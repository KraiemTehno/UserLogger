using Newtonsoft.Json;
using System;
using System.Configuration;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Watcher.Managers
{
    public class SendManager
    {
        private static readonly HttpClient client = new HttpClient() { BaseAddress = new Uri($"{ConfigurationManager.AppSettings["connectionString"]}api/") };
        private SQLManager sqlManager;

        public SendManager(SQLManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        public void Send()
        {
            try
            {
                SendApp();
                SendDevice();
                SendWeb();
                sqlManager.ClearDB();
            }
            catch
            {
            }
        }

        private async void SendApp()
        {
            var myContent = JsonConvert.SerializeObject(sqlManager.ReadAllAppLogs());
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            try
            {
                var response = await client.PostAsync("AppLog/Post", byteContent);
            }
            catch { }
        }

        private async void SendDevice()
        {
            var myContent = JsonConvert.SerializeObject(sqlManager.ReadAllDeviceLogs());
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await client.PostAsync("DeviceLog/Post", byteContent);
            }
            catch { }
        }

        private async void SendWeb()
        {
            var myContent = JsonConvert.SerializeObject(sqlManager.ReadAllWebLogs());
            var buffer = Encoding.UTF8.GetBytes(myContent);
            var byteContent = new ByteArrayContent(buffer);
            byteContent.Headers.ContentType = new MediaTypeHeaderValue("application/json");

            try
            {
                var response = await client.PostAsync("WebLog/Post", byteContent);
            }
            catch { }
        }
    }
}
