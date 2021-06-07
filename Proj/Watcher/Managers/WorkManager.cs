using System.Configuration;
using System.Management;
using System.Threading;
using System.Threading.Tasks;

namespace Watcher.Managers
{
    public class WorkManager : IManager
    {
        SendManager sender;
        Task send;
        CancellationTokenSource cancelTokenSource;
        CancellationToken token;
        SQLManager sqlManager;
        public static string UserName { get; set; }
        public static string PCName { get; set; }

        public WorkManager()
        {
            using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT * FROM Win32_ComputerSystem"))
            {
                foreach (ManagementObject mo in searcher.Get())
                {
                    UserName = mo["UserName"].ToString();
                    PCName = mo["Name"].ToString();
                    break;
                }
            }

            sqlManager = new SQLManager();
            sender = new SendManager(sqlManager);
            cancelTokenSource = new CancellationTokenSource();
            token = cancelTokenSource.Token;
            send = new Task(() => {
                while (true)
                {
                    if (token.IsCancellationRequested)
                    {
                        return;
                    }

                    var app = new AppManager(sqlManager);
                    var web = new WebManager(sqlManager);
                    var device = new DeviceManager(sqlManager);

                    try
                    {
                        app.Watch();
                        device.Watch();
                        web.Watch();
                        Thread.Sleep(int.Parse(ConfigurationManager.AppSettings["timeOut"]));
                    }
                    catch { }
                    finally {
                        app.StopWatch();
                        device.StopWatch();
                        web.StopWatch();
                    }
                    sender.Send();
                }
            });
        }

        public void Watch()
        {
            send.Start();
        }

        public void StopWatch()
        {
            cancelTokenSource.Cancel();
        }
    }
}
