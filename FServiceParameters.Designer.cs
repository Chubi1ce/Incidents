namespace Incidents
{
    partial class FServiceParameters
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FServiceParameters));
            lblLogin = new Label();
            tableLayoutPanel1 = new TableLayoutPanel();
            txtSite = new TextBox();
            txtPassword = new TextBox();
            lblStatus = new Label();
            lblInterval = new Label();
            lblSite = new Label();
            lblPassword = new Label();
            txtLogin = new TextBox();
            udInterval = new NumericUpDown();
            tbServiceOnOff = new ToggleButton();
            lblCurrentStatus = new Label();
            lblDialogID = new Label();
            txtDialogID = new TextBox();
            lblBotToken = new Label();
            txtBotToken = new TextBox();
            label1 = new Label();
            cbLog = new CheckBox();
            lblLog = new Label();
            lblLastCheckTime = new Label();
            txtLastCheckTime = new TextBox();
            tableLayoutPanel2 = new TableLayoutPanel();
            btnClose = new Button();
            gbUserData = new GroupBox();
            tableLayoutPanel3 = new TableLayoutPanel();
            lblEmail = new Label();
            lblUser = new Label();
            txtUser = new TextBox();
            txtEmail = new TextBox();
            notifyIcon = new NotifyIcon(components);
            tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)udInterval).BeginInit();
            tableLayoutPanel2.SuspendLayout();
            gbUserData.SuspendLayout();
            tableLayoutPanel3.SuspendLayout();
            SuspendLayout();
            // 
            // lblLogin
            // 
            lblLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblLogin.AutoSize = true;
            lblLogin.Location = new Point(3, 5);
            lblLogin.Name = "lblLogin";
            lblLogin.Size = new Size(158, 15);
            lblLogin.TabIndex = 0;
            lblLogin.Text = "Логин";
            lblLogin.Click += lblLogin_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45.83333F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 13.61111F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40.55556F));
            tableLayoutPanel1.Controls.Add(txtSite, 1, 2);
            tableLayoutPanel1.Controls.Add(txtPassword, 1, 1);
            tableLayoutPanel1.Controls.Add(lblLogin, 0, 0);
            tableLayoutPanel1.Controls.Add(lblStatus, 0, 4);
            tableLayoutPanel1.Controls.Add(lblInterval, 0, 3);
            tableLayoutPanel1.Controls.Add(lblSite, 0, 2);
            tableLayoutPanel1.Controls.Add(lblPassword, 0, 1);
            tableLayoutPanel1.Controls.Add(txtLogin, 1, 0);
            tableLayoutPanel1.Controls.Add(udInterval, 1, 3);
            tableLayoutPanel1.Controls.Add(tbServiceOnOff, 1, 4);
            tableLayoutPanel1.Controls.Add(lblCurrentStatus, 2, 4);
            tableLayoutPanel1.Controls.Add(lblDialogID, 0, 7);
            tableLayoutPanel1.Controls.Add(txtDialogID, 1, 7);
            tableLayoutPanel1.Controls.Add(lblBotToken, 0, 6);
            tableLayoutPanel1.Controls.Add(txtBotToken, 1, 6);
            tableLayoutPanel1.Controls.Add(label1, 0, 5);
            tableLayoutPanel1.Controls.Add(cbLog, 1, 5);
            tableLayoutPanel1.Controls.Add(lblLog, 2, 5);
            tableLayoutPanel1.Location = new Point(12, 12);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 8;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 14.2857141F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Size = new Size(360, 208);
            tableLayoutPanel1.TabIndex = 6;
            // 
            // txtSite
            // 
            txtSite.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtSite, 2);
            txtSite.Location = new Point(167, 55);
            txtSite.Name = "txtSite";
            txtSite.Size = new Size(190, 23);
            txtSite.TabIndex = 3;
            txtSite.Text = "im.gosuslugi.ru";
            // 
            // txtPassword
            // 
            txtPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtPassword, 2);
            txtPassword.Location = new Point(167, 29);
            txtPassword.Name = "txtPassword";
            txtPassword.PasswordChar = '*';
            txtPassword.Size = new Size(190, 23);
            txtPassword.TabIndex = 2;
            // 
            // lblStatus
            // 
            lblStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblStatus.AutoSize = true;
            lblStatus.Location = new Point(3, 109);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(158, 15);
            lblStatus.TabIndex = 4;
            lblStatus.Text = "Статус службы";
            // 
            // lblInterval
            // 
            lblInterval.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblInterval.AutoSize = true;
            lblInterval.Location = new Point(3, 83);
            lblInterval.Name = "lblInterval";
            lblInterval.Size = new Size(158, 15);
            lblInterval.TabIndex = 3;
            lblInterval.Text = "Интервал проверки (мин.)";
            // 
            // lblSite
            // 
            lblSite.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblSite.AutoSize = true;
            lblSite.Location = new Point(3, 57);
            lblSite.Name = "lblSite";
            lblSite.Size = new Size(158, 15);
            lblSite.TabIndex = 2;
            lblSite.Text = "Адрес сайта";
            // 
            // lblPassword
            // 
            lblPassword.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblPassword.AutoSize = true;
            lblPassword.Location = new Point(3, 31);
            lblPassword.Name = "lblPassword";
            lblPassword.Size = new Size(158, 15);
            lblPassword.TabIndex = 1;
            lblPassword.Text = "Пароль";
            // 
            // txtLogin
            // 
            txtLogin.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtLogin, 2);
            txtLogin.Location = new Point(167, 3);
            txtLogin.Name = "txtLogin";
            txtLogin.Size = new Size(190, 23);
            txtLogin.TabIndex = 1;
            // 
            // udInterval
            // 
            udInterval.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(udInterval, 2);
            udInterval.Increment = new decimal(new int[] { 10, 0, 0, 0 });
            udInterval.Location = new Point(167, 81);
            udInterval.Name = "udInterval";
            udInterval.Size = new Size(190, 23);
            udInterval.TabIndex = 4;
            // 
            // tbServiceOnOff
            // 
            tbServiceOnOff.Anchor = AnchorStyles.Left;
            tbServiceOnOff.AutoSize = true;
            tbServiceOnOff.Location = new Point(167, 107);
            tbServiceOnOff.MinimumSize = new Size(40, 20);
            tbServiceOnOff.Name = "tbServiceOnOff";
            tbServiceOnOff.OffBackColor = Color.Red;
            tbServiceOnOff.OffToggleColor = Color.Gainsboro;
            tbServiceOnOff.OnBackColor = Color.LimeGreen;
            tbServiceOnOff.OnToggleColor = Color.WhiteSmoke;
            tbServiceOnOff.Size = new Size(40, 20);
            tbServiceOnOff.TabIndex = 5;
            tbServiceOnOff.UseVisualStyleBackColor = true;
            tbServiceOnOff.CheckedChanged += tbServiceOnOff_CheckedChanged;
            // 
            // lblCurrentStatus
            // 
            lblCurrentStatus.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblCurrentStatus.AutoSize = true;
            lblCurrentStatus.Location = new Point(215, 109);
            lblCurrentStatus.Name = "lblCurrentStatus";
            lblCurrentStatus.Size = new Size(142, 15);
            lblCurrentStatus.TabIndex = 6;
            // 
            // lblDialogID
            // 
            lblDialogID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblDialogID.AutoSize = true;
            lblDialogID.Location = new Point(3, 187);
            lblDialogID.Name = "lblDialogID";
            lblDialogID.Size = new Size(158, 15);
            lblDialogID.TabIndex = 8;
            lblDialogID.Text = "ID диалога для сообщений";
            // 
            // txtDialogID
            // 
            txtDialogID.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtDialogID, 2);
            txtDialogID.Location = new Point(167, 185);
            txtDialogID.Name = "txtDialogID";
            txtDialogID.Size = new Size(190, 23);
            txtDialogID.TabIndex = 1;
            // 
            // lblBotToken
            // 
            lblBotToken.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblBotToken.AutoSize = true;
            lblBotToken.Location = new Point(3, 161);
            lblBotToken.Name = "lblBotToken";
            lblBotToken.Size = new Size(158, 15);
            lblBotToken.TabIndex = 7;
            lblBotToken.Text = "Token TG бота";
            // 
            // txtBotToken
            // 
            txtBotToken.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel1.SetColumnSpan(txtBotToken, 2);
            txtBotToken.Location = new Point(167, 159);
            txtBotToken.Name = "txtBotToken";
            txtBotToken.PasswordChar = '*';
            txtBotToken.Size = new Size(190, 23);
            txtBotToken.TabIndex = 1;
            // 
            // label1
            // 
            label1.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            label1.AutoSize = true;
            label1.Location = new Point(3, 135);
            label1.Name = "label1";
            label1.Size = new Size(158, 15);
            label1.TabIndex = 4;
            label1.Text = "Логирование";
            // 
            // cbLog
            // 
            cbLog.Anchor = AnchorStyles.None;
            cbLog.AutoSize = true;
            cbLog.Location = new Point(180, 136);
            cbLog.Name = "cbLog";
            cbLog.Size = new Size(15, 14);
            cbLog.TabIndex = 9;
            cbLog.UseVisualStyleBackColor = true;
            cbLog.CheckedChanged += cbLog_CheckedChanged;
            // 
            // lblLog
            // 
            lblLog.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblLog.AutoSize = true;
            lblLog.Location = new Point(215, 135);
            lblLog.Name = "lblLog";
            lblLog.Size = new Size(142, 15);
            lblLog.TabIndex = 6;
            lblLog.Text = "Не ведется";
            // 
            // lblLastCheckTime
            // 
            lblLastCheckTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblLastCheckTime.AutoSize = true;
            lblLastCheckTime.Location = new Point(3, 82);
            lblLastCheckTime.Name = "lblLastCheckTime";
            lblLastCheckTime.Size = new Size(122, 15);
            lblLastCheckTime.TabIndex = 5;
            lblLastCheckTime.Text = "Последняя проверка";
            // 
            // txtLastCheckTime
            // 
            txtLastCheckTime.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtLastCheckTime.Enabled = false;
            txtLastCheckTime.Location = new Point(131, 78);
            txtLastCheckTime.Name = "txtLastCheckTime";
            txtLastCheckTime.Size = new Size(220, 23);
            txtLastCheckTime.TabIndex = 6;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 1;
            tableLayoutPanel2.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(btnClose, 0, 0);
            tableLayoutPanel2.Location = new Point(12, 360);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new Size(360, 39);
            tableLayoutPanel2.TabIndex = 7;
            // 
            // btnClose
            // 
            btnClose.Anchor = AnchorStyles.None;
            btnClose.Location = new Point(142, 8);
            btnClose.Name = "btnClose";
            btnClose.Size = new Size(75, 23);
            btnClose.TabIndex = 7;
            btnClose.Text = "Выход";
            btnClose.UseVisualStyleBackColor = true;
            btnClose.Click += btnClose_Click;
            // 
            // gbUserData
            // 
            gbUserData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            gbUserData.Controls.Add(tableLayoutPanel3);
            gbUserData.Location = new Point(12, 226);
            gbUserData.Name = "gbUserData";
            gbUserData.Size = new Size(360, 128);
            gbUserData.TabIndex = 8;
            gbUserData.TabStop = false;
            gbUserData.Text = "Пользователь";
            // 
            // tableLayoutPanel3
            // 
            tableLayoutPanel3.ColumnCount = 2;
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 36.15819F));
            tableLayoutPanel3.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 63.84181F));
            tableLayoutPanel3.Controls.Add(lblEmail, 0, 1);
            tableLayoutPanel3.Controls.Add(lblUser, 0, 0);
            tableLayoutPanel3.Controls.Add(txtUser, 1, 0);
            tableLayoutPanel3.Controls.Add(lblLastCheckTime, 0, 2);
            tableLayoutPanel3.Controls.Add(txtEmail, 1, 1);
            tableLayoutPanel3.Controls.Add(txtLastCheckTime, 1, 2);
            tableLayoutPanel3.Dock = DockStyle.Fill;
            tableLayoutPanel3.Location = new Point(3, 19);
            tableLayoutPanel3.Name = "tableLayoutPanel3";
            tableLayoutPanel3.RowCount = 3;
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 38.52459F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 31.147541F));
            tableLayoutPanel3.RowStyles.Add(new RowStyle(SizeType.Percent, 30.32787F));
            tableLayoutPanel3.Size = new Size(354, 106);
            tableLayoutPanel3.TabIndex = 0;
            // 
            // lblEmail
            // 
            lblEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(3, 49);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(122, 15);
            lblEmail.TabIndex = 3;
            lblEmail.Text = "Эл. адрес";
            // 
            // lblUser
            // 
            lblUser.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            lblUser.AutoSize = true;
            lblUser.Location = new Point(3, 12);
            lblUser.Name = "lblUser";
            lblUser.Size = new Size(122, 15);
            lblUser.TabIndex = 1;
            lblUser.Text = "Имя";
            // 
            // txtUser
            // 
            txtUser.Dock = DockStyle.Fill;
            txtUser.Enabled = false;
            txtUser.Location = new Point(131, 3);
            txtUser.Multiline = true;
            txtUser.Name = "txtUser";
            txtUser.Size = new Size(220, 34);
            txtUser.TabIndex = 2;
            // 
            // txtEmail
            // 
            txtEmail.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            txtEmail.Enabled = false;
            txtEmail.Location = new Point(131, 45);
            txtEmail.Name = "txtEmail";
            txtEmail.Size = new Size(220, 23);
            txtEmail.TabIndex = 4;
            // 
            // notifyIcon
            // 
            notifyIcon.Icon = (Icon)resources.GetObject("notifyIcon.Icon");
            notifyIcon.Text = "Служба уведомления об ицидентах";
            notifyIcon.MouseDoubleClick += notifyIcon_MouseDoubleClick;
            // 
            // FServiceParameters
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = btnClose;
            ClientSize = new Size(384, 411);
            Controls.Add(gbUserData);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(tableLayoutPanel1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MaximumSize = new Size(400, 450);
            MinimumSize = new Size(400, 450);
            Name = "FServiceParameters";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Параметры службы";
            Load += FServiceParameters_Load;
            Resize += FServiceParameters_Resize;
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)udInterval).EndInit();
            tableLayoutPanel2.ResumeLayout(false);
            gbUserData.ResumeLayout(false);
            tableLayoutPanel3.ResumeLayout(false);
            tableLayoutPanel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblLogin;
        private TableLayoutPanel tableLayoutPanel1;
        private Label lblLastCheckTime;
        private Label lblStatus;
        private Label lblInterval;
        private Label lblSite;
        private Label lblPassword;
        private TextBox txtSite;
        private TextBox txtPassword;
        private TextBox txtLogin;
        private TextBox txtLastCheckTime;
        private NumericUpDown udInterval;
        private TableLayoutPanel tableLayoutPanel2;
        private Button btnClose;
        private GroupBox gbUserData;
        private TableLayoutPanel tableLayoutPanel3;
        private Label lblEmail;
        private Label lblUser;
        private TextBox txtUser;
        private TextBox txtEmail;
        private ToggleButton tbServiceOnOff;
        private Label lblCurrentStatus;
        private NotifyIcon notifyIcon;
        private Label lblDialogID;
        private Label lblBotToken;
        private TextBox txtBotToken;
        private TextBox txtDialogID;
        private Label label1;
        private CheckBox cbLog;
        private Label lblLog;
    }
}