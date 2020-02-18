#include <iostream>
#include <iomanip>
#include <Windows.h>
#include <dsound.h>
#pragma comment(lib, "dsound.lib")
#pragma comment(lib, "dxguid.lib")
#pragma comment(lib, "winmm.lib")
#pragma comment(lib, "ole32.lib")

#define __ECHO_FX__ 1
#define __WAVES_REVERB_FX__ 2
#define __DISTORSION_FX__ 3

IDirectSound8* pDS;
IDirectSoundBuffer* pBuffer;
IDirectSoundBuffer8* pSecBuffer;

WAVEHDR hdr;
bool isPlaying = false;

HWAVEOUT hWaveOut;
HWAVEIN hWaveIn;

MCIDEVICEID wDeviceID;

HRESULT InitDirectSound()
{
	HRESULT hr;

	DSBUFFERDESC dsBufDesc;
	WAVEFORMATEX wav;
	
	hr = CoInitializeEx(NULL, COINIT_MULTITHREADED);
	if (FAILED(hr))
		return hr;

	hr = DirectSoundCreate8(NULL, &pDS, NULL);
	if (FAILED(hr))
		return hr;

	hr = pDS->SetCooperativeLevel(GetConsoleWindow(), DSSCL_PRIORITY);
	if (FAILED(hr))
		return hr;

	dsBufDesc.dwSize = sizeof(DSBUFFERDESC);
	dsBufDesc.dwFlags = DSBCAPS_CTRLVOLUME | DSBCAPS_PRIMARYBUFFER;
	dsBufDesc.dwReserved = 0;
	dsBufDesc.dwBufferBytes = 0;
	dsBufDesc.lpwfxFormat = NULL;
	dsBufDesc.guid3DAlgorithm = GUID_NULL;

	hr = pDS->CreateSoundBuffer(&dsBufDesc, &pBuffer, NULL);
	if (FAILED(hr))
		return hr;

	wav.cbSize = 0;
	wav.wFormatTag = WAVE_FORMAT_PCM;
	wav.nSamplesPerSec = 44100;
	wav.nChannels = 2;
	wav.wBitsPerSample = 16;
	wav.nBlockAlign = (wav.wBitsPerSample / 8) * wav.nChannels;
	wav.nAvgBytesPerSec = wav.nSamplesPerSec * wav.nBlockAlign;

	hr = pBuffer->SetFormat(&wav);
	if (FAILED(hr))
		return hr;

	return S_OK;
}

bool loadWavDS(const char* filename)
{
	HRESULT hr;
	FILE* file;
	IDirectSoundBuffer* tempBuf;
	unsigned char* wavData = nullptr;
	size_t count = 0;
	DSBUFFERDESC bufDesc;
	LPWAVEFORMATEX wav = new WAVEFORMATEX;

	fopen_s(&file, filename, "rb");
	if (file == NULL)
	{
		printf("Blad przy otwieraniu pliku\n");
		return false;
	}

	fseek(file, 20, SEEK_SET);
	count += fread(&(wav->wFormatTag), sizeof(WORD), 1, file);
	count += fread(&(wav->nChannels), sizeof(WORD), 1, file);
	count += fread(&(wav->nSamplesPerSec), sizeof(DWORD), 1, file);
	count += fread(&(wav->nAvgBytesPerSec), sizeof(DWORD), 1, file);
	count += fread(&(wav->nBlockAlign), sizeof(WORD), 1, file);
	count += fread(&(wav->wBitsPerSample), sizeof(WORD), 1, file);
	wav->cbSize = 0;
	fseek(file, 40, SEEK_SET);
	count += fread(&hdr.dwBufferLength, sizeof(DWORD), 1, file);
	if (count != 7)
	{
		printf("Blad wczytywania naglowka pliku wav\n");
		delete wav;
		return false;
	}

	hdr.lpData = (LPSTR)malloc(hdr.dwBufferLength);
	if (hdr.lpData == NULL)
	{
		printf("Blad alokacji pamieci\n");
		delete wav;
		free(hdr.lpData);
		return false;
	}
	if (!fread(hdr.lpData, 1, hdr.dwBufferLength, file))
	{
		printf("Blad wczytywania sekcji danych pliku wav\n");
		delete wav;
		free(hdr.lpData);
		return false;
	}

	bufDesc.dwSize = sizeof(DSBUFFERDESC);
	bufDesc.dwFlags = DSBCAPS_CTRLFX | DSBCAPS_CTRLVOLUME;
	bufDesc.dwReserved = 0;
	bufDesc.dwBufferBytes = hdr.dwBufferLength;
	bufDesc.lpwfxFormat = wav;
	bufDesc.guid3DAlgorithm = GUID_NULL;

	hr = pDS->CreateSoundBuffer(&bufDesc, &tempBuf, NULL);
	if (FAILED(hr))
	{
		printf("CreateSoundBuffer() failed\n");
		delete wav;
		free(hdr.lpData);
		return false;
	}
	
	hr = tempBuf->QueryInterface(IID_IDirectSoundBuffer8, (LPVOID*)&pSecBuffer);
	if (FAILED(hr))
	{
		printf("QueryInterface() failed");
		delete wav;
		free(hdr.lpData);
		return false;
	}

	DWORD bufferSize;
	hr = pSecBuffer->Lock(0, hdr.dwBufferLength, (LPVOID*)&wavData, &bufferSize, NULL, NULL, NULL);
	if (FAILED(hr))
	{
		printf("Lock() failed");
		delete wav;
		free(hdr.lpData);
		return false;
	}
	memcpy(wavData, hdr.lpData, bufferSize);
	hr = pSecBuffer->Unlock((LPVOID)wavData, bufferSize, NULL, NULL);
	if (FAILED(hr))
	{
		printf("Unlock() failed");
		delete wav;
		free(hdr.lpData);
		return false;
	}

	free(hdr.lpData);
	delete wav;
	tempBuf->Release();

	return true;
}

bool setFX(const int effect)
{
	LPDSEFFECTDESC pFX = new DSEFFECTDESC;
	DWORD dwRetCodes;

	pFX->dwSize = sizeof(DSEFFECTDESC);
	pFX->dwFlags = 0;
	switch (effect)
	{
	case __ECHO_FX__:
		pFX->guidDSFXClass = GUID_DSFX_STANDARD_ECHO;
		break;
	case __WAVES_REVERB_FX__:
		pFX->guidDSFXClass = GUID_DSFX_WAVES_REVERB;
		break;
	case __DISTORSION_FX__:
		pFX->guidDSFXClass = GUID_DSFX_STANDARD_DISTORTION;
		break;
	default:
		pFX->guidDSFXClass = GUID_DSFX_STANDARD_ECHO;
		break;
	}
	pFX->dwReserved1 = 0;
	pFX->dwReserved2 = 0;

	HRESULT hr = pSecBuffer->SetFX(1, pFX, &dwRetCodes);
	if (hr != DS_OK) 
	{
		printf("Ustawianie efektow nie powiodlo sie\n");
		return false;
	}

	delete pFX;

	return true;
}

bool playDS()
{
	HRESULT hr = pSecBuffer->SetCurrentPosition(0);
	if (FAILED(hr))
		return false;
	hr = pSecBuffer->SetVolume(DSBVOLUME_MAX);
	if (FAILED(hr))
		return false;
	hr = pSecBuffer->Play(0, 0, 0);
	if (FAILED(hr))
		return false;

	isPlaying = true;
	
	return true;
}

void stopDS()
{
	if(isPlaying)
	{
		pBuffer->Stop();
		pSecBuffer->Stop();
		pSecBuffer->Release();
		isPlaying = false;
	}
}

void ReleaseDS()
{
	pBuffer->Release();
	pDS->Release();
}

void playPlaySound(const char* fileName)
{
	PlaySoundA(fileName, NULL, SND_ASYNC | SND_FILENAME);
	isPlaying = true;
}

void stopPlaySound()
{
	if(isPlaying)
	{
		PlaySoundA(NULL, NULL, SND_ASYNC);
		isPlaying = false;
	}
}

WAVEFORMATEX* readWav(const char* fileName)
{
	FILE* file;
	LPWAVEFORMATEX wav = new WAVEFORMATEX;
	size_t count = 0;
	
	fopen_s(&file, fileName, "rb");
	if (file == NULL)
	{
		printf("Blad przy otwieraniu pliku\n");
		return nullptr;
	}

	fseek(file, 20, SEEK_SET);
	count += fread(&(wav->wFormatTag), sizeof(WORD), 1, file);
	count += fread(&(wav->nChannels), sizeof(WORD), 1, file);
	count += fread(&(wav->nSamplesPerSec), sizeof(DWORD), 1, file);
	count += fread(&(wav->nAvgBytesPerSec), sizeof(DWORD), 1, file);
	count += fread(&(wav->nBlockAlign), sizeof(WORD), 1, file);
	count += fread(&(wav->wBitsPerSample), sizeof(WORD), 1, file);
	wav->cbSize = 0;
	fseek(file, 40, SEEK_SET);
	count += fread(&hdr.dwBufferLength, sizeof(DWORD), 1, file);
	if (count != 7)
	{
		printf("Blad wczytywania naglowka pliku wav\n");
		delete wav;
		return nullptr;
	}

	hdr.lpData = (LPSTR)malloc(hdr.dwBufferLength);
	if (hdr.lpData == NULL)
	{
		printf("Blad alokacji pamieci\n");
		free(hdr.lpData);
		delete wav;
		return nullptr;
	}
	if (!fread(hdr.lpData, 1, hdr.dwBufferLength, file))
	{
		printf("Blad wczytywania sekcji danych pliku wav\n");
		free(hdr.lpData);
		delete wav;
		return nullptr;
	}

	return wav;
}

void playWaveOut(LPWAVEFORMATEX wav)
{
	waveOutOpen(&hWaveOut, WAVE_MAPPER, wav, NULL, NULL, CALLBACK_NULL);
	waveOutPrepareHeader(hWaveOut, &hdr, sizeof(WAVEHDR));
	waveOutWrite(hWaveOut, &hdr, sizeof(WAVEHDR));
	isPlaying = true;
}

void stopWaveOut(LPWAVEFORMATEX wav)
{
	if(isPlaying)
	{
		waveOutReset(hWaveOut);
		waveOutClose(hWaveOut);
		free(hdr.lpData);
		delete wav;
		isPlaying = false;
	}
}

void playMCI(const char* fileName)
{
	MCI_OPEN_PARMSA mciOpenParms;
	mciOpenParms.lpstrDeviceType = "waveaudio";
	mciOpenParms.lpstrElementName = fileName;
	
	if(mciSendCommandA(0, MCI_OPEN, MCI_OPEN_TYPE | MCI_OPEN_ELEMENT, (DWORD_PTR)&mciOpenParms))
		return;

	wDeviceID = mciOpenParms.wDeviceID;
	MCI_PLAY_PARMS mciPlayParms;

	if(!mciSendCommandA(wDeviceID, MCI_PLAY, MCI_NOTIFY, (DWORD_PTR)&mciPlayParms))
		isPlaying = true;
}

void stopMCI()
{
	if(isPlaying)
	{
		mciSendCommandA(wDeviceID, MCI_CLOSE, NULL, NULL);
		isPlaying = false;
	}
}

char* recordWaveIn()
{
	WORD wChannels = 1;
	DWORD dwSamplesPerSecond = 44100;
	WORD wBitsPerSample = 8;
	DWORD wDurationSec = 10;

	WAVEFORMATEX wav;
	wav.wFormatTag = WAVE_FORMAT_PCM;
	wav.nChannels = wChannels;
	wav.nSamplesPerSec = dwSamplesPerSecond;
	wav.wBitsPerSample = wBitsPerSample;
	wav.nAvgBytesPerSec = dwSamplesPerSecond * wChannels;
	wav.nBlockAlign = (wChannels * wBitsPerSample) / 8;
	wav.cbSize = 0;

	MMRESULT result = waveInOpen(&hWaveIn, WAVE_MAPPER, &wav, 0, 0, WAVE_FORMAT_QUERY);
	if (result == WAVERR_BADFORMAT)
		return nullptr;

	result = waveInOpen(&hWaveIn, WAVE_MAPPER, &wav, 0, 0, CALLBACK_NULL);

	DWORD dwBufSize = wDurationSec * (wBitsPerSample / 8) * dwSamplesPerSecond * wChannels;
	char* buffer = (char*)malloc(dwBufSize);

	hdr.dwBufferLength = dwBufSize;
	hdr.dwFlags = 0;
	hdr.lpData = buffer;

	result = waveInPrepareHeader(hWaveIn, &hdr, sizeof(WAVEHDR));
	if (result)
	{
		std::cout << "Blad przygotowywania naglowka\n";
		free(buffer);
		return nullptr;
	}

	result = waveInAddBuffer(hWaveIn, &hdr, sizeof(WAVEHDR));
	if (result)
	{
		std::cout << "Blad przygotowywania buforu\n";
		free(buffer);
		return nullptr;
	}

	result = waveInStart(hWaveIn);
	if (result != MMSYSERR_NOERROR)
	{
		std::cout << "Blad nagrywania dzwieku\n";
		free(buffer);
		return nullptr;
	}

	return buffer;
}

void recordPlay()
{
	WORD wChannels = 1;
	DWORD dwSamplesPerSecond = 44100;
	WORD wBitsPerSample = 8;
	
	WAVEFORMATEX wav;
	wav.wFormatTag = WAVE_FORMAT_PCM;
	wav.nChannels = wChannels;
	wav.nSamplesPerSec = dwSamplesPerSecond;
	wav.wBitsPerSample = wBitsPerSample;
	wav.nAvgBytesPerSec = dwSamplesPerSecond * wChannels;
	wav.nBlockAlign = (wChannels*wBitsPerSample)/8;
	wav.cbSize = 0;
	
	MMRESULT result = waveOutOpen(&hWaveOut, WAVE_MAPPER, &wav, NULL, NULL, WAVE_FORMAT_QUERY);
	if (result == WAVERR_BADFORMAT)
		return;

	result = waveOutOpen(&hWaveOut, WAVE_MAPPER, &wav, NULL, NULL, CALLBACK_NULL);
	result = waveOutPrepareHeader(hWaveOut, &hdr, sizeof(WAVEHDR));
	result = waveOutWrite(hWaveOut, &hdr, sizeof(WAVEHDR));
	
	isPlaying = true;
}

int main(int argc, char* argv[])
{
	if (InitDirectSound() != S_OK)
	{
		printf("Nie udalo sie zainicjalizowac DirectSound\n");
		return EXIT_FAILURE;
	}

	char input = 0;

	while(input != '0')
	{
		std::cout << "KARTA MUZYCZNA - MENU\n";
		std::cout.fill('-');
		std::cout << std::setw(20) << '-' << '\n';
		std::cout.fill(' ');
		std::cout << "1. Odtworz plik wav - PlaySound\n";
		std::cout << "2. Odtworz plik wav - MCI\n";
		std::cout << "3. Odtworz plik wav - WaveOut\n";
		std::cout << "4. Odtworz plik wav - DirectSound\n";
		std::cout << "5. Nagraj dzwiek - WaveIn\n\n";
		std::cout << "0. Zakoncz\n\n";
		std::cout << "Twoj wybor: ";
		std::cin >> input;
		switch(input)
		{
		case '1':
			{
				std::string fileName;
				std::cout << "Podaj nazwe pliku: ";
				std::cin >> fileName;
				playPlaySound(fileName.c_str());
				std::cout << "[Wcisnij przycisk by przerwac]\n";
				std::cin.get();
				std::cin.get();
				stopPlaySound();
				break;
			}
		case '2':
			{
				std::string fileName;
				std::cout << "Podaj nazwe pliku: ";
				std::cin >> fileName;
				playMCI(fileName.c_str());
				std::cout << "[Wcisnij ENTER by przerwac]\n";
				getchar();
				getchar();
				stopMCI();
				break;
			}
		case '3':
			{
				std::string fileName;
				std::cout << "Podaj nazwe pliku: ";
				std::cin >> fileName;
				LPWAVEFORMATEX wav = readWav(fileName.c_str());
				if(!wav)
				{
					std::cout << "Wystapil blad wczytywania pliku\n";
					break;
				}
				playWaveOut(wav);
				std::cout << "[Wcisnij przycisk by przerwac]\n";
				getchar();
				getchar();
				stopPlaySound();
				break;
			}
		case '4':
			{
				std::string fileName;
				char effect;
				std::cout << "Podaj nazwe pliku: ";
				std::cin >> fileName;
				if(loadWavDS(fileName.c_str()))
				{
					std::cout << "WYBIERZ EFEKT\n";
					std::cout << "1. ECHO\n";
					std::cout << "2. REVERB\n";
					std::cout << "3. DISTORTION\n";
					std::cout << "4. BRAK\n";
					std::cout << "Twoj wybor: ";
					std::cin >> effect;
					switch(effect)
					{
					case '1':
						setFX(__ECHO_FX__);
						break;
					case '2':
						setFX(__WAVES_REVERB_FX__);
						break;
					case '3':
						setFX(__DISTORSION_FX__);
						break;
					}
					playDS();
					std::cout << "[Wcisnij przycisk by przerwac]\n";
					getchar();
					getchar();
					stopDS();
				}
				else
				{
					std::cout << "Wystapil blad wczytywania pliku\n";
				}
				break;
			}
		case '5':
			{
				std::cout << "Nagrywanie dzwieku (10 sekund)\n";
				char* buffer = recordWaveIn();
				if(!buffer)
				{
					std::cout << "Blad nagrywania\n";
					break;
				}
				Sleep(10000);
				std::cout << "Zakonczono nagrywanie\n";
				std::cout << "[Wcisnij ENTER aby odtworzyc nagranie]\n";
				getchar();
				getchar();
				recordPlay();
				std::cout << "[Wcisnij ENTER aby przerwac]\n";
				getchar();
				stopWaveOut(nullptr);
			}
			break;
		case '0':
			break;
		default:
			std::cout << "Bledny wybor!!!\n";
			break;
		}
	}

	return EXIT_SUCCESS;
}
