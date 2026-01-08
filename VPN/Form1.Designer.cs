// File: Form1.Designer.cs
using System.Drawing;
using System.Windows.Forms;

namespace VPN
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        // Controls
        private Label titleLabel;
        private Label labelUser;
        private Label labelPass;
        private Label labelKey;
        private TextBox txtUserName;
        private TextBox TextPassword;
        private TextBox txtLicenseKey;
        private Button button1;          // Connect / Disconnect
        private Button EXIT;             // (hidden; we use the × button)
        private GradientPanel leftBrandPanel;
        private Panel rightCard;
        private CheckBox rememberCheck;
        private LinkLabel forgotLink;
        private Button showPassBtn;
        private Button btnMinimize;
        private Button btnExit;
        private Label versionLabel;
        private Button btnRegister;
        private Button btnSwitchToLogin;
        private Button btnSwitchToRegister;
        private Label registerLabel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.titleLabel = new System.Windows.Forms.Label();
            this.labelUser = new System.Windows.Forms.Label();
            this.labelPass = new System.Windows.Forms.Label();
            this.labelKey = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.TextPassword = new System.Windows.Forms.TextBox();
            this.txtLicenseKey = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.EXIT = new System.Windows.Forms.Button();
            this.leftBrandPanel = new VPN.GradientPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.rightCard = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.gatewayLabel = new System.Windows.Forms.Label();
            this.showPassBtn = new System.Windows.Forms.Button();
            this.rememberCheck = new System.Windows.Forms.CheckBox();
            this.forgotLink = new System.Windows.Forms.LinkLabel();
            this.btnRegister = new System.Windows.Forms.Button();
            this.btnSwitchToLogin = new System.Windows.Forms.Button();
            this.btnSwitchToRegister = new System.Windows.Forms.Button();
            this.registerLabel = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.versionLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.rightCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.titleLabel.ForeColor = System.Drawing.Color.White;
            this.titleLabel.Location = new System.Drawing.Point(214, 156);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(104, 45);
            this.titleLabel.TabIndex = 0;
            this.titleLabel.Text = "Login";
            // 
            // labelUser
            // 
            this.labelUser.AutoSize = true;
            this.labelUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelUser.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.labelUser.Location = new System.Drawing.Point(103, 208);
            this.labelUser.Name = "labelUser";
            this.labelUser.Size = new System.Drawing.Size(135, 19);
            this.labelUser.TabIndex = 3;
            this.labelUser.Text = "Username or Email";
            // 
            // labelPass
            // 
            this.labelPass.AutoSize = true;
            this.labelPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelPass.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.labelPass.Location = new System.Drawing.Point(103, 269);
            this.labelPass.Name = "labelPass";
            this.labelPass.Size = new System.Drawing.Size(73, 19);
            this.labelPass.TabIndex = 5;
            this.labelPass.Text = "Password";
            // 
            // labelKey
            // 
            this.labelKey.AutoSize = true;
            this.labelKey.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.labelKey.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.labelKey.Location = new System.Drawing.Point(103, 321);
            this.labelKey.Name = "labelKey";
            this.labelKey.Size = new System.Drawing.Size(86, 19);
            this.labelKey.TabIndex = 11;
            this.labelKey.Text = "License Key";
            // 
            // txtUserName
            // 
            this.txtUserName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.txtUserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtUserName.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserName.ForeColor = System.Drawing.Color.White;
            this.txtUserName.Location = new System.Drawing.Point(103, 230);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(309, 27);
            this.txtUserName.TabIndex = 4;
            // 
            // TextPassword
            // 
            this.TextPassword.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.TextPassword.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.TextPassword.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.TextPassword.ForeColor = System.Drawing.Color.White;
            this.TextPassword.Location = new System.Drawing.Point(103, 290);
            this.TextPassword.Name = "TextPassword";
            this.TextPassword.Size = new System.Drawing.Size(275, 27);
            this.TextPassword.TabIndex = 6;
            this.TextPassword.UseSystemPasswordChar = true;
            // 
            // txtLicenseKey
            // 
            this.txtLicenseKey.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(25)))), ((int)(((byte)(35)))), ((int)(((byte)(60)))));
            this.txtLicenseKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtLicenseKey.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtLicenseKey.ForeColor = System.Drawing.Color.White;
            this.txtLicenseKey.Location = new System.Drawing.Point(103, 342);
            this.txtLicenseKey.Name = "txtLicenseKey";
            this.txtLicenseKey.Size = new System.Drawing.Size(309, 27);
            this.txtLicenseKey.TabIndex = 12;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.button1.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(103, 364);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(309, 43);
            this.button1.TabIndex = 13;
            this.button1.Text = "Login";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // EXIT
            // 
            this.EXIT.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(25)))), ((int)(((byte)(48)))));
            this.EXIT.FlatAppearance.BorderSize = 0;
            this.EXIT.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.EXIT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(210)))), ((int)(((byte)(235)))));
            this.EXIT.Location = new System.Drawing.Point(770, 24);
            this.EXIT.Name = "EXIT";
            this.EXIT.Size = new System.Drawing.Size(80, 30);
            this.EXIT.TabIndex = 0;
            this.EXIT.Text = "Exit";
            this.EXIT.UseVisualStyleBackColor = false;
            this.EXIT.Visible = false;
            // 
            // leftBrandPanel
            // 
            this.leftBrandPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBrandPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.leftBrandPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.leftBrandPanel.Location = new System.Drawing.Point(0, 0);
            this.leftBrandPanel.Name = "leftBrandPanel";
            this.leftBrandPanel.Size = new System.Drawing.Size(0, 477);
            this.leftBrandPanel.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.label3.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.label3.Location = new System.Drawing.Point(12, 246);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(182, 17);
            this.label3.TabIndex = 6;
            this.label3.Text = " pros and everyday browsing.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.label2.Location = new System.Drawing.Point(12, 219);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(342, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "MAXGG VPN keeps you private and fast built for gamers,";
            // 
            // rightCard
            // 
            this.rightCard.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.rightCard.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.rightCard.Controls.Add(this.pictureBox1);
            this.rightCard.Controls.Add(this.label1);
            this.rightCard.Controls.Add(this.titleLabel);
            this.rightCard.Controls.Add(this.gatewayLabel);
            this.rightCard.Controls.Add(this.labelUser);
            this.rightCard.Controls.Add(this.txtUserName);
            this.rightCard.Controls.Add(this.labelPass);
            this.rightCard.Controls.Add(this.TextPassword);
            this.rightCard.Controls.Add(this.showPassBtn);
            this.rightCard.Controls.Add(this.labelKey);
            this.rightCard.Controls.Add(this.txtLicenseKey);
            this.rightCard.Controls.Add(this.rememberCheck);
            this.rightCard.Controls.Add(this.forgotLink);
            this.rightCard.Controls.Add(this.button1);
            this.rightCard.Controls.Add(this.btnRegister);
            this.rightCard.Controls.Add(this.btnSwitchToLogin);
            this.rightCard.Controls.Add(this.btnSwitchToRegister);
            this.rightCard.Controls.Add(this.registerLabel);
            this.rightCard.Location = new System.Drawing.Point(0, 0);
            this.rightCard.Name = "rightCard";
            this.rightCard.Padding = new System.Windows.Forms.Padding(19, 19, 19, 19);
            this.rightCard.Size = new System.Drawing.Size(514, 477);
            this.rightCard.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.label1.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(157, 121);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(242, 32);
            this.label1.TabIndex = 1;
            this.label1.Text = "Welcome to MK VPN";
            // 
            // gatewayLabel
            // 
            this.gatewayLabel.Location = new System.Drawing.Point(34, 19);
            this.gatewayLabel.Name = "gatewayLabel";
            this.gatewayLabel.Size = new System.Drawing.Size(86, 20);
            this.gatewayLabel.TabIndex = 1;
            // 
            // showPassBtn
            // 
            this.showPassBtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(30)))), ((int)(((byte)(58)))));
            this.showPassBtn.FlatAppearance.BorderSize = 0;
            this.showPassBtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.showPassBtn.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.showPassBtn.ForeColor = System.Drawing.Color.White;
            this.showPassBtn.Location = new System.Drawing.Point(381, 288);
            this.showPassBtn.Name = "showPassBtn";
            this.showPassBtn.Size = new System.Drawing.Size(31, 24);
            this.showPassBtn.TabIndex = 7;
            this.showPassBtn.Text = "👁";
            this.showPassBtn.UseVisualStyleBackColor = false;
            // 
            // rememberCheck
            // 
            this.rememberCheck.AutoSize = true;
            this.rememberCheck.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(200)))), ((int)(((byte)(230)))));
            this.rememberCheck.Location = new System.Drawing.Point(103, 334);
            this.rememberCheck.Name = "rememberCheck";
            this.rememberCheck.Size = new System.Drawing.Size(94, 17);
            this.rememberCheck.TabIndex = 8;
            this.rememberCheck.Text = "Remember me";
            // 
            // forgotLink
            // 
            this.forgotLink.ActiveLinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(190)))), ((int)(((byte)(255)))));
            this.forgotLink.AutoSize = true;
            this.forgotLink.LinkColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.forgotLink.Location = new System.Drawing.Point(326, 334);
            this.forgotLink.Name = "forgotLink";
            this.forgotLink.Size = new System.Drawing.Size(91, 13);
            this.forgotLink.TabIndex = 9;
            this.forgotLink.TabStop = true;
            this.forgotLink.Text = "Forgot password?";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(44)))), ((int)(((byte)(123)))), ((int)(((byte)(255)))));
            this.btnRegister.FlatAppearance.BorderSize = 0;
            this.btnRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(103)))), ((int)(((byte)(235)))));
            this.btnRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(143)))), ((int)(((byte)(255)))));
            this.btnRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegister.Font = new System.Drawing.Font("Segoe UI", 13F, System.Drawing.FontStyle.Bold);
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(103, 377);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(309, 43);
            this.btnRegister.TabIndex = 14;
            this.btnRegister.Text = "Register";
            this.btnRegister.UseVisualStyleBackColor = false;
            this.btnRegister.Visible = false;
            // 
            // btnSwitchToLogin
            // 
            this.btnSwitchToLogin.BackColor = System.Drawing.Color.Transparent;
            this.btnSwitchToLogin.FlatAppearance.BorderSize = 0;
            this.btnSwitchToLogin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnSwitchToLogin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.btnSwitchToLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchToLogin.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSwitchToLogin.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.btnSwitchToLogin.Location = new System.Drawing.Point(103, 425);
            this.btnSwitchToLogin.Name = "btnSwitchToLogin";
            this.btnSwitchToLogin.Size = new System.Drawing.Size(103, 26);
            this.btnSwitchToLogin.TabIndex = 15;
            this.btnSwitchToLogin.Text = "Login";
            this.btnSwitchToLogin.UseVisualStyleBackColor = false;
            this.btnSwitchToLogin.Visible = false;
            // 
            // btnSwitchToRegister
            // 
            this.btnSwitchToRegister.BackColor = System.Drawing.Color.Transparent;
            this.btnSwitchToRegister.FlatAppearance.BorderSize = 0;
            this.btnSwitchToRegister.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(50)))));
            this.btnSwitchToRegister.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(70)))));
            this.btnSwitchToRegister.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSwitchToRegister.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnSwitchToRegister.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(170)))), ((int)(((byte)(255)))));
            this.btnSwitchToRegister.Location = new System.Drawing.Point(103, 407);
            this.btnSwitchToRegister.Name = "btnSwitchToRegister";
            this.btnSwitchToRegister.Size = new System.Drawing.Size(103, 26);
            this.btnSwitchToRegister.TabIndex = 16;
            this.btnSwitchToRegister.Text = "Register";
            this.btnSwitchToRegister.UseVisualStyleBackColor = false;
            // 
            // registerLabel
            // 
            this.registerLabel.AutoSize = true;
            this.registerLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.registerLabel.ForeColor = System.Drawing.Color.White;
            this.registerLabel.Location = new System.Drawing.Point(214, 156);
            this.registerLabel.Name = "registerLabel";
            this.registerLabel.Size = new System.Drawing.Size(102, 32);
            this.registerLabel.TabIndex = 17;
            this.registerLabel.Text = "Register";
            this.registerLabel.Visible = false;
            // 
            // btnMinimize
            // 
            this.btnMinimize.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.btnMinimize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnMinimize.FlatAppearance.BorderSize = 0;
            this.btnMinimize.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(18)))), ((int)(((byte)(26)))), ((int)(((byte)(48)))));
            this.btnMinimize.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.btnMinimize.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMinimize.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnMinimize.ForeColor = System.Drawing.Color.White;
            this.btnMinimize.Location = new System.Drawing.Point(454, 4);
            this.btnMinimize.Name = "btnMinimize";
            this.btnMinimize.Size = new System.Drawing.Size(26, 22);
            this.btnMinimize.TabIndex = 21;
            this.btnMinimize.Text = "−";
            this.btnMinimize.UseVisualStyleBackColor = false;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.Location = new System.Drawing.Point(484, 4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(26, 22);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // versionLabel
            // 
            this.versionLabel.AutoSize = true;
            this.versionLabel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.versionLabel.Font = new System.Drawing.Font("Segoe UI", 8F);
            this.versionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(120)))), ((int)(((byte)(130)))), ((int)(((byte)(150)))));
            this.versionLabel.Location = new System.Drawing.Point(446, 451);
            this.versionLabel.Name = "versionLabel";
            this.versionLabel.Size = new System.Drawing.Size(63, 13);
            this.versionLabel.TabIndex = 23;
            this.versionLabel.Text = "Version 2.0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.pictureBox1.BackgroundImage = global::VPN.Properties.Resources.Logo;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(206, 17);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(112, 101);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(514, 477);
            this.Controls.Add(this.versionLabel);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.leftBrandPanel);
            this.Controls.Add(this.rightCard);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAXGG VPN";
            this.rightCard.ResumeLayout(false);
            this.rightCard.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }
        #endregion

        // Painter helpers (designer-safe)
        private void RightCard_Paint(object sender, PaintEventArgs e)
        {
           var pen = new Pen(Color.FromArgb(40, 80, 140), 1);
            e.Graphics.DrawRectangle(pen, new Rectangle(0, 0, rightCard.Width - 1, rightCard.Height - 1));
        }

        //private void StatusDot_Paint(object? sender, PaintEventArgs e)
        //{
        //    e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        //    using var brush = new SolidBrush(statusDot.BackColor);
        //    e.Graphics.FillEllipse(brush, 0, 0, statusDot.Width - 1, statusDot.Height - 1);
        //}

        private Label gatewayLabel;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label2;
        private Label label1;
    }
}
