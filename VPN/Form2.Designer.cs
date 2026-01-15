using System.Drawing;
using System.Windows.Forms;

namespace VPN
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.panelMain = new System.Windows.Forms.Panel();
            this.gatewayLabel = new System.Windows.Forms.Label();
            this.btnMinimize = new System.Windows.Forms.Button();
            this.btnExit = new System.Windows.Forms.Button();
            this.leftBrandPanel = new VPN.GradientPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panelMain.SuspendLayout();
            this.leftBrandPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panelMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.panelMain.Controls.Add(this.gatewayLabel);
            this.panelMain.Location = new System.Drawing.Point(207, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Padding = new System.Windows.Forms.Padding(19);
            this.panelMain.Size = new System.Drawing.Size(492, 367);
            this.panelMain.TabIndex = 16;
            // 
            // gatewayLabel
            // 
            this.gatewayLabel.Location = new System.Drawing.Point(0, 0);
            this.gatewayLabel.Name = "gatewayLabel";
            this.gatewayLabel.Size = new System.Drawing.Size(86, 20);
            this.gatewayLabel.TabIndex = 1;
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
            this.btnMinimize.Location = new System.Drawing.Point(643, -4);
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
            this.btnExit.Location = new System.Drawing.Point(673, -4);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(26, 22);
            this.btnExit.TabIndex = 22;
            this.btnExit.Text = "×";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // leftBrandPanel
            // 
            this.leftBrandPanel.Controls.Add(this.button5);
            this.leftBrandPanel.Controls.Add(this.label2);
            this.leftBrandPanel.Controls.Add(this.button4);
            this.leftBrandPanel.Controls.Add(this.button2);
            this.leftBrandPanel.Controls.Add(this.button1);
            this.leftBrandPanel.Controls.Add(this.pictureBox1);
            this.leftBrandPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.leftBrandPanel.GradientBottomRight = System.Drawing.Color.FromArgb(((int)(((byte)(14)))), ((int)(((byte)(22)))), ((int)(((byte)(40)))));
            this.leftBrandPanel.GradientTopLeft = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.leftBrandPanel.Location = new System.Drawing.Point(0, 0);
            this.leftBrandPanel.Name = "leftBrandPanel";
            this.leftBrandPanel.Size = new System.Drawing.Size(207, 370);
            this.leftBrandPanel.TabIndex = 15;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 18F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(30, 108);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(155, 32);
            this.label2.TabIndex = 20;
            this.label2.Text = "MAXGG VPN";
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.button5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button5.FlatAppearance.BorderSize = 0;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button5.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button5.ForeColor = System.Drawing.Color.White;
            this.button5.Image = global::VPN.Properties.Resources.logout;
            this.button5.Location = new System.Drawing.Point(1, 275);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(201, 35);
            this.button5.TabIndex = 20;
            this.button5.Text = "   Exit";
            this.button5.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button5.UseVisualStyleBackColor = false;
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.button4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button4.FlatAppearance.BorderSize = 0;
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button4.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.Color.White;
            this.button4.Image = global::VPN.Properties.Resources.settings;
            this.button4.Location = new System.Drawing.Point(0, 232);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(201, 35);
            this.button4.TabIndex = 19;
            this.button4.Text = "    Settings";
            this.button4.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button4.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Image = global::VPN.Properties.Resources.vpn__1_;
            this.button2.Location = new System.Drawing.Point(1, 190);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(201, 35);
            this.button2.TabIndex = 17;
            this.button2.Text = "    VPN";
            this.button2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Segoe UI Semibold", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Image = global::VPN.Properties.Resources.dashboard;
            this.button1.Location = new System.Drawing.Point(0, 146);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(201, 35);
            this.button1.TabIndex = 16;
            this.button1.Text = "     Dashboard";
            this.button1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(34)))), ((int)(((byte)(64)))));
            this.pictureBox1.BackgroundImage = global::VPN.Properties.Resources.MK_VPN_transparent;
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox1.Location = new System.Drawing.Point(55, 23);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(81, 70);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(703, 370);
            this.Controls.Add(this.btnExit);
            this.Controls.Add(this.btnMinimize);
            this.Controls.Add(this.panelMain);
            this.Controls.Add(this.leftBrandPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "MAX VPN HUB 1.0";
            this.panelMain.ResumeLayout(false);
            this.leftBrandPanel.ResumeLayout(false);
            this.leftBrandPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        private PictureBox pictureBox1;
        private GradientPanel leftBrandPanel;
        private Button button1;
        private Button button2;
        private Button button4;
        private Label label2;
        private Button button5;
        private Panel panelMain;
        private Label gatewayLabel;
        private Button btnMinimize;
        private Button btnExit;
    }
}
