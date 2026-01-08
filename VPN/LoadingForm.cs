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
            welcomeLabel = new Label();
            loadingLabel = new Label();
            loadingPanel = new Panel();
            SuspendLayout();

            welcomeLabel.BackColor = Color.Transparent;
            welcomeLabel.Font = new Font("Segoe UI", 24F, FontStyle.Bold);
            welcomeLabel.ForeColor = Color.White;
            welcomeLabel.Location = new Point(0, 90);
            welcomeLabel.Name = "welcomeLabel";
            welcomeLabel.Size = new Size(500, 50);
            welcomeLabel.TabIndex = 0;
            welcomeLabel.Text = "Welcome to MAXGG VPN!";
            welcomeLabel.TextAlign = ContentAlignment.MiddleCenter;

            loadingLabel.BackColor = Color.Transparent;
            loadingLabel.Font = new Font("Segoe UI", 12F);
            loadingLabel.ForeColor = Color.FromArgb(200, 200, 200);
            loadingLabel.Location = new Point(0, 170);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new Size(500, 25);
            loadingLabel.TabIndex = 1;
            loadingLabel.Text = "Loading";
            loadingLabel.TextAlign = ContentAlignment.MiddleCenter;

            loadingPanel.BackColor = Color.Transparent;
            loadingPanel.Location = new Point(200, 210);
            loadingPanel.Name = "loadingPanel";
            loadingPanel.Size = new Size(100, 40);
            loadingPanel.TabIndex = 2;
            loadingPanel.Paint += LoadingPanel_Paint;

            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(12, 18, 34);
            ClientSize = new Size(500, 300);
            Controls.Add(welcomeLabel);
            Controls.Add(loadingLabel);
            Controls.Add(loadingPanel);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LoadingForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Loading";
            TopMost = true;
            Load += LoadingForm_Load;
            ResumeLayout(false);
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
