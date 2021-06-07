using System;
using System.Management;
using System.Collections.Generic;
using Watcher.Models;

namespace Watcher.Managers
{
    public class AppManager : IManager
    {
        SQLManager sqlManager;
        ManagementEventWatcher appStartWatcher;
        ManagementEventWatcher appStopWatcher;
        List<string> filter = new List<string>() { "cmd.exe", "dllhost.exe", "conhost.exe", "svchost.exe", "WUDFHost.exe" };

        public AppManager(SQLManager sqlManager)
        {
            this.sqlManager = sqlManager;
            var quaryStart = new SelectQuery("Win32_ProcessStartTrace");
            appStartWatcher = new ManagementEventWatcher(quaryStart.QueryString);
            var quaryStop = new SelectQuery("Win32_ProcessStopTrace");
            appStopWatcher = new ManagementEventWatcher(quaryStop.QueryString);

            appStartWatcher.EventArrived += CallBackStartWatcherApp;
            appStopWatcher.EventArrived += CallBackStopWatcherApp;
        }

        public void Watch()
        {
            appStartWatcher.Start();
            appStopWatcher.Start();
        }

        public void StopWatch()
        {
            appStartWatcher.Stop();
            appStopWatcher.Stop();
        }

        private void CallBackStartWatcherApp(object sender, EventArrivedEventArgs args)
        {
            if (args.NewEvent.Properties.Count == 0)
                return;
            if (filter.Contains(args.NewEvent.Properties["ProcessName"].Value.ToString()))
                return;
            var log = GetModel(args);
            log.Action = Enums.AppAction.Start;
            sqlManager.WriteAppLog(log);
        }

        private void CallBackStopWatcherApp(object sender, EventArrivedEventArgs args)
        {
            if (args.NewEvent.Properties.Count == 0)
                return;
            if (filter.Contains(args.NewEvent.Properties["ProcessName"].Value.ToString()))
                return;
            var log = GetModel(args);
            log.Action = Enums.AppAction.Stop;
            sqlManager.WriteAppLog(log);
        }

        private AppLogModel GetModel(EventArrivedEventArgs args)
        {
            var model = new AppLogModel
            {
                Name = args.NewEvent.Properties["ProcessName"].Value.ToString(),
                ProcessId = args.NewEvent.Properties["ProcessID"].Value.ToString(),
                SessionID = args.NewEvent.Properties["SessionID"].Value.ToString(),
                CreateDateTime = DateTime.Now,
                PCName = WorkManager.PCName,
                UserName = WorkManager.UserName
            };

            return model;
        }
    }
}
