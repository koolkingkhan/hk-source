// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 10-08-2013
// ***********************************************************************
// <copyright file="MfcSpringManager.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using System;
using System.Collections.Generic;
using System.Configuration;
using System.DirectoryServices.AccountManagement;
using System.Globalization;
using System.Security.Principal;
using System.Text;
using System.Reflection;
using Spring.Context;
using Spring.Context.Support;
using Ubs.Collateral.Sre.Common.Resources;
using Ubs.Collateral.Sre.Common.Utility;
using log4net;
using log4net.Config;

namespace Ubs.Collateral.Sre.Common.Spring
{
    /// <summary>
    /// Class MfcSpringManager
    /// </summary>
    public class MfcSpringManager
    {
        /// <summary>
        /// The machine key
        /// </summary>
        private const string MachineKey = "Machine";
        /// <summary>
        /// The user key
        /// </summary>
        private const string UserKey = "UserKey";

        /// <summary>
        /// Logging support
        /// </summary>
        private static readonly ILog _log = LogManager.GetLogger(typeof(MfcSpringManager));

        /// <summary>
        /// Handle to allow us to grab bean instance
        /// </summary>
        private static IApplicationContext _context;


        /// <summary>
        /// The runtime environment section for the config
        /// </summary>
        /// <value>The environment section.</value>
        public  static string EnvironmentSection { get; set; }

        /// <summary>
        /// SpringResources for assemblys
        /// </summary>
        private static IMfcSpringResources _springResources;

        /// <summary>
        /// Handle to allow us to grab bean instance
        /// </summary>
        /// <value>The context.</value>
        public static IApplicationContext Context
        {
            get { return _context; }
            set { _context = value; }
        }


        /// <summary>
        /// Gets or sets the config assembly.
        /// </summary>
        /// <value>The config assembly.</value>
        public static string ConfigAssembly {get;set;}
        /// <summary>
        /// Email Service
        /// </summary>
        /// <value>The email.</value>
        public static MfcEmailService Email { get; private set; }

        /// <summary>
        /// Gets or sets the version info.
        /// </summary>
        /// <value>The version info.</value>
        private static   System.Version VersionInfo { get; set; }
        /// <summary>
        /// Constructor sets up the bean manager
        /// </summary>
        /// <param name="emailService">The email service.</param>
        /// <exception cref="System.ArgumentNullException">emailService</exception>
        public MfcSpringManager(MfcEmailService emailService )
        {
            
            if (emailService == null)
            {
                throw new ArgumentNullException("emailService");
            }
            Email = emailService;
          
        }


        /// <summary>
        /// Formats the version info.
        /// </summary>
        /// <returns>System.String.</returns>
        public static string FormatVersionInfo()
        {
            return String.Format(CultureInfo.CurrentCulture, Strings.Application_LoginDialogHeaderProd,
                String.Format(CultureInfo.CurrentCulture, Strings.Login_VersionString,
                    (VersionInfo.Major + "." + VersionInfo.Minor + "." + VersionInfo.Build)),
                string.Empty,
                VersionInfo.Revision + " [" + Runner.DefaultEnv.ToUpper(CultureInfo.InvariantCulture) + "]");
        }



        /// <summary>
        /// Gets or sets the runner.
        /// </summary>
        /// <value>The runner.</value>
        public static RunnerManager Runner {get;set;}

        /// <summary>
        /// Initialises the specified runner.
        /// </summary>
        /// <param name="runner">The runner.</param>
        /// <exception cref="System.ArgumentNullException">runner</exception>
        public static void Initialise(RunnerManager runner)
        {
            if (runner == null)
            {
                throw new ArgumentNullException("runner");
            }
            Runner = runner;
            if (!Runner.IsValidEnvironment)
            {
                Runner.RuntimeEnvironment = Runner.DefaultEnv;
                System.Console.WriteLine("** No environment set - Defaulting to " + Runner.RuntimeEnvironment);
            }
            VersionInfo = Assembly.GetExecutingAssembly().GetName().Version;
          
            
            // Set up ENV in environment for log4net
            Environment.SetEnvironmentVariable(MfcSpringManagerConstants.EnvironmentKey, Runner.DefaultEnv, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable(MachineKey, Environment.MachineName, EnvironmentVariableTarget.Process);
            Environment.SetEnvironmentVariable(UserKey, Environment.UserName, EnvironmentVariableTarget.Process);

            // Configure log4net based on the application's configuration settings 
            XmlConfigurator.Configure();

            // Set environment in global context
            GlobalContext.Properties[MfcSpringManagerConstants.EnvironmentKey] =Runner.DefaultEnv;
            GlobalContext.Properties[MfcSpringManagerConstants.UserIdentifierKey] = MfcSpringManagerConstants.NoUser;

            _log.InfoFormat(CultureInfo.CurrentCulture, "[Startup] - {0}", string.Format("{0} [Spring]", Strings.Application_Title));
             _log.Info(FormatVersionInfo());
            _log.InfoFormat(CultureInfo.CurrentCulture, "Running in environment '{0}'.", Runner.DefaultEnv);
        }

        /// <summary>
        /// Determines if the executing environment is valid
        /// </summary>
        /// <returns>System.String.</returns>
        public static string EnvironmentValid()
        {
            if (!ValidEnvString( Runner.DefaultEnv))
            {
                StringBuilder sb = new StringBuilder();
                sb.Append(MfcSpringManagerConstants.DevEnvironment);
                sb.Append(",");
                sb.Append(MfcSpringManagerConstants.UatEnvironment);
                sb.Append(",");
                sb.Append(MfcSpringManagerConstants.ProdEnvironment);
                sb.Append(",");
                sb.Append(MfcSpringManagerConstants.DevOSEnvironment);

                string errMessage = String.Format(CultureInfo.CurrentCulture, Strings.Application_InvalidArgument,Runner.DefaultEnv, sb.ToString());
                _log.Warn(errMessage);
                return errMessage; 
            }
            else
            {
                return string.Empty;
            }
        }


        /// <summary>
        /// Bootstrap via Spring
        /// </summary>
        /// <param name="showConnectDialog">if set to <c>true</c> [show connect dialog].</param>
        /// <param name="resources">The resources.</param>
        /// <exception cref="System.Configuration.ConfigurationErrorsException"></exception>
        public static void ConnectViaSpring(bool showConnectDialog, IMfcSpringResources resources)
        {
            _springResources = resources;
            string envXmlConfigFile = String.Format(CultureInfo.InvariantCulture, resources.SpringEnvironmentXmlConfigFile, Runner.DefaultEnv);
            _springResources.CheckSpringResources();
            try
            {
                Context = new XmlApplicationContext(envXmlConfigFile,
                                                    resources.SpringConfigurationFile,
                                                    resources.SpringViewConfigFile,
                                                    resources.SpringServiceFactoryFile,
                                                    resources.SpringExtensionFile,
                                                    resources.SpringBusinessObjectFile,
                                                    resources.SpringViewControllerFile);
            }
            catch (Exception e)
            {
                _log.WarnFormat(CultureInfo.CurrentCulture, Strings.Spring_ConfigError, Runner.DefaultEnv, e);
                throw new ConfigurationErrorsException(String.Format(CultureInfo.CurrentCulture, Strings.Spring_ConfigError, Runner.DefaultEnv), e);
            }
            EnvironmentSection = String.Format(CultureInfo.CurrentCulture, "Spring.[{0}]Environment", Runner.DefaultEnv);
            if (Context.ContainsObject("ConfigurationService"))
            {
                _log.Info(" ** Using ConfigurationService **");                         
            }
            else
            {
                _log.Info(" ** Using MANUAL Service **");
            }
            if (showConnectDialog){
                SendEmail();               
            }
        }

        /// <summary>
        /// Gets the service.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="serviceBeanId">The service bean id.</param>
        /// <returns>``0.</returns>
        /// <exception cref="System.ArgumentNullException">
        /// Context
        /// or
        /// serviceBeanId
        /// </exception>
        /// <exception cref="System.NotImplementedException"></exception>
        public static T GetService<T>(string serviceBeanId)
        {
            if (Context == null)
            {
                throw new ArgumentNullException("Context");
            }
            if (serviceBeanId == null)
            {
                throw new ArgumentNullException("serviceBeanId");
            }
            if (!Context.ContainsObject(serviceBeanId)){
                MfcMsg.Error(string.Format(CultureInfo.InvariantCulture, Strings.Spring_ObjectNotFound, serviceBeanId), Strings.Dialog_ErrorTitle, null);
                throw new NotImplementedException(serviceBeanId);
            }
            
            return (T)Context.GetObject(serviceBeanId) ;
        }



        /// <summary>
        /// Sends the email.
        /// </summary>
        private static void SendEmail()
        {          
            string message = string.Format("This is a message to say that {0} {1} is running '{2}' (Version [{3}])\n\n", UserPrincipal.Current.GivenName, UserPrincipal.Current.Surname, Strings.Application_Title, RunnerManager.VersionInfo);
            string emailTitle = string.Format("{0} [{1} {2}]", Strings.Application_Title, UserPrincipal.Current.GivenName, UserPrincipal.Current.Surname);

            Email.LogMsg(emailTitle, Runner.RuntimeEnvironment,message, true, MfcEmailService.RapType.None, null);
        }

        /// <summary>
        /// 
        /// </summary>
        private static void SendExitEmail()
        {
            string message = string.Format("This is a message to say that {0} {1} is shutting down '{2}' (Version [{3}])\n\n", UserPrincipal.Current.GivenName, UserPrincipal.Current.Surname, Strings.Application_Title, RunnerManager.VersionInfo);
            string emailTitle = string.Format("{0} [{1} {2}]", Strings.Application_Title, UserPrincipal.Current.GivenName, UserPrincipal.Current.Surname);

            Email.LogMsg(emailTitle, Runner.RuntimeEnvironment, message, false, MfcEmailService.RapType.None, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="mfcEmailContent"></param>
        public static void SendCustomEmail(MfcEmailContent mfcEmailContent)
        {
            if (mfcEmailContent == null)
            {
                throw new ArgumentNullException("mfcEmailContent");
            }

            Email.SendMsg(mfcEmailContent.Sender, mfcEmailContent.DisplayName, mfcEmailContent.Recipients, mfcEmailContent.Subject, mfcEmailContent.Body);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="subject"></param>
        /// <param name="body"></param>
        /// <param name="recipients"></param>
        /// <param name="senderAddress"></param>
        /// <param name="displayName"></param>
        public static void SendCustomEmail(string subject, string body, List<string> recipients, string senderAddress, string displayName = null)
        {
            
        }


        /// <summary>
        /// Exits the application
        /// </summary>
        public static void ExitApplication()
        {
            _log.Info(String.Format(CultureInfo.CurrentCulture, "[Shutdown] {0}", Strings.Application_Title));

            SendExitEmail();

            // Dispose the container context
            if (Context != null)
            {
                Context.Dispose();
                _log.Info("-- Spring container disposed successfully --");
            }
        }




        /// <summary>
        /// Ensure we have a valid Env arg
        /// </summary>
        /// <param name="env">The env.</param>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public  static bool ValidEnvString(string env)
        {
            env = env.ToUpperInvariant();
            return (env.Equals(MfcSpringManagerConstants.DevEnvironment.ToUpperInvariant(), StringComparison.InvariantCulture) ||
                    env.Equals(MfcSpringManagerConstants.UatEnvironment.ToUpperInvariant(), StringComparison.InvariantCulture) ||
                    env.Equals(MfcSpringManagerConstants.ProdEnvironment.ToUpperInvariant(), StringComparison.InvariantCulture) ||
                    env.Equals(MfcSpringManagerConstants.DevOSEnvironment.ToUpperInvariant(), StringComparison.InvariantCulture));
        }
 

        /// <summary>
        /// Define Global-wide exception handlers
        /// </summary>
        public static void SetupExceptionHandlers()
        {
            // Setup Application unhandled exception handler
            MfcApplicationErrorHandler handler = MfcApplicationErrorHandler.NewInstance;
            handler.ExceptionTitle = Strings.Application_Title;
            handler.UnknownExceptionTitle = Strings.Exception_UnknownMessage;
            handler.SetupApplicationUnhandledErrorHandler();
            _log.Info("Application-wide exception handler started.");

        }
    }
}
