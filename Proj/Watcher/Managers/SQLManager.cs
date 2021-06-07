using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using Watcher.Enums;
using Watcher.Models;

namespace Watcher.Managers
{
    public class SQLManager : ISQLManager
    {
        string databaseName = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Watcher\\log.db";
        string hostName = $"{Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)}\\Watcher";
        SQLiteConnection connection;

        public SQLManager()
        {
            GetConnection();
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

        public IEnumerable<AppLogModel> ReadAllAppLogs()
        {
            var list = new List<AppLogModel>();            
            var command = new SQLiteCommand("SELECT * FROM AppLog;", connection);
            var reader = command.ExecuteReader();

            foreach (DbDataRecord record in reader)
            {
                list.Add(new AppLogModel {
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

            return list;
        }

        public IEnumerable<DeviceLogModel> ReadAllDeviceLogs()
        {
            var list = new List<DeviceLogModel>();            
            var command = new SQLiteCommand("SELECT * FROM DeviceLog;", connection);
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

            return list;
        }

        public IEnumerable<WebLogModel> ReadAllWebLogs()
        {
            var list = new List<WebLogModel>();            
            var command = new SQLiteCommand("SELECT * FROM WebLog;", connection);
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

        public void ClearDB()
        {
            new SQLiteCommand(@"DELETE FROM AppLog;", connection).ExecuteNonQuery();
            new SQLiteCommand(@"DELETE FROM DeviceLog;", connection).ExecuteNonQuery();
            new SQLiteCommand(@"DELETE FROM WebLog WHERE id NOT IN ( 
   SELECT id FROM WebLog 
   ORDER BY CreateDateTime DESC
   LIMIT 1 
   );", connection).ExecuteNonQuery();
        }

        private void GetConnection()
        {
            CreateDB();
            connection = new SQLiteConnection(string.Format("Data Source={0};", databaseName));
            connection.Open();
        }
    }
}
