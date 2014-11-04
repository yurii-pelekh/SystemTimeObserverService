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
        private System.ComponentModel.IContainer components = null;
        private long counter;

        public HiddenForm()
        {
            this.InitializeComponent();
        }

        private void HiddenFormLoad(object sender, EventArgs e)
        {
            SystemEvents.TimeChanged += this.SystemEventsTimeChanged;
        }

        private void HiddenFormFormClosing(object sender, FormClosingEventArgs e)
        {
            SystemEvents.TimeChanged -= this.SystemEventsTimeChanged;
        }

        private void SystemEventsTimeChanged(object sender, EventArgs e)
        {
            try
            {
                if (this.counter++ % 2 == 0)
                {
                    var fromAddress = new MailAddress("systemtimeobserver@gmail.com", "SystemTimeObserver");

                    const string FromPassword = "systemtime321";
                    const string Subject = "Alarm!";
                    var body = string.Format("System time was changed! New time is {0}", DateTime.Now);

                    var smtp = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        UseDefaultCredentials = false,
                        Credentials = new NetworkCredential(fromAddress.Address, FromPassword)
                    };

                    var toAddressesList = new List<string> { "vitki@ukr.net", "mazanuj@gmail.com" };
                    foreach (
                        var toAddress in toAddressesList.Select(toAddressString => new MailAddress(toAddressString)))
                    {
                        using (var message = new MailMessage(fromAddress, toAddress) { Subject = Subject, Body = body })
                        {
                            smtp.Send(message);
                        }
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
            if (disposing && (this.components != null))
            {
                this.components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(0, 0);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "TimeObserver";
            this.Text = "TimeObserver";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.Load += new System.EventHandler(this.HiddenFormLoad);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.HiddenFormFormClosing);
            this.ResumeLayout(false);

        }

    }
}
