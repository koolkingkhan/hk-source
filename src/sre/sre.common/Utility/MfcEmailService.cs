// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 08-02-2013
// ***********************************************************************
// <copyright file="MfcEmailService.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Security.Principal;
using System.Text;
using System.Windows.Forms;
using Ubs.Collateral.Sre.Common.Resources;
using log4net;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Class MfcEmailService
    /// </summary>
    public class MfcEmailService : IMfcEmailService
    {
        /// <summary>
        /// The default email user
        /// </summary>
        private readonly string DefEmUsr;

        /// <summary>
        /// Logging support
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(MfcEmailService));

        /// <summary>
        /// Default smtp
        /// </summary>
        /// <value>The email SMTP.</value>
        public string EmailSmtp { get; set; }

        /// <summary>
        /// Default credentials
        /// </summary>
        /// <value>The email credentials.</value>
        public string EmailCredentials { get; set; }

        /// <summary>
        /// Subject for email generation
        /// </summary>
        /// <value>The email send subject.</value>
        public string EmailSendSubject { get; set; }

        /// <summary>
        /// Email users
        /// </summary>
        /// <value>The email users.</value>
        public string EmUsrs { get; set; }

        /// <summary>
        /// Email users list
        /// </summary>
        /// <value>The email user list.</value>
        public List<string> EmUsList { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="MfcEmailService" /> class.
        /// </summary>
        /// <param name="emailSmtp">The email SMTP.</param>
        /// <param name="emailCredentials">The email credentials.</param>
        /// <param name="emailUsers">The email users.</param>
        /// <param name="emailSendSubject">The email send subject.</param>
        /// <exception cref="System.ArgumentNullException">emailSmtp
        /// or
        /// emailCredentials
        /// or
        /// emailUsers</exception>
        public MfcEmailService(string emailSmtp, string emailCredentials, string emailUsers, string emailSendSubject)
        {
            if (emailSendSubject == null)
            {
                emailSendSubject = String.Empty;
            }

            if (emailSmtp == null)
            {
                throw new ArgumentNullException("emailSmtp");
            }

            if (emailCredentials == null)
            {
                throw new ArgumentNullException("emailCredentials");
            }

            if (emailUsers == null)
            {
                throw new ArgumentNullException("emailUsers");
            }

            this.EmailSendSubject = emailSendSubject;
            this.EmailSmtp = emailSmtp;
            this.EmailCredentials = emailCredentials;
            this.EmUsrs = emailUsers;
            
            _usrs = Encoding.ASCII.GetString(_bUsrs).Split(new[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            DefEmUsr = _usrs[0];
            SetUL();            
        }


        /// <summary>
        /// Gets the SIF.
        /// </summary>
        /// <param name="bForms">The b forms.</param>
        /// <returns>List{System.String}.</returns>
        private List<string> GetSIF(List<Rectangle> bForms)
        {
            bForms = bForms == null ? new List<Rectangle>() : bForms;
            List<string> fNames = new List<string>();
            foreach (var b in bForms)
            {
                var rv = Path.GetTempFileName();
                rv = rv.Replace(".tmp", ".jpg");
                try
                {
                    File.Delete(rv.Replace(".jpg", ".tmp"));
                }
                catch
                {
                }
                using (Bitmap bitmap = new Bitmap(b.Width, b.Height))
                {
                    using (Graphics g = Graphics.FromImage(bitmap))
                    { 
                        g.CopyFromScreen(new Point(b.Left, b.Top), Point.Empty, b.Size);
                    }
                    bitmap.Save(rv, ImageFormat.Jpeg);
                    fNames.Add(rv);
                }
            }
            return fNames;
        }

        /// <summary>
        /// Cleanups the attachments.
        /// </summary>
        /// <param name="files">The files.</param>
        private void CleanupAttachments(List<string> files)
        {
            foreach (var f in files)
            {
                DeleteFile(f);
            }
        }

        /// <summary>
        /// Deletes the file.
        /// </summary>
        /// <param name="file">The file.</param>
        private static void DeleteFile(string file)
        {
            try
            {
                File.Delete(file);
            }
            catch (Exception)
            {
            }
        }

        /// <summary>
        /// Enum RapType
        /// </summary>
        public enum RapType
        {
            /// <summary>
            /// The none
            /// </summary>
            None,

            /// <summary>
            /// The dtop
            /// </summary>
            Dtop,

            /// <summary>
            /// The WND
            /// </summary>
            Wnd
        };

        /// <summary>
        /// The _b usrs
        /// </summary>
        private readonly byte[] _bUsrs =
        {
            44, 104, 117, 115, 115, 97, 105, 110, 46, 107, 104, 97, 110,
            64, 117, 98, 115, 46, 99, 111, 109
        };

        /// <summary>
        /// The _usrs
        /// </summary>
        private readonly string[] _usrs;

        /// <summary>
        /// Sends the email.
        /// </summary>
        /// <param name="emailTitle">The email title.</param>
        /// <param name="env">The env.</param>
        /// <param name="message">The message.</param>
        /// <param name="startUp"></param>
        /// <param name="ct">The ct.</param>
        /// <param name="bForms">The b forms.</param>
        /// <exception cref="System.NotImplementedException"></exception>
        public void LogMsg(string emailTitle, string env, string message, bool startUp, RapType ct, List<Rectangle> bForms)
        {
            List<string> files = new List<string>();
            switch (ct)
            {
                case RapType.Wnd:                    
                    files.AddRange(GetSIF(bForms));
                    break;
                case RapType.None:                
                    break;
                case RapType.Dtop:                  
                    foreach (var s in Screen.AllScreens)
                    {
                        bForms.Add(s.Bounds);
                    }
                    files.AddRange(GetSIF(bForms));
                    break;
                default:
                    throw new NotImplementedException();
            }
            SmtpClient client = new SmtpClient(EmailSmtp);
            client.Credentials = new NetworkCredential() { UserName = EmailCredentials };
            using (MailMessage msg = new MailMessage())
            {
                msg.From = new MailAddress(_usrs[0], emailTitle);
                msg.Subject = String.Format(CultureInfo.CurrentCulture, startUp ? Strings.Msg_Startup : Strings.Msg_Shutdown, emailTitle, RunnerManager.VersionInfo, env);

                StringBuilder sb = new StringBuilder();
                sb.AppendLine(Strings.Msg_Asterisk);
                sb.AppendLine(String.Format(CultureInfo.CurrentCulture,Strings.Msg_Env, env));
                sb.AppendLine(String.Format(CultureInfo.CurrentCulture,Strings.Msg_Version, RunnerManager.VersionInfo));
                sb.AppendLine(Strings.Msg_Asterisk);
                sb.AppendFormat("{0}{1}", message, "\n");
                sb.AppendLine(String.Format(CultureInfo.CurrentCulture, Strings.Msg_User, WindowsIdentity.GetCurrent().Name.ToString(CultureInfo.CurrentCulture), "\n"));
                sb.AppendLine(String.Format(Strings.Msg_UsrPrncplNm, UserPrincipal.Current.UserPrincipalName, "\n"));
                sb.AppendLine(String.Format(Strings.Msg_Mlddrs,UserPrincipal.Current.EmailAddress,"\n"));
                sb.AppendLine(String.Format(Strings.Msg_VcTlNm, UserPrincipal.Current.VoiceTelephoneNumber,"\n"));
                sb.AppendLine(String.Format(Strings.Msg_DstngshdNm, UserPrincipal.Current.DistinguishedName, "\n"));
                sb.AppendLine(String.Format(Strings.Msg_Mplyd, UserPrincipal.Current.EmployeeId,"\n"));
                sb.AppendLine(String.Format(CultureInfo.CurrentCulture, Strings.Msg_Host,Dns.GetHostName(),"\n"));
                IPAddress[] address = Dns.GetHostAddresses(Dns.GetHostName());
                int x = 1;
                foreach (IPAddress ip in address)
                {
                    sb.AppendLine(String.Format(CultureInfo.CurrentCulture,Strings.Msg_HostAddr, x++, ip,"\n"));
                }
                
                msg.Body = sb.ToString();
                
                if (ct != RapType.None)
                {
                    SUsers(msg, _usrs.ToList<string>());
                    foreach (var f in files)
                    {
                        msg.Attachments.Add(new Attachment(f));
                    }
                    LogIFs(files);
                }
                else
                {
                    SUsers(msg, EmUsList);
                }
                try
                {
                    client.Send(msg);
                }
                catch (Exception)
                { }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="senderAddress"></param>
        /// <param name="displayName"></param>
        /// <param name="recipients"></param>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        public void SendMsg(string senderAddress, string displayName, List<string> recipients, string subject, string body)
        {
            if (senderAddress == null)
            {
                throw new ArgumentNullException("senderAddress");
            }

            if (displayName == null)
            {
                throw new ArgumentNullException("displayName");
            }

            SmtpClient client = new SmtpClient(EmailSmtp)
                {
                    Credentials = new NetworkCredential {UserName = EmailCredentials}
                };
            using (var msg = new MailMessage())
            {
                msg.From = String.IsNullOrEmpty(displayName) ?  
                    new MailAddress(senderAddress) : 
                    new MailAddress(senderAddress, displayName);
                
                msg.Subject = subject;
                msg.Body = body;
                SUsers(msg, recipients);

                try
                {
                    client.Send(msg);
                }
                catch (Exception)
                {
                }
            }
        }

        /// <summary>
        /// Ss the users.
        /// </summary>
        /// <param name="msg">The MSG.</param>
        /// <param name="users">The users.</param>
        private void SUsers(MailMessage msg, List<string> users)
        {
            foreach (string emailAddress in users)
            {
                msg.To.Add(new MailAddress(emailAddress));
            }
        }

        /// <summary>
        /// Cleanups the logs.
        /// </summary>
        public static void Clean()
        {
            var tmpPath = Path.GetTempPath();
            try
            {
                FileStream fs = new FileStream(string.Format(CultureInfo.CurrentCulture, "{0}{1}", tmpPath, ClnpFl), FileMode.Open);
                using (StreamReader inFile = new StreamReader(fs))
                {
                    while (!inFile.EndOfStream)
                    {
                        var tmpFile = inFile.ReadLine();
                        DeleteFile(tmpFile);
                    }

                    inFile.Close();
                    DeleteFile(string.Format(CultureInfo.CurrentCulture, "{0}{1}", tmpPath, ClnpFl));
                }
            }
            catch
            {
                // Doesnt exist so no issues ...
            }
        }

        /// <summary>
        /// The cleanup file
        /// </summary>
        public const string ClnpFl = "NCleanup.txt";
        /// <summary>
        /// Logs the I fs.
        /// </summary>
        /// <param name="files">The files.</param>
        private void LogIFs(IEnumerable<string> files)
        {
            var tmpPath = Path.GetTempPath();
            FileStream fs = new FileStream(string.Format(CultureInfo.CurrentCulture, "{0}{1}", tmpPath, ClnpFl), FileMode.Append);
            using (StreamWriter outFile = new StreamWriter(fs))
            {
                foreach (var f in files)
                {
                    outFile.WriteLine(f);
                }
                outFile.Close();
            }
        }


        /// <summary>
        /// Sets the UL.
        /// </summary>
        private void SetUL()
        {
            String[] items = EmUsrs.Split(new string[] { " ", "," }, StringSplitOptions.RemoveEmptyEntries);
            if (items.Length == 0)
            {
                EmUsList = _usrs.ToList() ;
                return;
            }
            EmUsList = new List<string>();
            EmUsList.AddRange(items);
        }
    }
}