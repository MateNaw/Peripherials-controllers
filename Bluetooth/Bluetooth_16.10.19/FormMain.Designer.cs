namespace Bluetooth_16._10._19
{
    partial class FormMain
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
            this.listboxDevices = new System.Windows.Forms.ListBox();
            this.labelPaired = new System.Windows.Forms.Label();
            this.labelConnected = new System.Windows.Forms.Label();
            this.textBoxPaired = new System.Windows.Forms.TextBox();
            this.textBoxConnected = new System.Windows.Forms.TextBox();
            this.buttonPair = new System.Windows.Forms.Button();
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.labelFileInfo = new System.Windows.Forms.Label();
            this.textBoxFileInfo = new System.Windows.Forms.TextBox();
            this.buttonFile = new System.Windows.Forms.Button();
            this.buttonSend = new System.Windows.Forms.Button();
            this.labelFilters = new System.Windows.Forms.Label();
            this.checkBoxAuth = new System.Windows.Forms.CheckBox();
            this.checkBoxRemembered = new System.Windows.Forms.CheckBox();
            this.checkBoxUnknown = new System.Windows.Forms.CheckBox();
            this.buttonServices = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // listboxDevices
            // 
            this.listboxDevices.FormattingEnabled = true;
            this.listboxDevices.ItemHeight = 20;
            this.listboxDevices.Location = new System.Drawing.Point(12, 12);
            this.listboxDevices.Name = "listboxDevices";
            this.listboxDevices.Size = new System.Drawing.Size(480, 224);
            this.listboxDevices.TabIndex = 0;
            this.listboxDevices.SelectedIndexChanged += new System.EventHandler(this.listboxDevices_SelectedIndexChanged);
            // 
            // labelPaired
            // 
            this.labelPaired.AutoSize = true;
            this.labelPaired.Location = new System.Drawing.Point(12, 255);
            this.labelPaired.Name = "labelPaired";
            this.labelPaired.Size = new System.Drawing.Size(101, 20);
            this.labelPaired.TabIndex = 1;
            this.labelPaired.Text = "Sparowany - ";
            // 
            // labelConnected
            // 
            this.labelConnected.AutoSize = true;
            this.labelConnected.Location = new System.Drawing.Point(246, 255);
            this.labelConnected.Name = "labelConnected";
            this.labelConnected.Size = new System.Drawing.Size(91, 20);
            this.labelConnected.TabIndex = 2;
            this.labelConnected.Text = "Połączony -";
            // 
            // textBoxPaired
            // 
            this.textBoxPaired.Location = new System.Drawing.Point(119, 252);
            this.textBoxPaired.Name = "textBoxPaired";
            this.textBoxPaired.ReadOnly = true;
            this.textBoxPaired.Size = new System.Drawing.Size(100, 26);
            this.textBoxPaired.TabIndex = 3;
            // 
            // textBoxConnected
            // 
            this.textBoxConnected.Location = new System.Drawing.Point(343, 252);
            this.textBoxConnected.Name = "textBoxConnected";
            this.textBoxConnected.ReadOnly = true;
            this.textBoxConnected.Size = new System.Drawing.Size(100, 26);
            this.textBoxConnected.TabIndex = 4;
            // 
            // buttonPair
            // 
            this.buttonPair.Location = new System.Drawing.Point(498, 106);
            this.buttonPair.Name = "buttonPair";
            this.buttonPair.Size = new System.Drawing.Size(160, 56);
            this.buttonPair.TabIndex = 5;
            this.buttonPair.Text = "Sparuj";
            this.buttonPair.UseVisualStyleBackColor = true;
            this.buttonPair.Click += new System.EventHandler(this.buttonPair_Click);
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(498, 28);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(160, 57);
            this.buttonRefresh.TabIndex = 6;
            this.buttonRefresh.Text = "Odśwież listę";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // labelFileInfo
            // 
            this.labelFileInfo.AutoSize = true;
            this.labelFileInfo.Location = new System.Drawing.Point(488, 286);
            this.labelFileInfo.Name = "labelFileInfo";
            this.labelFileInfo.Size = new System.Drawing.Size(204, 20);
            this.labelFileInfo.TabIndex = 7;
            this.labelFileInfo.Text = "Scieżka pliku do przesłania ";
            // 
            // textBoxFileInfo
            // 
            this.textBoxFileInfo.Location = new System.Drawing.Point(694, 283);
            this.textBoxFileInfo.Name = "textBoxFileInfo";
            this.textBoxFileInfo.ReadOnly = true;
            this.textBoxFileInfo.Size = new System.Drawing.Size(385, 26);
            this.textBoxFileInfo.TabIndex = 8;
            // 
            // buttonFile
            // 
            this.buttonFile.Location = new System.Drawing.Point(694, 324);
            this.buttonFile.Name = "buttonFile";
            this.buttonFile.Size = new System.Drawing.Size(174, 61);
            this.buttonFile.TabIndex = 9;
            this.buttonFile.Text = "WYBIERZ PLIK";
            this.buttonFile.UseVisualStyleBackColor = true;
            this.buttonFile.Click += new System.EventHandler(this.buttonFile_Click);
            // 
            // buttonSend
            // 
            this.buttonSend.Location = new System.Drawing.Point(893, 324);
            this.buttonSend.Name = "buttonSend";
            this.buttonSend.Size = new System.Drawing.Size(174, 61);
            this.buttonSend.TabIndex = 10;
            this.buttonSend.Text = "WYŚLIJ";
            this.buttonSend.UseVisualStyleBackColor = true;
            this.buttonSend.Click += new System.EventHandler(this.buttonSend_Click);
            // 
            // labelFilters
            // 
            this.labelFilters.AutoSize = true;
            this.labelFilters.Location = new System.Drawing.Point(740, 46);
            this.labelFilters.Name = "labelFilters";
            this.labelFilters.Size = new System.Drawing.Size(258, 20);
            this.labelFilters.TabIndex = 11;
            this.labelFilters.Text = "Które urządzenia należy wyszukać: ";
            // 
            // checkBoxAuth
            // 
            this.checkBoxAuth.AutoSize = true;
            this.checkBoxAuth.Location = new System.Drawing.Point(755, 79);
            this.checkBoxAuth.Name = "checkBoxAuth";
            this.checkBoxAuth.Size = new System.Drawing.Size(146, 24);
            this.checkBoxAuth.TabIndex = 12;
            this.checkBoxAuth.Text = "Uwierzytelnione";
            this.checkBoxAuth.UseVisualStyleBackColor = true;
            this.checkBoxAuth.CheckedChanged += new System.EventHandler(this.checkBoxAuth_CheckedChanged);
            // 
            // checkBoxRemembered
            // 
            this.checkBoxRemembered.AutoSize = true;
            this.checkBoxRemembered.Location = new System.Drawing.Point(755, 109);
            this.checkBoxRemembered.Name = "checkBoxRemembered";
            this.checkBoxRemembered.Size = new System.Drawing.Size(129, 24);
            this.checkBoxRemembered.TabIndex = 13;
            this.checkBoxRemembered.Text = "Zapamiętane";
            this.checkBoxRemembered.UseVisualStyleBackColor = true;
            this.checkBoxRemembered.CheckedChanged += new System.EventHandler(this.checkBoxRemembered_CheckedChanged);
            // 
            // checkBoxUnknown
            // 
            this.checkBoxUnknown.AutoSize = true;
            this.checkBoxUnknown.Location = new System.Drawing.Point(755, 140);
            this.checkBoxUnknown.Name = "checkBoxUnknown";
            this.checkBoxUnknown.Size = new System.Drawing.Size(102, 24);
            this.checkBoxUnknown.TabIndex = 14;
            this.checkBoxUnknown.Text = "Nieznane";
            this.checkBoxUnknown.UseVisualStyleBackColor = true;
            this.checkBoxUnknown.CheckedChanged += new System.EventHandler(this.checkBoxUnknown_CheckedChanged);
            // 
            // buttonServices
            // 
            this.buttonServices.Location = new System.Drawing.Point(498, 180);
            this.buttonServices.Name = "buttonServices";
            this.buttonServices.Size = new System.Drawing.Size(160, 56);
            this.buttonServices.TabIndex = 15;
            this.buttonServices.Text = "Wyświetl serwisy urządzenia";
            this.buttonServices.UseVisualStyleBackColor = true;
            this.buttonServices.Click += new System.EventHandler(this.buttonServices_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1136, 430);
            this.Controls.Add(this.buttonServices);
            this.Controls.Add(this.checkBoxUnknown);
            this.Controls.Add(this.checkBoxRemembered);
            this.Controls.Add(this.checkBoxAuth);
            this.Controls.Add(this.labelFilters);
            this.Controls.Add(this.buttonSend);
            this.Controls.Add(this.buttonFile);
            this.Controls.Add(this.textBoxFileInfo);
            this.Controls.Add(this.labelFileInfo);
            this.Controls.Add(this.buttonRefresh);
            this.Controls.Add(this.buttonPair);
            this.Controls.Add(this.textBoxConnected);
            this.Controls.Add(this.textBoxPaired);
            this.Controls.Add(this.labelConnected);
            this.Controls.Add(this.labelPaired);
            this.Controls.Add(this.listboxDevices);
            this.Name = "FormMain";
            this.Text = "Łączność Bluetooth";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listboxDevices;
        private System.Windows.Forms.Label labelPaired;
        private System.Windows.Forms.Label labelConnected;
        private System.Windows.Forms.TextBox textBoxPaired;
        private System.Windows.Forms.TextBox textBoxConnected;
        private System.Windows.Forms.Button buttonPair;
        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.Label labelFileInfo;
        private System.Windows.Forms.TextBox textBoxFileInfo;
        private System.Windows.Forms.Button buttonFile;
        private System.Windows.Forms.Button buttonSend;
        private System.Windows.Forms.Label labelFilters;
        private System.Windows.Forms.CheckBox checkBoxAuth;
        private System.Windows.Forms.CheckBox checkBoxRemembered;
        private System.Windows.Forms.CheckBox checkBoxUnknown;
        private System.Windows.Forms.Button buttonServices;
    }
}
