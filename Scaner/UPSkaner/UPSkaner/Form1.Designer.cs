namespace Skaner
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonStart = new System.Windows.Forms.Button();
            this.listBoxList = new System.Windows.Forms.ListBox();
            this.trackBarJasnosc = new System.Windows.Forms.TrackBar();
            this.trackBarKontrast = new System.Windows.Forms.TrackBar();
            this.labelJasnosc = new System.Windows.Forms.Label();
            this.labelKontrast = new System.Windows.Forms.Label();
            this.labelJasnoscValue = new System.Windows.Forms.Label();
            this.labelKontrastValue = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarJasnosc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKontrast)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(380, 272);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(76, 42);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Skanuj";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // listBoxList
            // 
            this.listBoxList.FormattingEnabled = true;
            this.listBoxList.Location = new System.Drawing.Point(307, 218);
            this.listBoxList.Name = "listBoxList";
            this.listBoxList.Size = new System.Drawing.Size(239, 30);
            this.listBoxList.TabIndex = 1;
            // 
            // trackBarJasnosc
            // 
            this.trackBarJasnosc.Location = new System.Drawing.Point(302, 78);
            this.trackBarJasnosc.Maximum = 50;
            this.trackBarJasnosc.Minimum = -50;
            this.trackBarJasnosc.Name = "trackBarJasnosc";
            this.trackBarJasnosc.Size = new System.Drawing.Size(257, 45);
            this.trackBarJasnosc.SmallChange = 5;
            this.trackBarJasnosc.TabIndex = 2;
            this.trackBarJasnosc.TickFrequency = 5;
            this.trackBarJasnosc.Scroll += new System.EventHandler(this.trackBarJasnosc_Scroll);
            // 
            // trackBarKontrast
            // 
            this.trackBarKontrast.Location = new System.Drawing.Point(302, 27);
            this.trackBarKontrast.Maximum = 50;
            this.trackBarKontrast.Minimum = -50;
            this.trackBarKontrast.Name = "trackBarKontrast";
            this.trackBarKontrast.Size = new System.Drawing.Size(257, 45);
            this.trackBarKontrast.SmallChange = 5;
            this.trackBarKontrast.TabIndex = 3;
            this.trackBarKontrast.TickFrequency = 5;
            this.trackBarKontrast.Scroll += new System.EventHandler(this.trackBarKontrast_Scroll);
            // 
            // labelJasnosc
            // 
            this.labelJasnosc.AutoSize = true;
            this.labelJasnosc.Location = new System.Drawing.Point(312, 62);
            this.labelJasnosc.Name = "labelJasnosc";
            this.labelJasnosc.Size = new System.Drawing.Size(46, 13);
            this.labelJasnosc.TabIndex = 4;
            this.labelJasnosc.Text = "Jasność";
            // 
            // labelKontrast
            // 
            this.labelKontrast.AutoSize = true;
            this.labelKontrast.Location = new System.Drawing.Point(312, 11);
            this.labelKontrast.Name = "labelKontrast";
            this.labelKontrast.Size = new System.Drawing.Size(46, 13);
            this.labelKontrast.TabIndex = 5;
            this.labelKontrast.Text = "Kontrast";
            // 
            // labelJasnoscValue
            // 
            this.labelJasnoscValue.AutoSize = true;
            this.labelJasnoscValue.Location = new System.Drawing.Point(533, 62);
            this.labelJasnoscValue.Name = "labelJasnoscValue";
            this.labelJasnoscValue.Size = new System.Drawing.Size(13, 13);
            this.labelJasnoscValue.TabIndex = 6;
            this.labelJasnoscValue.Text = "0";
            // 
            // labelKontrastValue
            // 
            this.labelKontrastValue.AutoSize = true;
            this.labelKontrastValue.Location = new System.Drawing.Point(533, 11);
            this.labelKontrastValue.Name = "labelKontrastValue";
            this.labelKontrastValue.Size = new System.Drawing.Size(13, 13);
            this.labelKontrastValue.TabIndex = 7;
            this.labelKontrastValue.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(265, 358);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 11;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "Kolorowy",
            "Czarno-bialy",
            "Szary"});
            this.comboBox1.Location = new System.Drawing.Point(307, 140);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(239, 21);
            this.comboBox1.TabIndex = 12;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 382);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelKontrastValue);
            this.Controls.Add(this.labelJasnoscValue);
            this.Controls.Add(this.labelKontrast);
            this.Controls.Add(this.labelJasnosc);
            this.Controls.Add(this.trackBarKontrast);
            this.Controls.Add(this.trackBarJasnosc);
            this.Controls.Add(this.listBoxList);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.Text = "Skanowanie";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarJasnosc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarKontrast)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.ListBox listBoxList;
        private System.Windows.Forms.TrackBar trackBarJasnosc;
        private System.Windows.Forms.TrackBar trackBarKontrast;
        private System.Windows.Forms.Label labelJasnosc;
        private System.Windows.Forms.Label labelKontrast;
        private System.Windows.Forms.Label labelJasnoscValue;
        private System.Windows.Forms.Label labelKontrastValue;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

