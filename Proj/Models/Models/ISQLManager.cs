using System;
using System.Collections.Generic;

namespace Watcher.Models
{
    public interface ISQLManager
    {
        void WriteAppLog(AppLogModel log);
        void WriteDeviceLog(DeviceLogModel log);
        void WriteWebLog(WebLogModel log);
        void CreateDB();
    }
    public interface ISQLApiManager : ISQLManager
    {
        IEnumerable<string> ReadAllDeviceUsers();
        IEnumerable<string> ReadAllWebUsers();
        IEnumerable<string> ReadAllAppUsers();
        IEnumerable<string> ReadAllAppExecutibles();
        IEnumerable<string> ReadAllWebUrls();
        IEnumerable<AppLogModel> ReadAllAppLogs(DateTime from, DateTime to, string user, string app);
        IEnumerable<DeviceLogModel> ReadAllDeviceLogs(DateTime from, DateTime to, string user);
        IEnumerable<WebLogModel> ReadAllWebLogs(DateTime from, DateTime to, string user, string url);
    }
}
