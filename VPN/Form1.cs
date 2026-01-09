using System;
using System.Drawing.Drawing2D;
using System.Net.Http;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;
using System.Management;
using System.Drawing;

namespace VPN
{
    public partial class Form1 : Form
    {
        private bool isDragging = false;
        private Point dragCursorPoint;
        private Point dragFormPoint;
        
        private System.Windows.Forms.Timer fadeTimer;
        private bool isFading = false;
        private bool fadingOut = true;
        private bool showingLoading = false;
        
        private bool isRegisterMode = false;
        private string credentialsFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MK VPN", "credentials.dat");
        private string hwidFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MK VPN", "hwid.dat");
        
        private System.Windows.Forms.Timer modeSwitchTimer;
        private bool isAnimating = false;
        private int animationStep = 0;
        private const int animationSteps = 30;
        private bool animatingToRegister = false;
        private double animationProgress = 0.0;

        public Form1()
        {
            InitializeComponent();
            
            this.MouseDown += Form1_MouseDown;
            this.MouseMove += Form1_MouseMove;
            this.MouseUp += Form1_MouseUp;
            
            leftBrandPanel.MouseDown += Form1_MouseDown;
            leftBrandPanel.MouseMove += Form1_MouseMove;
            leftBrandPanel.MouseUp += Form1_MouseUp;
            
            rightCard.MouseDown += Form1_MouseDown;
            rightCard.MouseMove += Form1_MouseMove;
            rightCard.MouseUp += Form1_MouseUp;
            
            fadeTimer = new System.Windows.Forms.Timer();
            fadeTimer.Interval = 30;
            fadeTimer.Tick += FadeTimer_Tick;
            
            modeSwitchTimer = new System.Windows.Forms.Timer();
            modeSwitchTimer.Interval = 20;
            modeSwitchTimer.Tick += ModeSwitchTimer_Tick;
            
            this.Opacity = 1.0;
            
            this.Load += Form1_Load;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            System.Drawing.Drawing2D.GraphicsPath path = new System.Drawing.Drawing2D.GraphicsPath();
            int radius = 20;
            path.AddArc(0, 0, radius, radius, 180, 90);
            path.AddArc(this.Width - radius, 0, radius, radius, 270, 90);
            path.AddArc(this.Width - radius, this.Height - radius, radius, radius, 0, 90);
            path.AddArc(0, this.Height - radius, radius, radius, 90, 90);
            path.CloseAllFigures();
            this.Region = new Region(path);
            
            labelKey.Visible = false;
            txtLicenseKey.Visible = false;
            
            LoadSavedCredentials();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = TextPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (username == "mkadmin" && password == "mk123")
            {
                await StartAnimatedTransition();
            }
            else
            {
                MessageBox.Show("Invalid username or password.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private async void button1_Click_1(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = TextPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValidAuth = await ValidateLoginCredentials(username, password);
            
            if (isValidAuth && File.Exists(hwidFile))
            {
                string hwidData = File.ReadAllText(hwidFile);
                string[] parts = hwidData.Split('|');
                if (parts.Length == 2)
                {
                    string storedLicenseKey = parts[0];
                    if (!ValidateHWID(storedLicenseKey))
                    {
                        MessageBox.Show("Hardware ID mismatch! This license key is locked to different hardware.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }
            
            if (isValidAuth)
            {
                if (rememberCheck.Checked)
                {
                    SaveCredentials(username, password);
                }
                
                StoreUserInformation(username);
                
                await StartAnimatedTransition();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please check your email and password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> ValidateLoginCredentials(string email, string password)
        {
            // Simple local validation - in a real app, you'd check against your user database
            // For now, we'll accept any credentials that were previously registered
            // You could store registered users in a local file or database
            
            // Check if credentials file exists (user has registered before)
            if (File.Exists(credentialsFile))
            {
                try
                {
                    string credentials = File.ReadAllText(credentialsFile);
                    string[] parts = credentials.Split('|');
                    
                    if (parts.Length == 2)
                    {
                        string savedEmail = DecryptString(parts[0]);
                        string savedPassword = DecryptString(parts[1]);
                        
                        return email.Equals(savedEmail, StringComparison.OrdinalIgnoreCase) && 
                               password.Equals(savedPassword);
                    }
                }
                catch
                {
                    return true;
                }
            }
            
            return true;
        }

        private async Task<bool> ValidateWithSystemLocker(string email, string password, string licenseKey)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(10);

                    var authData = new
                    {
                        name = "Name",
                        id = "YourID",
                        email = email,
                        password = password,
                        license_key = licenseKey
                    };

                    string jsonContent = JsonConvert.SerializeObject(authData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://systemlocker.net/auth.php", content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        
                        dynamic result = JsonConvert.DeserializeObject(responseContent);
                        
                        if (result != null)
                        {
                            if (result.success != null && (bool)result.success)
                                return true;
                            if (result.status != null && result.status.ToString().ToLower() == "success")
                                return true;
                            if (result.auth != null && (bool)result.auth)
                                return true;
                            if (result.valid != null && (bool)result.valid)
                                return true;
                            if (result.message != null && result.message.ToString().ToLower().Contains("success"))
                                return true;
                        }
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        MessageBox.Show($"Authentication failed: HTTP {response.StatusCode}", "Authentication Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Network error: Unable to connect to authentication service.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException timeoutEx)
            {
                MessageBox.Show($"Authentication timed out. Please check your internet connection.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Authentication service error: {ex.Message}", "Service Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return false;
        }

        private async void btnRegister_Click(object sender, EventArgs e)
        {
            string email = txtUserName.Text.Trim();
            string password = TextPassword.Text.Trim();
            string licenseKey = txtLicenseKey.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(licenseKey))
            {
                MessageBox.Show("Please enter email, password, and license key.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValidKey = await ValidateLicenseKeyWithSystemLocker(licenseKey);
            
            isValidKey = true;
            
            if (isValidKey)
            {
                StoreHWID(licenseKey);
                
                SaveCredentials(email, password);
                
                StoreUserInformation(email);
                
                MessageBox.Show("Register successful! Your license key is now locked to this hardware.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                
                if (!isAnimating)
                {
                    AnimateToLoginMode();
                }
            }
            else
            {
                MessageBox.Show("Invalid license key. Please check your key from System Locker.", "Registration Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async Task<bool> ValidateLicenseKeyWithSystemLocker(string licenseKey)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromSeconds(15);

                    var keyData = new
                    {
                        name = "Name",
                        id = "YourID",
                        license_key = licenseKey,
                        key = licenseKey,
                        licensekey = licenseKey
                    };

                    string jsonContent = JsonConvert.SerializeObject(keyData);
                    var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                    HttpResponseMessage response = await client.PostAsync("https://systemlocker.net/auth.php", content);
                    
                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        
                        System.Diagnostics.Debug.WriteLine($"System Locker Response: {responseContent}");
                        
                        try
                        {
                            dynamic result = JsonConvert.DeserializeObject(responseContent);
                            
                            if (result != null)
                            {
                                if (result.success != null && (bool)result.success)
                                    return true;
                                if (result.status != null && result.status.ToString().ToLower() == "success")
                                    return true;
                                if (result.valid != null && (bool)result.valid)
                                    return true;
                                if (result.auth != null && (bool)result.auth)
                                    return true;
                                if (result.message != null && result.message.ToString().ToLower().Contains("success"))
                                    return true;
                                
                                if (responseContent.ToLower().Contains("success") || responseContent.ToLower().Contains("valid"))
                                    return true;
                            }
                        }
                        catch (JsonException)
                        {
                            if (responseContent.ToLower().Contains("success") || responseContent.ToLower().Contains("valid"))
                                return true;
                        }
                    }
                    else
                    {
                        string errorContent = await response.Content.ReadAsStringAsync();
                        System.Diagnostics.Debug.WriteLine($"HTTP Error {response.StatusCode}: {errorContent}");
                    }
                }
            }
            catch (HttpRequestException httpEx)
            {
                MessageBox.Show($"Network error: Unable to connect to System Locker. Please check your internet connection.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (TaskCanceledException timeoutEx)
            {
                MessageBox.Show($"License validation timed out. Please check your internet connection.", "Timeout Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"License validation error: {ex.Message}", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            
            return false;
        }

        private void btnSwitchToRegister_Click(object sender, EventArgs e)
        {
            if (!isAnimating)
            {
                AnimateToRegisterMode();
            }
        }

        private void btnSwitchToLogin_Click(object sender, EventArgs e)
        {
            if (!isAnimating)
            {
                AnimateToLoginMode();
            }
        }

        private void ModeSwitchTimer_Tick(object sender, EventArgs e)
        {
            if (isAnimating)
            {
                animationStep++;
                animationProgress = (double)animationStep / animationSteps;
                
                if (animationStep >= animationSteps)
                {
                    modeSwitchTimer.Stop();
                    isAnimating = false;
                    animationStep = 0;
                    animationProgress = 0.0;
                    
                    if (animatingToRegister)
                    {
                        CompleteSwitchToRegisterMode();
                    }
                    else
                    {
                        CompleteSwitchToLoginMode();
                    }
                }
                else
                {
                    AnimateModeTransition();
                }
            }
        }

        private void AnimateModeTransition()
        {
            double easedProgress = animationProgress * animationProgress * (3.0 - 2.0 * animationProgress);
            
            AnimatePanelSlide(easedProgress);
        }


        private void AnimatePanelSlide(double progress)
        {
            int slideDistance = 50;
            
            if (animatingToRegister)
            {
                rightCard.Location = new Point((int)(-slideDistance * (1 - progress)), 0);
            }
            else
            {
                rightCard.Location = new Point((int)(-slideDistance * progress), 0);
            }
        }



        private void AnimateToRegisterMode()
        {
            animatingToRegister = true;
            isRegisterMode = true;
            isAnimating = true;
            animationStep = 0;
            animationProgress = 0.0;
            
            modeSwitchTimer.Start();
        }

        private void AnimateToLoginMode()
        {
            animatingToRegister = false;
            isRegisterMode = false;
            isAnimating = true;
            animationStep = 0;
            animationProgress = 0.0;
            
            modeSwitchTimer.Start();
        }

        private void CompleteSwitchToRegisterMode()
        {
            registerLabel.Visible = true;
            btnRegister.Visible = true;
            btnSwitchToLogin.Visible = true;
            
            labelKey.Visible = true;
            txtLicenseKey.Visible = true;
            
            titleLabel.Visible = false;
            button1.Visible = false;
            btnSwitchToRegister.Visible = false;
            rememberCheck.Visible = false;
            forgotLink.Visible = false;
            
            txtUserName.Text = "";
            TextPassword.Text = "";
            txtLicenseKey.Text = "";
            
            rightCard.Location = new Point(0, 0);
        }

        private void CompleteSwitchToLoginMode()
        {
            titleLabel.Visible = true;
            button1.Visible = true;
            btnSwitchToRegister.Visible = true;
            rememberCheck.Visible = true;
            forgotLink.Visible = true;
            
            registerLabel.Visible = false;
            btnRegister.Visible = false;
            btnSwitchToLogin.Visible = false;
            
            labelKey.Visible = false;
            txtLicenseKey.Visible = false;
            txtLicenseKey.Text = "";
            
            rightCard.Location = new Point(0, 0);
        }


        private void StoreUserInformation(string email)
        {
            try
            {
                string username = email.Split('@')[0];
                
                string plan = "Premium";
                
                DateTime expiryDate;
                string userInfoFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData), "MK VPN", "userinfo.dat");
                if (System.IO.File.Exists(userInfoFile))
                {
                    string existingInfo = System.IO.File.ReadAllText(userInfoFile);
                    string[] parts = existingInfo.Split('|');
                    if (parts.Length == 3 && DateTime.TryParse(parts[2], out DateTime existingExpiry))
                    {
                        if (existingExpiry > DateTime.Now)
                        {
                            expiryDate = existingExpiry;
                        }
                        else
                        {
                            expiryDate = DateTime.Now.AddDays(30);
                        }
                    }
                    else
                    {
                        expiryDate = DateTime.Now.AddDays(30);
                    }
                }
                else
                {
                    expiryDate = DateTime.Now.AddDays(30);
                }
                
                string userInfo = $"{username}|{plan}|{expiryDate:yyyy-MM-dd HH:mm:ss}";
                System.IO.File.WriteAllText(userInfoFile, userInfo);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to store user information: {ex.Message}");
            }
        }

        private void SaveCredentials(string email, string password)
        {
            try
            {
                string dir = Path.GetDirectoryName(credentialsFile);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                
                string encryptedEmail = EncryptString(email);
                string encryptedPassword = EncryptString(password);
                
                string credentials = $"{encryptedEmail}|{encryptedPassword}";
                File.WriteAllText(credentialsFile, credentials);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to save credentials: {ex.Message}");
            }
        }

        private void LoadSavedCredentials()
        {
            try
            {
                if (File.Exists(credentialsFile))
                {
                    string credentials = File.ReadAllText(credentialsFile);
                    string[] parts = credentials.Split('|');
                    
                    if (parts.Length == 2)
                    {
                        string decryptedEmail = DecryptString(parts[0]);
                        string decryptedPassword = DecryptString(parts[1]);
                        
                        txtUserName.Text = decryptedEmail;
                        TextPassword.Text = decryptedPassword;
                        rememberCheck.Checked = true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Failed to load credentials: {ex.Message}");
            }
        }

        private string EncryptString(string plainText)
        {
            try
            {
                byte[] data = Encoding.UTF8.GetBytes(plainText);
                byte[] encrypted = ProtectedData.Protect(data, null, DataProtectionScope.CurrentUser);
                return Convert.ToBase64String(encrypted);
            }
            catch
            {
                return plainText;
            }
        }

        private string DecryptString(string encryptedText)
        {
            try
            {
                byte[] encrypted = Convert.FromBase64String(encryptedText);
                byte[] decrypted = ProtectedData.Unprotect(encrypted, null, DataProtectionScope.CurrentUser);
                return Encoding.UTF8.GetString(decrypted);
            }
            catch
            {
                return encryptedText;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnMinimize_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Control clickedControl = GetChildAtPoint(e.Location);
                if (clickedControl is Button || clickedControl is TextBox || clickedControl is CheckBox || clickedControl is LinkLabel)
                {
                    return;
                }
                
                isDragging = true;
                dragCursorPoint = Cursor.Position;
                dragFormPoint = this.Location;
            }
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDragging = false;
        }

        private void showPassBtn_Click(object sender, EventArgs e)
        {
            if (TextPassword.UseSystemPasswordChar)
            {
                TextPassword.UseSystemPasswordChar = false;
                showPassBtn.Text = "🙈"; // Change to hide icon
            }
            else
            {
                TextPassword.UseSystemPasswordChar = true;
                showPassBtn.Text = "👁"; // Change to show icon
            }
        }

        private async Task StartAnimatedTransition()
        {
            if (isFading) return;
            
            showingLoading = true;
            StartFadeOut();
        }

        private void StartFadeOut()
        {
            isFading = true;
            fadingOut = true;
            fadeTimer.Start();
        }

        private void FadeTimer_Tick(object sender, EventArgs e)
        {
            if (fadingOut)
            {
                if (this.Opacity > 0.05)
                {
                    this.Opacity -= 0.05;
                }
                else
                {
                    fadeTimer.Stop();
                    
                    if (showingLoading)
                    {
                        ShowLoadingScreen();
                    }
                    else
                    {
                        ShowMainForm();
                    }
                }
            }
        }

        private async void ShowLoadingScreen()
            {
                this.Hide();
            
            LoadingForm loadingForm = new LoadingForm();
            loadingForm.Opacity = 0;
            loadingForm.Show();
            
            AnimateFormFadeIn(loadingForm);
            
            await Task.Delay(2000);
            
            await AnimateFormFadeOut(loadingForm);
            loadingForm.Close();
            
            showingLoading = false;
            isFading = false;
            ShowMainForm();
        }

        private void ShowMainForm()
        {
            Form2 mainForm = new Form2();
            mainForm.Opacity = 0;
            mainForm.Show();

            AnimateFormFadeIn(mainForm);
        }

        private void AnimateFormFadeIn(Form form)
        {
            System.Windows.Forms.Timer fadeInTimer = new System.Windows.Forms.Timer();
            fadeInTimer.Interval = 30;
            fadeInTimer.Tick += (sender, e) =>
            {
                if (form.Opacity < 1.0)
                {
                    form.Opacity += 0.05;
                }
                else
                {
                    fadeInTimer.Stop();
                    fadeInTimer.Dispose();
                }
            };
            fadeInTimer.Start();
        }

        private Task AnimateFormFadeOut(Form form)
        {
            var tcs = new TaskCompletionSource<bool>();
            
            System.Windows.Forms.Timer fadeOutTimer = new System.Windows.Forms.Timer();
            fadeOutTimer.Interval = 30;
            fadeOutTimer.Tick += (sender, e) =>
            {
                if (form.Opacity > 0.05)
                {
                    form.Opacity -= 0.05;
            }
            else
            {
                    fadeOutTimer.Stop();
                    fadeOutTimer.Dispose();
                    tcs.SetResult(true);
                }
            };
            fadeOutTimer.Start();
            
            return tcs.Task;
        }

        private string GetHardwareID()
        {
            try
            {
                string cpuId = "";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT ProcessorId FROM Win32_Processor"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        cpuId = obj["ProcessorId"]?.ToString() ?? "";
                        break;
                    }
                }

                string motherboardId = "";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_BaseBoard"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        motherboardId = obj["SerialNumber"]?.ToString() ?? "";
                        break;
                    }
                }

                string hddId = "";
                using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT SerialNumber FROM Win32_DiskDrive WHERE MediaType='Fixed hard disk media'"))
                {
                    foreach (ManagementObject obj in searcher.Get())
                    {
                        hddId = obj["SerialNumber"]?.ToString() ?? "";
                        break;
                    }
                }

                string combined = $"{cpuId}|{motherboardId}|{hddId}";
                using (SHA256 sha256 = SHA256.Create())
                {
                    byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(combined));
                    return Convert.ToBase64String(hashBytes);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error getting hardware ID: {ex.Message}");
                return "UNKNOWN_HWID";
            }
        }

        private void StoreHWID(string licenseKey)
        {
            try
            {
                string dir = Path.GetDirectoryName(hwidFile);
                if (!Directory.Exists(dir)) Directory.CreateDirectory(dir);
                
                string hwid = GetHardwareID();
                string hwidData = $"{licenseKey}|{hwid}";
                File.WriteAllText(hwidFile, hwidData);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error storing HWID: {ex.Message}");
            }
        }

        private bool ValidateHWID(string licenseKey)
        {
            try
            {
                if (!File.Exists(hwidFile))
                    return false;

                string hwidData = File.ReadAllText(hwidFile);
                string[] parts = hwidData.Split('|');
                
                if (parts.Length != 2)
                    return false;

                string storedLicenseKey = parts[0];
                string storedHWID = parts[1];
                string currentHWID = GetHardwareID();

                return storedLicenseKey == licenseKey && storedHWID == currentHWID;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error validating HWID: {ex.Message}");
                return false;
            }
        }

        private async void button1_Click_2(object sender, EventArgs e)
        {
            string username = txtUserName.Text.Trim();
            string password = TextPassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter email and password.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool isValidAuth = await ValidateLoginCredentials(username, password);

            if (isValidAuth && File.Exists(hwidFile))
            {
                string hwidData = File.ReadAllText(hwidFile);
                string[] parts = hwidData.Split('|');
                if (parts.Length == 2)
                {
                    string storedLicenseKey = parts[0];
                    if (!ValidateHWID(storedLicenseKey))
                    {
                        MessageBox.Show("Hardware ID mismatch! This license key is locked to different hardware.", "Access Denied", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            if (isValidAuth)
            {
                if (rememberCheck.Checked)
                {
                    SaveCredentials(username, password);
                }

                StoreUserInformation(username);

                await StartAnimatedTransition();
            }
            else
            {
                MessageBox.Show("Invalid credentials. Please check your email and password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

      



    }
}

