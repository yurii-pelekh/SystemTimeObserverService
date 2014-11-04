namespace SystemTimeObserverService
{
    using System.ServiceProcess;

    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] 
            { 
                new TimeObserver() 
            };
            ServiceBase.Run(ServicesToRun);
        }
    }
}
