namespace WatcherManagerClient
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabApp = new System.Windows.Forms.TabPage();
            this.dataAppLogs = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.AppExe = new System.Windows.Forms.ComboBox();
            this.AppUser = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.AppDateTo = new System.Windows.Forms.DateTimePicker();
            this.AppDateFrom = new System.Windows.Forms.DateTimePicker();
            this.tabDevice = new System.Windows.Forms.TabPage();
            this.dataDeviceLogs = new System.Windows.Forms.DataGridView();
            this.label6 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.DeviceUser = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.DeviceDateTo = new System.Windows.Forms.DateTimePicker();
            this.DeviceDateFrom = new System.Windows.Forms.DateTimePicker();
            this.tabUrl = new System.Windows.Forms.TabPage();
            this.dataWebLogs = new System.Windows.Forms.DataGridView();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.WebUrl = new System.Windows.Forms.ComboBox();
            this.WebUser = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.WebDateTo = new System.Windows.Forms.DateTimePicker();
            this.WebDateFrom = new System.Windows.Forms.DateTimePicker();
            this.tabControl1.SuspendLayout();
            this.tabApp.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAppLogs)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.tabDevice.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDeviceLogs)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabUrl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWebLogs)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabApp);
            this.tabControl1.Controls.Add(this.tabDevice);
            this.tabControl1.Controls.Add(this.tabUrl);
            this.tabControl1.Location = new System.Drawing.Point(1, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1162, 572);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Selecting += new System.Windows.Forms.TabControlCancelEventHandler(this.tabControl1_Selecting);
            // 
            // tabApp
            // 
            this.tabApp.Controls.Add(this.dataAppLogs);
            this.tabApp.Controls.Add(this.label1);
            this.tabApp.Controls.Add(this.groupBox1);
            this.tabApp.Location = new System.Drawing.Point(4, 25);
            this.tabApp.Name = "tabApp";
            this.tabApp.Padding = new System.Windows.Forms.Padding(3);
            this.tabApp.Size = new System.Drawing.Size(1154, 543);
            this.tabApp.TabIndex = 0;
            this.tabApp.Text = "Applications";
            this.tabApp.UseVisualStyleBackColor = true;
            // 
            // dataAppLogs
            // 
            this.dataAppLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataAppLogs.Location = new System.Drawing.Point(7, 122);
            this.dataAppLogs.Name = "dataAppLogs";
            this.dataAppLogs.RowHeadersWidth = 51;
            this.dataAppLogs.RowTemplate.Height = 24;
            this.dataAppLogs.Size = new System.Drawing.Size(1141, 411);
            this.dataAppLogs.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(7, 102);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(128, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Application Logs";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button4);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.AppExe);
            this.groupBox1.Controls.Add(this.AppUser);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.AppDateTo);
            this.groupBox1.Controls.Add(this.AppDateFrom);
            this.groupBox1.Location = new System.Drawing.Point(7, 6);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(808, 93);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filters";
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Location = new System.Drawing.Point(497, 59);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(137, 28);
            this.button4.TabIndex = 10;
            this.button4.Text = "Clear";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(640, 59);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 28);
            this.button1.TabIndex = 8;
            this.button1.Text = "Apply";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // AppExe
            // 
            this.AppExe.FormattingEnabled = true;
            this.AppExe.Location = new System.Drawing.Point(571, 15);
            this.AppExe.Name = "AppExe";
            this.AppExe.Size = new System.Drawing.Size(228, 24);
            this.AppExe.TabIndex = 7;
            // 
            // AppUser
            // 
            this.AppUser.FormattingEnabled = true;
            this.AppUser.Location = new System.Drawing.Point(83, 43);
            this.AppUser.Name = "AppUser";
            this.AppUser.Size = new System.Drawing.Size(352, 24);
            this.AppUser.TabIndex = 6;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(464, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 17);
            this.label5.TabIndex = 5;
            this.label5.Text = "For application";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "Fro user";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(259, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "to";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "Date from";
            // 
            // AppDateTo
            // 
            this.AppDateTo.Location = new System.Drawing.Point(285, 17);
            this.AppDateTo.Name = "AppDateTo";
            this.AppDateTo.Size = new System.Drawing.Size(170, 22);
            this.AppDateTo.TabIndex = 1;
            // 
            // AppDateFrom
            // 
            this.AppDateFrom.Location = new System.Drawing.Point(83, 17);
            this.AppDateFrom.Name = "AppDateFrom";
            this.AppDateFrom.Size = new System.Drawing.Size(168, 22);
            this.AppDateFrom.TabIndex = 0;
            // 
            // tabDevice
            // 
            this.tabDevice.Controls.Add(this.dataDeviceLogs);
            this.tabDevice.Controls.Add(this.label6);
            this.tabDevice.Controls.Add(this.groupBox2);
            this.tabDevice.Location = new System.Drawing.Point(4, 25);
            this.tabDevice.Name = "tabDevice";
            this.tabDevice.Padding = new System.Windows.Forms.Padding(3);
            this.tabDevice.Size = new System.Drawing.Size(1154, 543);
            this.tabDevice.TabIndex = 1;
            this.tabDevice.Text = "Devices";
            this.tabDevice.UseVisualStyleBackColor = true;
            // 
            // dataDeviceLogs
            // 
            this.dataDeviceLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataDeviceLogs.Location = new System.Drawing.Point(7, 124);
            this.dataDeviceLogs.Name = "dataDeviceLogs";
            this.dataDeviceLogs.RowHeadersWidth = 51;
            this.dataDeviceLogs.RowTemplate.Height = 24;
            this.dataDeviceLogs.Size = new System.Drawing.Size(1141, 411);
            this.dataDeviceLogs.TabIndex = 5;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(7, 104);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(97, 17);
            this.label6.TabIndex = 4;
            this.label6.Text = "Device Logs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.DeviceUser);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.DeviceDateTo);
            this.groupBox2.Controls.Add(this.DeviceDateFrom);
            this.groupBox2.Location = new System.Drawing.Point(7, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(808, 93);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Filters";
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Location = new System.Drawing.Point(497, 59);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(137, 27);
            this.button3.TabIndex = 9;
            this.button3.Text = "Clear";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(640, 59);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(159, 28);
            this.button2.TabIndex = 8;
            this.button2.Text = "Apply";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // DeviceUser
            // 
            this.DeviceUser.FormattingEnabled = true;
            this.DeviceUser.Location = new System.Drawing.Point(83, 43);
            this.DeviceUser.Name = "DeviceUser";
            this.DeviceUser.Size = new System.Drawing.Size(352, 24);
            this.DeviceUser.TabIndex = 6;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(16, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 17);
            this.label8.TabIndex = 4;
            this.label8.Text = "Fro user";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(259, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 17);
            this.label9.TabIndex = 3;
            this.label9.Text = "to";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(7, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(70, 17);
            this.label10.TabIndex = 2;
            this.label10.Text = "Date from";
            // 
            // DeviceDateTo
            // 
            this.DeviceDateTo.Location = new System.Drawing.Point(285, 17);
            this.DeviceDateTo.Name = "DeviceDateTo";
            this.DeviceDateTo.Size = new System.Drawing.Size(170, 22);
            this.DeviceDateTo.TabIndex = 1;
            // 
            // DeviceDateFrom
            // 
            this.DeviceDateFrom.Location = new System.Drawing.Point(83, 17);
            this.DeviceDateFrom.Name = "DeviceDateFrom";
            this.DeviceDateFrom.Size = new System.Drawing.Size(168, 22);
            this.DeviceDateFrom.TabIndex = 0;
            // 
            // tabUrl
            // 
            this.tabUrl.Controls.Add(this.dataWebLogs);
            this.tabUrl.Controls.Add(this.label7);
            this.tabUrl.Controls.Add(this.groupBox3);
            this.tabUrl.Location = new System.Drawing.Point(4, 25);
            this.tabUrl.Name = "tabUrl";
            this.tabUrl.Size = new System.Drawing.Size(1154, 543);
            this.tabUrl.TabIndex = 2;
            this.tabUrl.Text = "Url\'s";
            this.tabUrl.UseVisualStyleBackColor = true;
            // 
            // dataWebLogs
            // 
            this.dataWebLogs.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataWebLogs.Location = new System.Drawing.Point(7, 124);
            this.dataWebLogs.Name = "dataWebLogs";
            this.dataWebLogs.RowHeadersWidth = 51;
            this.dataWebLogs.RowTemplate.Height = 24;
            this.dataWebLogs.Size = new System.Drawing.Size(1141, 411);
            this.dataWebLogs.TabIndex = 5;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(7, 104);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(69, 17);
            this.label7.TabIndex = 4;
            this.label7.Text = "Url Logs";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.WebUrl);
            this.groupBox3.Controls.Add(this.WebUser);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.WebDateTo);
            this.groupBox3.Controls.Add(this.WebDateFrom);
            this.groupBox3.Location = new System.Drawing.Point(7, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(808, 93);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Filters";
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Location = new System.Drawing.Point(497, 59);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(137, 28);
            this.button5.TabIndex = 10;
            this.button5.Text = "Clear";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button6.Location = new System.Drawing.Point(640, 59);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(159, 28);
            this.button6.TabIndex = 8;
            this.button6.Text = "Apply";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // WebUrl
            // 
            this.WebUrl.FormattingEnabled = true;
            this.WebUrl.Location = new System.Drawing.Point(521, 15);
            this.WebUrl.Name = "WebUrl";
            this.WebUrl.Size = new System.Drawing.Size(278, 24);
            this.WebUrl.TabIndex = 7;
            // 
            // WebUser
            // 
            this.WebUser.FormattingEnabled = true;
            this.WebUser.Location = new System.Drawing.Point(83, 43);
            this.WebUser.Name = "WebUser";
            this.WebUser.Size = new System.Drawing.Size(352, 24);
            this.WebUser.TabIndex = 6;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(464, 22);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(51, 17);
            this.label11.TabIndex = 5;
            this.label11.Text = "For Url";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(16, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(61, 17);
            this.label12.TabIndex = 4;
            this.label12.Text = "Fro user";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(259, 22);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(20, 17);
            this.label13.TabIndex = 3;
            this.label13.Text = "to";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(7, 22);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(70, 17);
            this.label14.TabIndex = 2;
            this.label14.Text = "Date from";
            // 
            // WebDateTo
            // 
            this.WebDateTo.Location = new System.Drawing.Point(285, 17);
            this.WebDateTo.Name = "WebDateTo";
            this.WebDateTo.Size = new System.Drawing.Size(170, 22);
            this.WebDateTo.TabIndex = 1;
            // 
            // WebDateFrom
            // 
            this.WebDateFrom.Location = new System.Drawing.Point(83, 17);
            this.WebDateFrom.Name = "WebDateFrom";
            this.WebDateFrom.Size = new System.Drawing.Size(168, 22);
            this.WebDateFrom.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1166, 570);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.Text = "WatcherManager";
            this.Load += new System.EventHandler(this.Form1_Load_1);
            this.tabControl1.ResumeLayout(false);
            this.tabApp.ResumeLayout(false);
            this.tabApp.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataAppLogs)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabDevice.ResumeLayout(false);
            this.tabDevice.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataDeviceLogs)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabUrl.ResumeLayout(false);
            this.tabUrl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataWebLogs)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabApp;
        private System.Windows.Forms.TabPage tabDevice;
        private System.Windows.Forms.TabPage tabUrl;
        private System.Windows.Forms.DataGridView dataAppLogs;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker AppDateTo;
        private System.Windows.Forms.DateTimePicker AppDateFrom;
        private System.Windows.Forms.ComboBox AppExe;
        private System.Windows.Forms.ComboBox AppUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.DataGridView dataDeviceLogs;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox DeviceUser;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.DateTimePicker DeviceDateTo;
        private System.Windows.Forms.DateTimePicker DeviceDateFrom;
        private System.Windows.Forms.DataGridView dataWebLogs;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.ComboBox WebUrl;
        private System.Windows.Forms.ComboBox WebUser;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.DateTimePicker WebDateTo;
        private System.Windows.Forms.DateTimePicker WebDateFrom;
    }
}

