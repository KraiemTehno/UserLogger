using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using Watcher.Enums;
using Watcher.Models;

namespace WatcherAPI.Managers
{

    public class SQLManager : ISQLApiManager
    {
        string databaseName = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Watcher\\APILog.db";
        string hostName = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Watcher";
        SQLiteConnection connection;

        public SQLManager()
        {
            connection = GetConnection();
        }

        ~SQLManager()
        {
            if (connection != null)
                try
                {
                    connection.Close();
                }
                catch { }
        }

        public void WriteAppLog(AppLogModel log)
        {
            new SQLiteCommand($@"INSERT INTO AppLog (ProcessId,
                                    SessionID,
                                    Name,
                                    Action,
                                    CreateDateTime,
                                    PCName,
                                    UserName) 
                                    VALUES ('{log.ProcessId}',
                                    '{log.SessionID}',
                                    '{log.Name}',
                                    {(int)log.Action},
                                    '{log.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss")}',
                                    '{log.PCName}',
                                    '{log.UserName}');", connection).ExecuteNonQuery();
        }

        public void WriteDeviceLog(DeviceLogModel log)
        {
            new SQLiteCommand($@"INSERT INTO DeviceLog (Action,
                                    DeviceName,
                                    DeviceID,
                                    Description,
                                    CreateDateTime,
                                    PCName,
                                    UserName) 
                                    VALUES ({(int)log.Action},
                                    '{log.DeviceName}',
                                    '{log.DeviceID}',
                                    '{log.Description}',
                                    '{log.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss")}',
                                    '{log.PCName}',
                                    '{log.UserName}');", connection).ExecuteNonQuery();
        }

        public void WriteWebLog(WebLogModel log)
        {
            new SQLiteCommand($@"INSERT INTO WebLog (Url, Title,
                                    Browser,
                                    CreateDateTime,
                                    PCName,
                                    UserName) 
                                    VALUES ('{log.Url}','{log.Title.Replace("'", "\"")}',
                                    '{log.Browser}',
                                    '{log.CreateDateTime.ToString("yyyy-MM-dd HH:mm:ss")}',
                                    '{log.PCName}',
                                    '{log.UserName}');", connection).ExecuteNonQuery();
        }

        public IEnumerable<string> ReadAllDeviceUsers()
        {            
            var list = new List<string>();
            var command = new SQLiteCommand("SELECT UserName FROM DeviceLog;", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(record["UserName"].ToString());
            }

            return list.Distinct();
        }

        public IEnumerable<string> ReadAllWebUsers()
        {            
            var list = new List<string>();
            var command = new SQLiteCommand("SELECT UserName FROM WebLog;", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(record["UserName"].ToString());
            }

            return list.Distinct();
        }

        public IEnumerable<string> ReadAllAppUsers()
        {            
            var list = new List<string>();
            var command = new SQLiteCommand("SELECT UserName FROM AppLog;", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(record["UserName"].ToString());
            }

            return list.Distinct();
        }

        public IEnumerable<string> ReadAllAppExecutibles()
        {            
            var list = new List<string>();
            var command = new SQLiteCommand("SELECT Name FROM AppLog;", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(record["Name"].ToString());
            }

            return list.Distinct();
        }

        public IEnumerable<string> ReadAllWebUrls()
        {            
            var list = new List<string>();
            var command = new SQLiteCommand("SELECT Url FROM WebLog;", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(record["Url"].ToString());
            }

            return list.Distinct();
        }

        public IEnumerable<AppLogModel> ReadAllAppLogs(DateTime from, DateTime to, string user, string app)
        {            
            var list = new List<AppLogModel>();
            var command = new SQLiteCommand($@"SELECT * FROM AppLog where
                                               datetime(CreateDateTime) between datetime('{from.ToString("yyyy-MM-dd 00:00:00")}') and datetime('{to.ToString("yyyy-MM-dd 23:59:59")}') 
                                                {(!string.IsNullOrEmpty(user) ? $"and UserName = '{user}'" : null)}
                                                {(!string.IsNullOrEmpty(app) ? $"and Name = '{app}'" : null)}", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(new AppLogModel
                {
                    Id = int.Parse(record["Id"].ToString()),
                    Action = (AppAction)int.Parse(record["Action"].ToString()),
                    CreateDateTime = DateTime.ParseExact(record["CreateDateTime"].ToString(), "yyyy-MM-dd HH:mm:ss", null),
                    Name = record["Name"].ToString(),
                    PCName = record["PCName"].ToString(),
                    ProcessId = record["ProcessId"].ToString(),
                    SessionID = record["SessionID"].ToString(),
                    UserName = record["UserName"].ToString()
                }
                );
            }

            if (list.Any())
                list = list.OrderByDescending(x => x.CreateDateTime).ToList();

            return list;
        }

        public IEnumerable<DeviceLogModel> ReadAllDeviceLogs(DateTime from, DateTime to, string user)
        {            
            var list = new List<DeviceLogModel>();
            var command = new SQLiteCommand($@"SELECT * FROM DeviceLog where
                                               datetime(CreateDateTime) between datetime('{from.ToString("yyyy-MM-dd 00:00:00")}') and datetime('{to.ToString("yyyy-MM-dd 23:59:59")}') 
                                                {(!string.IsNullOrEmpty(user) ? $"and UserName = '{user}'" : null)}", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(new DeviceLogModel
                {
                    Id = int.Parse(record["Id"].ToString()),
                    Action = (DeviceAction)int.Parse(record["Action"].ToString()),
                    CreateDateTime = DateTime.ParseExact(record["CreateDateTime"].ToString(), "yyyy-MM-dd HH:mm:ss", null),
                    Description = record["Description"].ToString(),
                    DeviceID = record["DeviceID"].ToString(),
                    DeviceName = record["DeviceName"].ToString(),
                    PCName = record["PCName"].ToString(),
                    UserName = record["UserName"].ToString()
                }
                );
            }

            if (list.Any())
                list = list.OrderByDescending(x => x.CreateDateTime).ToList();

            return list;
        }

        public IEnumerable<WebLogModel> ReadAllWebLogs(DateTime from, DateTime to, string user, string url)
        {            
            var list = new List<WebLogModel>();
            var command = new SQLiteCommand($@"SELECT * FROM WebLog where
                                               datetime(CreateDateTime) between datetime('{from.ToString("yyyy-MM-dd 00:00:00")}') and datetime('{to.ToString("yyyy-MM-dd 23:59:59")}')
                                                {(!string.IsNullOrEmpty(user) ? $"and UserName = '{user}'" : null)}
                                                { (!string.IsNullOrEmpty(url) ? $"and Url = '{url}'" : null)}", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(new WebLogModel
                {
                    Id = int.Parse(record["Id"].ToString()),
                    Url = record["Url"].ToString(),
                    Browser = record["Browser"].ToString(),
                    Title = record["Title"].ToString(),
                    CreateDateTime = DateTime.ParseExact(record["CreateDateTime"].ToString(), "yyyy-MM-dd HH:mm:ss", null),
                    PCName = record["PCName"].ToString(),
                    UserName = record["UserName"].ToString()
                }
                );
            }

            if (list.Any())
                list = list.OrderByDescending(x => x.CreateDateTime).ToList();

            return list;
        }

        public void CreateDB()
        {
            if (File.Exists(databaseName))
            {
                return;
            }

            if (!Directory.Exists(hostName))
            {
                Directory.CreateDirectory(hostName);
            }

            SQLiteConnection.CreateFile(databaseName);

            var connectionCreate = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connectionCreate.Open();

            new SQLiteCommand(@"CREATE TABLE AppLog (id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    ProcessId TEXT,
                                    SessionID TEXT,
                                    Name TEXT,
                                    Action INTEGER,
                                    CreateDateTime TEXT,
                                    PCName TEXT,
                                    UserName TEXT);", connectionCreate).ExecuteNonQuery();
            new SQLiteCommand(@"CREATE TABLE DeviceLog (id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Action INTEGER,
                                    DeviceName TEXT,
                                    DeviceID TEXT,
                                    Description TEXT,
                                    CreateDateTime TEXT,
                                    PCName TEXT,
                                    UserName TEXT);", connectionCreate).ExecuteNonQuery();
            new SQLiteCommand(@"CREATE TABLE WebLog (id INTEGER PRIMARY KEY AUTOINCREMENT,
                                    Url TEXT,
                                    Title TEXT,
                                    Browser TEXT,
                                    CreateDateTime Text,
                                    PCName TEXT,
                                    UserName TEXT);", connectionCreate).ExecuteNonQuery();

            connectionCreate.Close();
        }

        private SQLiteConnection GetConnection()
        {
            CreateDB();
            var connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
            return connection;
        }
    }
}