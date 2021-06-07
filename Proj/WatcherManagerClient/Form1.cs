using Newtonsoft.Json;
using System;
using System.Configuration;
using System.IO;
using System.Net;
using System.Windows.Forms;
using Watcher.Models;

namespace WatcherManagerClient
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void tabControl1_Selecting(object sender, TabControlCancelEventArgs e)
        {
            switch (tabControl1.SelectedTab.Name)
            {
                case "tabApp":
                    AppDateFrom.Value = DateTime.Now;
                    AppDateTo.Value = DateTime.Now;
                    AppUser.Text = "";
                    GetAppUsers();
                    AppExe.Text = "";
                    GetApp();
                    break;
                case "tabDevice":
                    DeviceDateFrom.Value = DateTime.Now;
                    DeviceDateTo.Value = DateTime.Now;
                    DeviceUser.Text = "";
                    GetDeviceUsers();
                    break;
                case "tabUrl":
                    WebDateFrom.Value = DateTime.Now;
                    WebDateTo.Value = DateTime.Now;
                    WebUser.Text = "";
                    GetWebUsers();
                    WebUrl.Text = "";
                    GetUrls();
                    break;
            }
        }

        private WebRequest GetWebRequest(string req)
        {
            return WebRequest.Create($"{ConfigurationManager.AppSettings["connectionString"]}api/{req}");
        }

        private async void GetAppUsers()
        {
            WebResponse response = await GetWebRequest("AppLog/GetUsers").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    AppUser.Items.Clear();
                    AppUser.Items.AddRange(JsonConvert.DeserializeObject<string[]>(reader.ReadToEnd()));
                    response.Close();
                }
            }
        }

        private async void GetDeviceUsers()
        {
            WebResponse response = await GetWebRequest("DeviceLog/GetUsers").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    DeviceUser.Items.Clear();
                    DeviceUser.Items.AddRange(JsonConvert.DeserializeObject<string[]>(reader.ReadToEnd()));
                    response.Close();
                }
            }
        }

        private async void GetWebUsers()
        {
            WebResponse response = await GetWebRequest("WebLog/GetUsers").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    WebUser.Items.Clear();
                    WebUser.Items.AddRange(JsonConvert.DeserializeObject<string[]>(reader.ReadToEnd()));
                    response.Close();
                }
            }
        }

        private async void GetApp()
        {
            WebResponse response = await GetWebRequest("AppLog/GetApp").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    AppExe.Items.Clear();
                    AppExe.Items.AddRange(JsonConvert.DeserializeObject<string[]>(reader.ReadToEnd()));
                    response.Close();
                }
            }
        }

        private async void GetUrls()
        {
            WebResponse response = await GetWebRequest("WebLog/GetUrls").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    WebUrl.Items.Clear();
                    WebUrl.Items.AddRange(JsonConvert.DeserializeObject<string[]>(reader.ReadToEnd()));
                    response.Close();
                }
            }
        }

        private async void GetAllApp()
        {
            WebResponse response = await GetWebRequest($"AppLog/GetAll?from={AppDateFrom.Value.ToString("MM/dd/yy")}&to={AppDateTo.Value.ToString("MM/dd/yy")}&user={AppUser.Text}&app={AppExe.Text}").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var data = JsonConvert.DeserializeObject<AppLogModel[]>(reader.ReadToEnd());
                    dataAppLogs.DataSource = data;
                    response.Close();
                }
            }
        }

        private async void GetAllDevices()
        {
            WebResponse response = await GetWebRequest($"DeviceLog/GetAll?from={DeviceDateFrom.Value.ToString("MM/dd/yy")}&to={DeviceDateTo.Value.ToString("MM/dd/yy")}&user={DeviceUser.Text}").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var data = JsonConvert.DeserializeObject<DeviceLogModel[]>(reader.ReadToEnd());
                    dataDeviceLogs.DataSource = data;
                    response.Close();
                }
            }
        }

        private async void GetAllWeb()
        {
            WebResponse response = await GetWebRequest($"WebLog/GetAll?from={WebDateFrom.Value.ToString("MM/dd/yy")}&to={WebDateTo.Value.ToString("MM/dd/yy")}&user={WebUser.Text}&url={WebUrl.Text}").GetResponseAsync();
            using (Stream stream = response.GetResponseStream())
            {
                using (StreamReader reader = new StreamReader(stream))
                {
                    var data = JsonConvert.DeserializeObject<WebLogModel[]>(reader.ReadToEnd());
                    dataWebLogs.DataSource = data;
                    response.Close();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            GetAllApp();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            AppDateFrom.Value = DateTime.Now;
            AppDateTo.Value = DateTime.Now;
            AppUser.Text = "";
            GetAppUsers();
            AppExe.Text = "";
            GetApp();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AppDateFrom.Value = DateTime.Now;
            AppDateTo.Value = DateTime.Now;
            AppUser.Text = "";
            AppExe.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DeviceDateFrom.Value = DateTime.Now;
            DeviceDateTo.Value = DateTime.Now;
            DeviceUser.Text = "";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            WebDateFrom.Value = DateTime.Now;
            WebDateTo.Value = DateTime.Now;
            WebUser.Text = "";
            WebUrl.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            GetAllDevices();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            GetAllWeb();
        }

        private void Form1_Load_1(object sender, EventArgs e)
        {
            AppDateFrom.Value = DateTime.Now;
            AppDateTo.Value = DateTime.Now;
            AppUser.Text = "";
            GetAppUsers();
            AppExe.Text = "";
            GetApp();
        }
    }
}
