using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace Bluetooth_16._10._19
{
    public partial class FormMain : Form
    {

        string sFilePath = string.Empty;
        string sFileName = string.Empty;
        bool showAuthorized = false;
        bool showRemembered = false;
        bool showUnknown = false;

        public FormMain()
        {
            InitializeComponent();
        }

        private void listboxDevices_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxConnected.Text = ((BTDevice)listboxDevices.SelectedItem).Connected.ToString();
            textBoxPaired.Text = ((BTDevice)listboxDevices.SelectedItem).Paired.ToString();
        }

        private void buttonPair_Click(object sender, EventArgs e)
        {
            if(listboxDevices.SelectedItem == null)
            {
                MessageBox.Show("Musisz wybrać urządzenie.", "OSTRZEŻENIE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                BTDevice selected = (BTDevice)listboxDevices.SelectedItem;
                if(!BluetoothSecurity.PairRequest(selected.DeviceInfo.DeviceAddress, "9999"))
                {
                    MessageBox.Show("Nie można sparować z urządzeniem.", "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show("Udało się sparować z urządzeniem.", "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    selected.Connected = true;
                    selected.Paired = true;
                }
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            BluetoothClient client = new BluetoothClient();
            List<BTDevice> btDevices = new List<BTDevice>();
            var rawDeviceInfos = client.DiscoverDevices(10, showAuthorized, showRemembered, showUnknown);
            foreach (var item in rawDeviceInfos)
            {
                btDevices.Add(new BTDevice(item));
            }
            listboxDevices.DataSource = btDevices;
        }

        private void buttonFile_Click(object sender, EventArgs e)
        { 
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "C:\\Users\\lab\\Desktop";
                var fileChosen = openFileDialog.ShowDialog();
                if(fileChosen != DialogResult.OK)
                {
                    MessageBox.Show("Nie udało się wybrać pliku.", "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                sFilePath = openFileDialog.FileName;
                sFileName = sFilePath.Substring(sFilePath.LastIndexOf("\\") + 1);

                textBoxFileInfo.Text = sFilePath;
            }
        }

        private void buttonSend_Click(object sender, EventArgs e)
        {
            if(sFileName == string.Empty || sFilePath == string.Empty)
            {
                MessageBox.Show("Musisz wybrać plik.", "OSTRZEŻENIE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            BTDevice selected = (BTDevice)listboxDevices.SelectedItem;
            if(selected == null)
            {
                MessageBox.Show("Musisz wybrać urządzenie.", "OSTRZEŻENIE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            Uri uri = new Uri("obex://" + selected.DeviceInfo.DeviceAddress.ToString() + "/" + sFilePath);
            InTheHand.Net.ObexWebRequest request = new InTheHand.Net.ObexWebRequest(uri);
            request.ReadFile(sFilePath);
            InTheHand.Net.ObexWebResponse response;
            try
            {
                response = (InTheHand.Net.ObexWebResponse)request.GetResponse();
                response.Close();
                if(response.StatusCode == InTheHand.Net.ObexStatusCode.OK)
                {
                    MessageBox.Show("Udało się przesłać plik " + sFileName, "INFO", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Nie udało się wysłać pliku. (errCode = " + response.StatusCode.ToString() + ")",
                        "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Nie udało się wysłać pliku.,",
                        "BŁĄD", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void checkBoxAuth_CheckedChanged(object sender, EventArgs e)
        {
            showAuthorized = !showAuthorized;
        }

        private void checkBoxRemembered_CheckedChanged(object sender, EventArgs e)
        {
            showRemembered = !showRemembered;
        }

        private void checkBoxUnknown_CheckedChanged(object sender, EventArgs e)
        {
            showUnknown = !showUnknown;
        }

        private void buttonServices_Click(object sender, EventArgs e)
        {

            if (listboxDevices.SelectedItem == null)
            {
                MessageBox.Show("Musisz wybrać urządzenie.", "OSTRZEŻENIE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                var selected = (BTDevice)listboxDevices.SelectedItem;
                if (!selected.Paired)
                {
                    MessageBox.Show("Musisz sparować urządzenie.", "OSTRZEŻENIE", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                var serviceGuids = selected.DeviceInfo.InstalledServices;
                string list = "Lista serwisow obslugiwanych przez urzadzenie:\n";
                int counter = 1;
                foreach (var guid in serviceGuids)
                {
                    try
                    {
                        var name = BluetoothService.GetName(guid);
                        if(name != null)
                        {
                            list += "\t";
                            list += counter + ". ";
                            list += name;
                            list += "\n";
                            counter++;
                        }
                    }
                    catch (Exception)
                    {
                        continue;
                    }
                }
                MessageBox.Show(list, "LISTA SERWISOW", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
