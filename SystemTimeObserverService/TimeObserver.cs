namespace SystemTimeObserverService
{
    using System.ServiceProcess;
    using System.Threading;
    using System.Windows.Forms;

    public partial class TimeObserver : ServiceBase
    {
        static void Main(string[] args)
        {
            ServiceBase.Run(new TimeObserver());
        }

        protected override void OnStart(string[] args)
        {
            new Thread(this.RunMessagePump).Start();
        }

        private void RunMessagePump()
        {
            Application.Run(new HiddenForm());
        }

        protected override void OnStop()
        {
            Application.Exit();
        }

    }
}
