
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VPN
{
    public partial class Form2 : Form
    {

        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;


        //--------------------------------------------------------
        // --- Sliding nav config ---
        private const int NavMaxWidth = 235;     // fully-open width
        private const int AnimDurationMs = 260;  // total duration per open/close
        private System.Windows.Forms.Timer animTimer;
        private bool navOpen = false;

        // animation state
        private DateTime animStart;
        private int fromWidth, toWidth;

        // optional overlay (tap to close)
        private Panel overlayPanel;


        //--------------------------------------------------------
        public Form2()
        {
            InitializeComponent();
            
            EnableDragging(this);
            EnableDragging(leftBrandPanel);
            EnableDragging(panelMain);
            //==============================================================
            // Smooth visuals
            EnableDoubleBuffer(this);
            EnableDoubleBuffer(leftBrandPanel);
            EnableDoubleBuffer(panelMain);

            // Optional: dim overlay when nav is open
            overlayPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(110, 0, 0, 0),
                Visible = false
            };
            overlayPanel.Click += (s, e) => StartSlide(false);
            panelMain.Controls.Add(overlayPanel);
            overlayPanel.BringToFront();

            // Animation timer (~60fps)
            animTimer = new System.Windows.Forms.Timer { Interval = 15 };
            animTimer.Tick += AnimTimer_Tick;

            // Ensure starting positions
            leftBrandPanel.Width = 0;
            panelMain.Left = 0;

            // Hook your menu button
            btnMenu.Click += (s, e) => StartSlide(!navOpen);


            //==============================================================
            this.Load += Form2_Load_RoundCorners;
        }
        // Animation variables
        private bool isCollapsed = true;
        private const int SlideSpeed = 15;
        private const int MaxWidth = 235; // full nav width

        private void btnMenu_Click(object sender, EventArgs e)
        {
            slideTimer.Start();
        }

        private void StartSlide(bool open)
        {
            navOpen = open;
            overlayPanel.Visible = open; // show overlay immediately on open

            fromWidth = leftBrandPanel.Width;
            toWidth = open ? NavMaxWidth : 0;

            animStart = DateTime.Now;
            animTimer.Start();
        }

        private void AnimTimer_Tick(object sender, EventArgs e)
        {
            // progress 0..1 using elapsed time
            double t = (DateTime.Now - animStart).TotalMilliseconds / AnimDurationMs;
            if (t >= 1.0) t = 1.0;

            // ease-out cubic for smooth finish
            double eased = 1 - Math.Pow(1 - t, 3);

            int w = (int)Math.Round(Lerp(fromWidth, toWidth, eased));

            // Apply to both sidebar and content (push layout like mobile)
            leftBrandPanel.Width = w;
            panelMain.Left = w;

            if (t >= 1.0)
            {
                animTimer.Stop();
                if (w == 0) overlayPanel.Visible = false; // hide overlay when closed
            }
        }

        private static double Lerp(double a, double b, double t) => a + (b - a) * t;

        // Turns on true double-buffering (reduces flicker)
        private static void EnableDoubleBuffer(Control c)
        {
            c.GetType().GetProperty("DoubleBuffered",
                System.Reflection.BindingFlags.Instance |
                System.Reflection.BindingFlags.NonPublic)?
                .SetValue(c, true, null);

            foreach (Control child in c.Controls)
                EnableDoubleBuffer(child);
        }

        //private void slideTimer_Tick(object sender, EventArgs e)
        //{
        //    if (isCollapsed)
        //    {
        //        leftBrandPanel.Width += SlideSpeed;
        //        panelMain.Left += SlideSpeed; // move content right

        //        if (leftBrandPanel.Width >= MaxWidth)
        //        {
        //            slideTimer.Stop();
        //            isCollapsed = false;
        //            Refresh();
        //        }
        //    }
        //    else
        //    {
        //        leftBrandPanel.Width -= SlideSpeed;
        //        panelMain.Left -= SlideSpeed; // move content left

        //        if (leftBrandPanel.Width <= 0)
        //        {
        //            slideTimer.Stop();
        //            isCollapsed = true;
        //            Refresh();
        //        }
        //    }
        //}

        private void Form2_Load_RoundCorners(object sender, EventArgs e)
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
        
        private void EnableDragging(Control control)
        {
            control.MouseDown += Form2_MouseDown;
            control.MouseMove += Form2_MouseMove;
            control.MouseUp += Form2_MouseUp;
        }

        private void Form2_Load(object sender, EventArgs e)
        {
           
        }



        private void button1_Click(object sender, EventArgs e)
        {
          
        }

        private void button4_Click(object sender, EventArgs e)
        {
           
        }

        private void button2_Click(object sender, EventArgs e)
        {
   
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void rightCard_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            
        }

        private void button7_Click(object sender, EventArgs e)
        {
            
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control clickedControl = GetChildAtPoint(e.Location);
                if (clickedControl is Button)
                {
                    return;
                }
                
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }
    }
}
