using System;
using System.ComponentModel;

namespace Watcher.Models
{
    public class WebLogModel : IModel
    {
        [DisplayName("N/N")]
        public int Id { get; set; }

        [DisplayName("Date of recording")]
        public DateTime CreateDateTime { get; set; }

        [DisplayName("Url of site")]
        public string Url { get; set; }

        [DisplayName("Title of site")]
        public string Title { get; set; }

        [DisplayName("Browser Name")]
        public string Browser { get; set; }

        [DisplayName("User name of PC")]
        public string UserName { get; set; }

        [DisplayName("Name of PC")]
        public string PCName { get; set; }
    }
}
