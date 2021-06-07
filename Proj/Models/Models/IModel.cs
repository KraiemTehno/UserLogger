using System;

namespace Watcher.Models
{
    interface IModel
    {
        int Id { get; set; }
        DateTime CreateDateTime { get; set; }
        string PCName { get; set; }
        string UserName { get; set; }
    }
}
