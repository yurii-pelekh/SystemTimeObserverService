namespace SystemTimeObserverService
{
    partial class ProjectInstaller
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.TimeObserverProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
            this.TimeObserver = new System.ServiceProcess.ServiceInstaller();
            // 
            // TimeObserverProcessInstaller
            // 
            this.TimeObserverProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
            this.TimeObserverProcessInstaller.Password = null;
            this.TimeObserverProcessInstaller.Username = null;
            // 
            // TimeObserver
            // 
            this.TimeObserver.ServiceName = "TimeObserverService";
            this.TimeObserver.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
            // 
            // ProjectInstaller
            // 
            this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.TimeObserverProcessInstaller,
            this.TimeObserver});

        }

        #endregion

        private System.ServiceProcess.ServiceProcessInstaller TimeObserverProcessInstaller;
        private System.ServiceProcess.ServiceInstaller TimeObserver;
    }
}