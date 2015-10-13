//***********************************************************************
// Assembly         : mdn.ui
// Author           : Rohan Bethune
// Created          : 01-10-2012
//
// Last Modified By : Rohan Bethune
// Last Modified On : 01-13-2012
// Description      : 
//
// Copyright        : (c) UBS AG. All rights reserved.
//***********************************************************************

using System;
using System.Windows.Forms;
using Ubs.Collateral.Mdn.Gui.Utility;
using Ubs.Collateral.Mdn.Mfc.Config;
using Ubs.Collateral.Mdn.Mfc.Preferences;
using Ubs.Collateral.Mdn.Mfc.Resources;
using Ubs.Collateral.Mdn.Mfc.Spring;
using Ubs.Collateral.Mdn.Mfc.Ui.Utility;
using Ubs.Collateral.Mdn.Mfc.Utility;


namespace mdn.TestUi
{
    /// <summary>
    /// 
    /// </summary>
    /// <remarks></remarks>
    static class Runme2
    {
        /// <summary>
        /// Environment spring config 
        /// </summary>
        private static string _springEnvironmentXmlConfigFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.{0}.xml";
        /// <summary>
        /// View wiring
        /// </summary>
        private static string _springViewConfigFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.Views.xml";
        /// <summary>
        /// Basic Spring config
        /// </summary>
        private static string _springConfigurationFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.xml";
        /// <summary>
        /// Spring factories
        /// </summary>
        private static string _springServiceFactoryFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.Factories.xml";
        /// <summary>
        /// Property configurer 
        /// </summary>
        private static string _springExtensionFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.Extensions.xml";
        /// <summary>
        ///  BO's
        /// </summary>
        private static string _springBusinessObjectFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.BusinessObject.xml";
        /// <summary>
        /// Controllers 
        /// </summary>
        private static string _springViewControllerFile = "assembly://mdn.config/Ubs.Collateral.Mdn.Config/Configuration.Spring.Spring.Views.Controllers.xml";


        private static string _writeableConfigFile = "Ubs.Collateral.Mdn.Config.Configuration.Spring." + MfcControlSectionHandler.WritableFile;


        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        /// <param name="args">The args.</param>
        /// <remarks></remarks>
        [STAThread]
        static void Main(string[] args)
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MfcVersionInfo.ApplicationTitle = "Maelstrom.NET Client";
            MfcSpringManager.Initialise(args);
            string errMessage = MfcSpringManager.EnvironmentValid();
            if (errMessage.Length != 0)
            {
                MfcMsg.Error(errMessage, Strings.Dialog_ErrorTitle, null);
                MfcSpringManager.ExitApplication();
            }
            else
            {
                MfcSpringManager.SetupExceptionHandlers();
                IMfcSpringResources resources = new MfcSpringResources(_springEnvironmentXmlConfigFile, _springViewConfigFile, _springConfigurationFile, _springServiceFactoryFile, _springExtensionFile, _springBusinessObjectFile, _springViewControllerFile, _writeableConfigFile);
                MfcSpringManager.ConnectViaSpring(true, resources, new SchemaManager().RemovedSchemaProfiles, MfcPreferenceManager.RemoveGridStateTemplates, "MaelstromMainFormView");
            }

        }
    }
}
