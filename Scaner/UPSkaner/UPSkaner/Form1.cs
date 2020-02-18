using System;
using System.IO;
using System.Windows.Forms;
using WIA;
namespace Skaner
{
    public partial class Form1 : Form
    {
        DeviceManager deviceManager = new DeviceManager();
        DeviceInfo firstDevice = null;
        WIA.Device device;

        int resolution = 150;
        int width_pixel = 1250; //domyslnie 1250
        int height_pixel = 1700; //domyslnie 1700
        int jasnosc = 0;
        int kontrast = 0;
        int color_mode = 1;  // 1 - Kolor, 2 - Szary, 4 - Czarno-Biały 
        ImageFile imageFile;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            for (int i = 1; i <= deviceManager.DeviceInfos.Count; i++)
            {
                if (deviceManager.DeviceInfos[i].Type == WiaDeviceType.ScannerDeviceType)
                {
                    listBoxList.Items.Add(deviceManager.DeviceInfos[i].Properties["Name"].get_Value());
                    firstDevice = deviceManager.DeviceInfos[i];
                }
            }
            //listBoxList.SelectedIndex = 0;
           //listBoxList.SetSelected(0, true);
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            var device = firstDevice.Connect();
            var scannerItem = device.Items[1];
            AdjustScannerSettings(scannerItem, resolution, 0, 0, width_pixel, height_pixel, jasnosc, kontrast, color_mode);
            imageFile = (ImageFile)scannerItem.Transfer(FormatID.wiaFormatJPEG);


            string path = @"C:\Users\Marcin\Desktop\Studia\Semestr 5\UP\Skaner\UPSkaner\scan.jpeg"; ///zmienic sciezke

            if (File.Exists(path))
            {
                File.Delete(path);
            }

            imageFile.SaveFile(path);
            MessageBox.Show("Obraz został zapisany do pliku.");
            pictureBox1.ImageLocation = path;

        }

        private void trackBarJasnosc_Scroll(object sender, EventArgs e)
        {
            jasnosc = trackBarJasnosc.Value;
            labelJasnoscValue.Text = trackBarJasnosc.Value.ToString();
        }

        private void trackBarKontrast_Scroll(object sender, EventArgs e)
        {
            kontrast = trackBarKontrast.Value;
            labelKontrastValue.Text = trackBarKontrast.Value.ToString();
        }

        private static void AdjustScannerSettings(IItem scannnerItem, int scanResolutionDPI, int scanStartLeftPixel, int scanStartTopPixel, int scanWidthPixels, int scanHeightPixels, int brightnessPercents, int contrastPercents, int colorMode)
        {
            const string WIA_SCAN_COLOR_MODE = "6146";
            const string WIA_HORIZONTAL_SCAN_RESOLUTION_DPI = "6147";
            const string WIA_VERTICAL_SCAN_RESOLUTION_DPI = "6148";
            const string WIA_HORIZONTAL_SCAN_START_PIXEL = "6149";
            const string WIA_VERTICAL_SCAN_START_PIXEL = "6150";
            const string WIA_HORIZONTAL_SCAN_SIZE_PIXELS = "6151";
            const string WIA_VERTICAL_SCAN_SIZE_PIXELS = "6152";
            const string WIA_SCAN_BRIGHTNESS_PERCENTS = "6154";
            const string WIA_SCAN_CONTRAST_PERCENTS = "6155";
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_RESOLUTION_DPI, scanResolutionDPI);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_START_PIXEL, scanStartLeftPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_START_PIXEL, scanStartTopPixel);
            SetWIAProperty(scannnerItem.Properties, WIA_HORIZONTAL_SCAN_SIZE_PIXELS, scanWidthPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_VERTICAL_SCAN_SIZE_PIXELS, scanHeightPixels);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_BRIGHTNESS_PERCENTS, brightnessPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_CONTRAST_PERCENTS, contrastPercents);
            SetWIAProperty(scannnerItem.Properties, WIA_SCAN_COLOR_MODE, colorMode);
        }

        private static void SetWIAProperty(IProperties properties, object propName, object propValue)
        {
            Property prop = properties.get_Item(ref propName);
            prop.set_Value(ref propValue);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string tryb = comboBox1.Text;

            if (tryb.Equals("Kolorowy")) color_mode = 1;
            if (tryb.Equals("Czarno-bialy")) color_mode = 4;
            if (tryb.Equals("Szary")) color_mode = 2;

            //switch (tryb)
            //{
            //    case "Kolorowy":
            //        {
            //            color_mode = 1;
            //        }
            //        break;
            //    case "Czarno-bialy":
            //        {
            //            color_mode = 2;
            //        }
            //        break;
            //    case "Szary":
            //        {
            //            color_mode = 3;
            //        }
            //        break;
            //    default:
            //        {
            //            color_mode = 1;
            //        }
            //        break;
            //}

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

    }
}
