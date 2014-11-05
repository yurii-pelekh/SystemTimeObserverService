namespace SystemTimeObserverService
{
    using System.ServiceProcess;

    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        private static void Main()
        {
            var ServicesToRun = new ServiceBase[]
            {
                new TimeObserver()
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}