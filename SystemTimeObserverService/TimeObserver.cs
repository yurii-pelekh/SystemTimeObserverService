namespace SystemTimeObserverService
{
    using System.ServiceProcess;
    using System.Threading;
    using System.Windows.Forms;

    public partial class TimeObserver : ServiceBase
    {
        private static void Main()
        {
            Run(new TimeObserver());
        }

        protected override void OnStart(string[] args)
        {
            new Thread(RunMessagePump).Start();
        }

        private static void RunMessagePump()
        {
            Application.Run(new HiddenForm());
        }

        protected override void OnStop()
        {
            Application.Exit();
        }
    }
}