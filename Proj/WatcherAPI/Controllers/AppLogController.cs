using System;
using System.Collections.Generic;
using System.Web.Http;
using WatcherAPI.Managers;
using Watcher.Models;

namespace WatcherAPI.Controllers
{
    public class AppLogController : ApiController
    {
        private ISQLApiManager sqlManager;

        public AppLogController(ISQLApiManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
            return sqlManager.ReadAllAppUsers();
        }

        public IEnumerable<string> GetApp()
        {
            return sqlManager.ReadAllAppExecutibles();
        }

        // GET: api/AppLog
        public IEnumerable<AppLogModel> GetAll(DateTime from, DateTime to, string user, string app)
        {
            return sqlManager.ReadAllAppLogs(from, to, user, app);
        }

        // POST: api/AppLog
        [HttpPost]
        public void Post([FromBody]AppLogModel[] value)
        {
            foreach (var item in value)
            {
                sqlManager.WriteAppLog(item);
            }
        }
    }
}
