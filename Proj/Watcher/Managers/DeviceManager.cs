using System;
using System.Management;
using Watcher.Models;

namespace Watcher.Managers
{
    public class DeviceManager : IManager
    {
        SQLManager sqlManager;
        ManagementEventWatcher watcherArrived;

        public DeviceManager(SQLManager sqlManager)
        {
            this.sqlManager = sqlManager;
            string queryStr = "SELECT * FROM __InstanceCreationEvent WITHIN 2 WHERE TargetInstance ISA 'Win32_PnPEntity'";
            watcherArrived = new ManagementEventWatcher(queryStr);

            watcherArrived.EventArrived += new EventArrivedEventHandler(DeviceChangeEventReceived);
        }

        public void Watch()
        {
            watcherArrived.Start();
        }

        public void StopWatch()
        {
            watcherArrived.Stop();
        }

        private void DeviceChangeEventReceived(object sender, EventArrivedEventArgs args)
        {
            if (args.NewEvent.Properties.Count == 0)
                return;
            ManagementBaseObject instance = (ManagementBaseObject)args.NewEvent["TargetInstance"];
            var PNPDeviceID = instance.Properties["PNPClass"].Value.ToString();
            if (instance.Properties["PNPClass"].Value.ToString() != "WPD")
                return;
            var log = GetModel(instance);
            log.Action = Enums.DeviceAction.Mount;
            sqlManager.WriteDeviceLog(log);
        }

        private DeviceLogModel GetModel(ManagementBaseObject instance)
        {
            var model = new DeviceLogModel
            {
                DeviceName = instance.Properties["Name"].Value.ToString(),
                Description = instance.Properties["Description"].Value.ToString(),
                DeviceID = instance.Properties["DeviceID"].Value.ToString(),
                CreateDateTime = DateTime.Now,
                PCName = WorkManager.PCName,
                UserName = WorkManager.UserName
            };

            return model;
        }
    }
}
