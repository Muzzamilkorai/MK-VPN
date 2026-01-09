using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN
{
    public partial class LoadingForm : Form
    {
        private System.Windows.Forms.Timer animationTimer;
        private int animationStep = 0;
        private Label welcomeLabel;
        private Label loadingLabel;
        private Panel loadingPanel;
        private int dotCount = 0;

        public LoadingForm()
        {
            InitializeComponent();
            SetupLoadingAnimation();

            this.Load += LoadingForm_Load_RoundCorners;
        }

        private void LoadingForm_Load_RoundCorners(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
        }

        private void InitializeComponent()
        {
            this.welcomeLabel = new System.Windows.Forms.Label();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // welcomeLabel
            // 
            this.welcomeLabel.BackColor = System.Drawing.Color.Transparent;
            this.welcomeLabel.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold);
            this.welcomeLabel.ForeColor = System.Drawing.Color.White;
            this.welcomeLabel.Location = new System.Drawing.Point(0, 78);
            this.welcomeLabel.Name = "welcomeLabel";
            this.welcomeLabel.Size = new System.Drawing.Size(429, 43);
            this.welcomeLabel.TabIndex = 0;
            this.welcomeLabel.Text = "Welcome to MK VPN!";
            this.welcomeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingLabel
            // 
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.loadingLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.loadingLabel.Location = new System.Drawing.Point(0, 147);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(429, 22);
            this.loadingLabel.TabIndex = 1;
            this.loadingLabel.Text = "Loading";
            this.loadingLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loadingPanel
            // 
            this.loadingPanel.BackColor = System.Drawing.Color.Transparent;
            this.loadingPanel.Location = new System.Drawing.Point(171, 182);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(86, 35);
            this.loadingPanel.TabIndex = 2;
            // 
            // LoadingForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(18)))), ((int)(((byte)(34)))));
            this.ClientSize = new System.Drawing.Size(429, 260);
            this.Controls.Add(this.welcomeLabel);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.loadingPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "LoadingForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Loading";
            this.TopMost = true;
            this.ResumeLayout(false);

        }

        private void SetupLoadingAnimation()
        {
            animationTimer = new System.Windows.Forms.Timer();
            animationTimer.Interval = 200;
            animationTimer.Tick += AnimationTimer_Tick;
            animationTimer.Start();
        }

        private void AnimationTimer_Tick(object sender, EventArgs e)
        {
            animationStep++;
            dotCount = (animationStep % 4);

            string dots = new string('.', dotCount);
            loadingLabel.Text = "Loading" + dots;

            loadingPanel.Invalidate();
        }

        private void LoadingPanel_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            int centerX = loadingPanel.Width / 2;
            int centerY = loadingPanel.Height / 2;
            int radius = 8;

            for (int i = 0; i < 8; i++)
            {
                double angle = (i * Math.PI / 4) + (animationStep * Math.PI / 16);
                int x = centerX + (int)(Math.Cos(angle) * radius);
                int y = centerY + (int)(Math.Sin(angle) * radius);

                int alpha = 255 - (i * 30);
                if (alpha < 50) alpha = 50;

                using (SolidBrush brush = new SolidBrush(Color.FromArgb(alpha, 44, 123, 255)))
                {
                    g.FillEllipse(brush, x - 2, y - 2, 4, 4);
                }
            }
        }

        public async Task ShowLoadingAsync(int durationMs = 3000)
        {
            this.Show();
            await Task.Delay(durationMs);
            this.Close();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (animationTimer != null)
                {
                    animationTimer.Stop();
                    animationTimer.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }
    }
}
