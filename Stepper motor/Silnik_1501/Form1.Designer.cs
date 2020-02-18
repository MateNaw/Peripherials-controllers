namespace Silnik_1501
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
            this.buttonLeft = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.labelSteps = new System.Windows.Forms.Label();
            this.labelInterval = new System.Windows.Forms.Label();
            this.textBoxSteps = new System.Windows.Forms.TextBox();
            this.textBoxInterval = new System.Windows.Forms.TextBox();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.buttonDisconnect = new System.Windows.Forms.Button();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.labelTryb = new System.Windows.Forms.Label();
            this.buttonEpromRead = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonLeft
            // 
            this.buttonLeft.Location = new System.Drawing.Point(290, 105);
            this.buttonLeft.Name = "buttonLeft";
            this.buttonLeft.Size = new System.Drawing.Size(175, 78);
            this.buttonLeft.TabIndex = 0;
            this.buttonLeft.Text = "KROKI W LEWO (S1)";
            this.buttonLeft.UseVisualStyleBackColor = true;
            this.buttonLeft.Click += new System.EventHandler(this.buttonLeft_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(290, 198);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(175, 75);
            this.button2.TabIndex = 1;
            this.button2.Text = "KROKI W PRAWO (S1)";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // labelSteps
            // 
            this.labelSteps.AutoSize = true;
            this.labelSteps.Location = new System.Drawing.Point(184, 293);
            this.labelSteps.Name = "labelSteps";
            this.labelSteps.Size = new System.Drawing.Size(100, 20);
            this.labelSteps.TabIndex = 2;
            this.labelSteps.Text = "Ilosc krokow:";
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(179, 335);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(105, 20);
            this.labelInterval.TabIndex = 3;
            this.labelInterval.Text = "Okres (w ms):";
            // 
            // textBoxSteps
            // 
            this.textBoxSteps.Location = new System.Drawing.Point(290, 290);
            this.textBoxSteps.Name = "textBoxSteps";
            this.textBoxSteps.Size = new System.Drawing.Size(175, 26);
            this.textBoxSteps.TabIndex = 4;
            this.textBoxSteps.Text = "10";
            // 
            // textBoxInterval
            // 
            this.textBoxInterval.Location = new System.Drawing.Point(290, 332);
            this.textBoxInterval.Name = "textBoxInterval";
            this.textBoxInterval.Size = new System.Drawing.Size(175, 26);
            this.textBoxInterval.TabIndex = 5;
            this.textBoxInterval.Tag = "";
            this.textBoxInterval.Text = "100";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Location = new System.Drawing.Point(12, 12);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(175, 78);
            this.buttonConnect.TabIndex = 6;
            this.buttonConnect.Text = "POLACZ";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // buttonDisconnect
            // 
            this.buttonDisconnect.Location = new System.Drawing.Point(290, 12);
            this.buttonDisconnect.Name = "buttonDisconnect";
            this.buttonDisconnect.Size = new System.Drawing.Size(175, 78);
            this.buttonDisconnect.TabIndex = 7;
            this.buttonDisconnect.Text = "ODLACZ";
            this.buttonDisconnect.UseVisualStyleBackColor = true;
            this.buttonDisconnect.Click += new System.EventHandler(this.buttonDisconnect_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(290, 373);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 28);
            this.comboBox1.TabIndex = 8;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // labelTryb
            // 
            this.labelTryb.AutoSize = true;
            this.labelTryb.Location = new System.Drawing.Point(198, 376);
            this.labelTryb.Name = "labelTryb";
            this.labelTryb.Size = new System.Drawing.Size(86, 20);
            this.labelTryb.TabIndex = 9;
            this.labelTryb.Text = "Tryb silnika";
            // 
            // buttonEpromRead
            // 
            this.buttonEpromRead.Location = new System.Drawing.Point(12, 105);
            this.buttonEpromRead.Name = "buttonEpromRead";
            this.buttonEpromRead.Size = new System.Drawing.Size(175, 78);
            this.buttonEpromRead.TabIndex = 10;
            this.buttonEpromRead.Text = "ODCZYT EPROM";
            this.buttonEpromRead.UseVisualStyleBackColor = true;
            this.buttonEpromRead.Click += new System.EventHandler(this.buttonEpromRead_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(471, 105);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(175, 78);
            this.button1.TabIndex = 11;
            this.button1.Text = "KROKI W LEWO (S2)";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(471, 198);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(175, 75);
            this.button3.TabIndex = 12;
            this.button3.Text = "KROKI W PRAWO (S2)";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 423);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.buttonEpromRead);
            this.Controls.Add(this.labelTryb);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.buttonDisconnect);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.textBoxInterval);
            this.Controls.Add(this.textBoxSteps);
            this.Controls.Add(this.labelInterval);
            this.Controls.Add(this.labelSteps);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonLeft);
            this.Name = "Form1";
            this.Text = "Silnik krokowy";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonLeft;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label labelSteps;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.TextBox textBoxSteps;
        private System.Windows.Forms.TextBox textBoxInterval;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.Button buttonDisconnect;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label labelTryb;
        private System.Windows.Forms.Button buttonEpromRead;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button3;
    }
}

