using System;
using System.ComponentModel;
using Watcher.Enums;

namespace Watcher.Models
{
    public class AppLogModel : IModel
    {
        [DisplayName("N/N")]
        public int Id { get; set; }

        [DisplayName("Date of recording")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("Action")]
        public AppAction Action { get; set; }

        [DisplayName("Name of process")]
        public string Name { get; set; }

        [DisplayName("Identificator of process")]
        public string ProcessId { get; set; }

        [DisplayName("Identificator of session")]
        public string SessionID { get; set; }

        [DisplayName("User name of PC")]
        public string UserName { get; set; }

        [DisplayName("Name of PC")]
        public string PCName { get; set; }
    }
}
