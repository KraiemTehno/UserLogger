using System;
using System.Collections.Generic;
using System.Web.Http;
using Watcher.Models;
using WatcherAPI.Managers;

namespace WatcherAPI.Controllers
{
    public class WebLogController : ApiController
    {
        private SQLManager sqlManager;

        public WebLogController(SQLManager sqlManager)
        {
            this.sqlManager = sqlManager;
        }

        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
            return sqlManager.ReadAllWebUsers();
        }

        public IEnumerable<string> GetUrls()
        {
            return sqlManager.ReadAllWebUrls();
        }

        // GET: api/AppLog
        public IEnumerable<WebLogModel> GetAll(DateTime from, DateTime to, string user, string url)
        {
            return sqlManager.ReadAllWebLogs(from, to, user, url);
        }

        // POST: api/AppLog
        [HttpPost]
        public void Post([FromBody]WebLogModel[] value)
        {
            foreach (var item in value)
            {
                sqlManager.WriteWebLog(item);
            }
        }
    }
}
