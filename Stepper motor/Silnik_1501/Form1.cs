using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Silnik_1501
{
    

    public partial class Form1 : Form
    {
        Silnik silnik;
        string[] tryby = { "Polkrokowy", "Jednofazowy", "Dwufazowy" };

        public Form1()
        {

            silnik = new Silnik();
            InitializeComponent();
            foreach (var item in tryby)
                comboBox1.Items.Add(item);
            comboBox1.SelectedIndex = 0;
        }

        private void buttonLeft_Click(object sender, EventArgs e)
        {
            if (!silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie nie jest polaczone");
                return;
            }
            int steps = int.Parse(this.textBoxSteps.Text);
            int interval = int.Parse(this.textBoxInterval.Text);
            silnik.Krok(true, steps, interval, 1);
        }

        private void buttonConnect_Click(object sender, EventArgs e)
        {
            if (silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie jest juz polaczone");
                return;
            }
            silnik.Polacz();
            MessageBox.Show("Polaczono z " + silnik.Nazwa());
        }

        private void buttonDisconnect_Click(object sender, EventArgs e)
        {
            if (!silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie nie jest polaczone");
                return;
            }
            silnik.Rozlacz();
            MessageBox.Show("Rozlaczono z " + silnik.Nazwa());
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie nie jest polaczone");
                return;
            }
            int steps = int.Parse(this.textBoxSteps.Text);
            int interval = int.Parse(this.textBoxInterval.Text);
            silnik.Krok(false, steps, interval, 1);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBox1.SelectedIndex)
            {
                case 0:
                    silnik.SetTryb(TrybKontroli.POLKROK);
                    break;
                case 1:
                    silnik.SetTryb(TrybKontroli.JEDNOFAZOWA);
                    break;
                case 2:
                    silnik.SetTryb(TrybKontroli.DWUFAZOWA);
                    break;
                default:
                    break;
            }
        }

        private void buttonEpromRead_Click(object sender, EventArgs e)
        {
            if (!silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie nie jest polaczone");
                return;
            }
            MessageBox.Show(silnik.EpromRead());
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (!silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie nie jest polaczone");
                return;
            }
            int steps = int.Parse(this.textBoxSteps.Text);
            int interval = int.Parse(this.textBoxInterval.Text);
            silnik.Krok(true, steps, interval, 2);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (!silnik.Polaczone)
            {
                MessageBox.Show("Urzadzenie nie jest polaczone");
                return;
            }
            int steps = int.Parse(this.textBoxSteps.Text);
            int interval = int.Parse(this.textBoxInterval.Text);
            silnik.Krok(false, steps, interval, 2);
        }
    }
}
