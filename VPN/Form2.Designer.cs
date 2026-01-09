using System.Drawing;
using System.Windows.Forms;

namespace VPN
{
    partial class Form2
    {
        private System.ComponentModel.IContainer components = null;

        // New
        private System.Windows.Forms.Timer slideTimer;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            pictureBox1 = new PictureBox();
            leftBrandPanel = new GradientPanel();
            button5 = new Button();
            label2 = new Label();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panelMain = new Panel();
            gatewayLabel = new Label();
            btnMinimize = new Button();
            btnExit = new Button();
            btnMenu = new Button();
            slideTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            leftBrandPanel.SuspendLayout();
            panelMain.SuspendLayout();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.FromArgb(24, 34, 64);
         //   pictureBox1.BackgroundImage = Properties.Resources.IMG_34631;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(64, 26);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(95, 81);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // leftBrandPanel
            // 
            leftBrandPanel.Controls.Add(button5);
            leftBrandPanel.Controls.Add(label2);
            leftBrandPanel.Controls.Add(button4);
            leftBrandPanel.Controls.Add(button3);
            leftBrandPanel.Controls.Add(button2);
            leftBrandPanel.Controls.Add(button1);
            leftBrandPanel.Controls.Add(pictureBox1);
            leftBrandPanel.Dock = DockStyle.Left;
            leftBrandPanel.GradientBottomRight = Color.FromArgb(14, 22, 40);
            leftBrandPanel.GradientTopLeft = Color.FromArgb(24, 34, 64);
            leftBrandPanel.Location = new Point(0, 0);
            leftBrandPanel.Name = "leftBrandPanel";
            leftBrandPanel.Size = new Size(0, 457);
            leftBrandPanel.TabIndex = 15;
            // 
            // button5
            // 
            button5.BackColor = Color.FromArgb(24, 34, 64);
            button5.Cursor = Cursors.Hand;
            button5.FlatAppearance.BorderSize = 0;
            button5.FlatStyle = FlatStyle.Flat;
            button5.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button5.ForeColor = Color.White;
         //   button5.Image = Properties.Resources.;
            button5.Location = new Point(1, 369);
            button5.Name = "button5";
            button5.Size = new Size(235, 40);
            button5.TabIndex = 20;
            button5.Text = "   Exit";
            button5.TextImageRelation = TextImageRelation.ImageBeforeText;
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.FromArgb(24, 34, 64);
            label2.Font = new Font("Segoe UI Semibold", 18F, FontStyle.Bold);
            label2.ForeColor = Color.White;
            label2.Location = new Point(35, 125);
            label2.Name = "label2";
            label2.Size = new Size(155, 32);
            label2.TabIndex = 20;
            label2.Text = "MAXGG VPN";
            // 
            // button4
            // 
            button4.BackColor = Color.FromArgb(24, 34, 64);
            button4.Cursor = Cursors.Hand;
            button4.FlatAppearance.BorderSize = 0;
            button4.FlatStyle = FlatStyle.Flat;
            button4.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button4.ForeColor = Color.White;
           // button4.Image = Properties.Resources.settings;
            button4.Location = new Point(0, 319);
            button4.Name = "button4";
            button4.Size = new Size(235, 40);
            button4.TabIndex = 19;
            button4.Text = "    Settings";
            button4.TextImageRelation = TextImageRelation.ImageBeforeText;
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.BackColor = Color.FromArgb(24, 34, 64);
            button3.Cursor = Cursors.Hand;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button3.ForeColor = Color.White;
          //  button3.Image = Properties.Resources.box;
            button3.Location = new Point(1, 269);
            button3.Name = "button3";
            button3.Size = new Size(235, 40);
            button3.TabIndex = 18;
            button3.Text = "    Products";
            button3.TextImageRelation = TextImageRelation.ImageBeforeText;
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.FromArgb(24, 34, 64);
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button2.ForeColor = Color.White;
          //  button2.Image = Properties.Resources.vpn__1_;
            button2.Location = new Point(1, 219);
            button2.Name = "button2";
            button2.Size = new Size(235, 40);
            button2.TabIndex = 17;
            button2.Text = "    VPN Hub";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.FromArgb(24, 34, 64);
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Segoe UI Semibold", 11F, FontStyle.Bold);
            button1.ForeColor = Color.White;
         //   button1.Image = Properties.Resources.dashboard;
            button1.Location = new Point(0, 169);
            button1.Name = "button1";
            button1.Size = new Size(235, 40);
            button1.TabIndex = 16;
            button1.Text = "     Dashboard";
            button1.TextImageRelation = TextImageRelation.ImageBeforeText;
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // panelMain
            // 
            panelMain.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            panelMain.BackColor = Color.FromArgb(255, 128, 0);
            panelMain.Controls.Add(gatewayLabel);
            panelMain.Location = new Point(5, 30);
            panelMain.Name = "panelMain";
            panelMain.Padding = new Padding(22);
            panelMain.Size = new Size(815, 424);
            panelMain.TabIndex = 16;
            panelMain.Paint += rightCard_Paint;
            // 
            // gatewayLabel
            // 
            gatewayLabel.Location = new Point(0, 0);
            gatewayLabel.Name = "gatewayLabel";
            gatewayLabel.Size = new Size(100, 23);
            gatewayLabel.TabIndex = 1;
            // 
            // btnMinimize
            // 
            btnMinimize.BackColor = Color.FromArgb(12, 18, 34);
            btnMinimize.Cursor = Cursors.Hand;
            btnMinimize.FlatAppearance.BorderSize = 0;
            btnMinimize.FlatAppearance.MouseDownBackColor = Color.FromArgb(18, 26, 48);
            btnMinimize.FlatAppearance.MouseOverBackColor = Color.FromArgb(24, 34, 64);
            btnMinimize.FlatStyle = FlatStyle.Flat;
            btnMinimize.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnMinimize.ForeColor = Color.White;
            btnMinimize.Location = new Point(750, -5);
            btnMinimize.Name = "btnMinimize";
            btnMinimize.Size = new Size(30, 25);
            btnMinimize.TabIndex = 21;
            btnMinimize.Text = "−";
            btnMinimize.UseVisualStyleBackColor = false;
            btnMinimize.Click += btnMinimize_Click;
            // 
            // btnExit
            // 
            btnExit.BackColor = Color.FromArgb(12, 18, 34);
            btnExit.Cursor = Cursors.Hand;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatAppearance.MouseDownBackColor = Color.FromArgb(64, 0, 0);
            btnExit.FlatAppearance.MouseOverBackColor = Color.FromArgb(48, 0, 0);
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnExit.ForeColor = Color.White;
            btnExit.Location = new Point(785, -5);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(30, 25);
            btnExit.TabIndex = 22;
            btnExit.Text = "×";
            btnExit.UseVisualStyleBackColor = false;
            btnExit.Click += btnExit_Click;
            // 
            // btnMenu
            // 
            btnMenu.BackColor = Color.FromArgb(12, 18, 34);
            btnMenu.Cursor = Cursors.Hand;
            btnMenu.FlatAppearance.BorderSize = 0;
            btnMenu.FlatStyle = FlatStyle.Flat;
            btnMenu.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            btnMenu.ForeColor = Color.White;
            btnMenu.Location = new Point(5, 5);
            btnMenu.Name = "btnMenu";
            btnMenu.Size = new Size(40, 35);
            btnMenu.TabIndex = 23;
            btnMenu.Text = "☰";
            btnMenu.UseVisualStyleBackColor = false;
            btnMenu.Click += btnMenu_Click;
            // 
            // slideTimer
            // 
            slideTimer.Interval = 15;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 18, 34);
            ClientSize = new Size(820, 457);
            Controls.Add(btnMenu);
            Controls.Add(btnExit);
            Controls.Add(btnMinimize);
            Controls.Add(panelMain);
            Controls.Add(leftBrandPanel);
            FormBorderStyle = FormBorderStyle.None;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Name = "Form2";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MAX VPN HUB 1.0";
            Load += Form2_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            leftBrandPanel.ResumeLayout(false);
            leftBrandPanel.PerformLayout();
            panelMain.ResumeLayout(false);
            ResumeLayout(false);
        }
        #endregion

        private PictureBox pictureBox1;
        private GradientPanel leftBrandPanel;
        private Button button1;
        private Button button3;
        private Button button2;
        private Button button4;
        private Label label2;
        private Button button5;
        private Panel panelMain;
        private Label gatewayLabel;
        private Button btnMinimize;
        private Button btnExit;
        private Button btnMenu; // new
    }
}
