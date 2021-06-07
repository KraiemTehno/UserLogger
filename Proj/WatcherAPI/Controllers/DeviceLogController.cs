using System;
using System.Collections.Generic;
using System.Web.Http;
using Watcher.Models;
using WatcherAPI.Managers;

namespace WatcherAPI.Controllers
{
    public class DeviceLogController : ApiController
    {
        private SQLManager sqlManager;

        public DeviceLogController(SQLManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
            return sqlManager.ReadAllDeviceUsers();
        }

        // GET: api/AppLog
        public IEnumerable<DeviceLogModel> GetAll(DateTime from, DateTime to, string user)
        {
            return sqlManager.ReadAllDeviceLogs(from, to, user);
        }

        // POST: api/AppLog
        [HttpPost]
        public void Post([FromBody]DeviceLogModel[] value)
        {
            foreach (var item in value)
            {
                sqlManager.WriteDeviceLog(item);
            }
        }
    }
}
