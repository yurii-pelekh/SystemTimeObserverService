using System.ComponentModel;

namespace SystemTimeObserverService
{
    [RunInstaller(true)]
// ReSharper disable once ClassNeverInstantiated.Global
    public partial class ProjectInstaller : System.Configuration.Install.Installer
    {
        public ProjectInstaller()
        {
            InitializeComponent();
        }
    }
}