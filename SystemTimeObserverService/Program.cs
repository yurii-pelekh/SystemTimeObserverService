using System.Linq;

namespace SystemTimeObserverService
{
    using System.ServiceProcess;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main(string[] args)
        {
            var ServicesToRun = new ServiceBase[]
            {
                new TimeObserver()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}