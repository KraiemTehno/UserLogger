using System;
using System.ComponentModel;
using Watcher.Enums;

namespace Watcher.Models
{
    public class DeviceLogModel : IModel
    {
        [DisplayName("N/N")]
        public int Id { get; set; }

        [DisplayName("Date of recording")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("Action")]
        public DeviceAction Action { get; set; }

        [DisplayName("Name of device")]
        public string DeviceName { get; set; }

        [DisplayName("Identificator of device")]
        public string DeviceID { get; set; }

        [DisplayName("Description for device")]
        public string Description { get; set; }

        [DisplayName("User name of PC")]
        public string UserName { get; set; }

        [DisplayName("Name of PC")]
        public string PCName { get; set; }
    }
}
