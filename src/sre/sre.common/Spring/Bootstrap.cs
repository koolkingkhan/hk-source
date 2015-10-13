using Ubs.Collateral.Sre.Common.Utility;

namespace Ubs.Collateral.Sre.Common.Spring
{

    public class Bootstrap
    {
        /// <summary>
        /// Environment spring config 
        /// </summary>
        private static string _springEnvironmentXmlConfigFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.{0}.xml";
        /// <summary>
        /// View wiring
        /// </summary>
        private static string _springViewConfigFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.Views.xml";
        /// <summary>
        /// Basic Spring config
        /// </summary>
        private static string _springConfigurationFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.xml";
        /// <summary>
        /// Spring factories
        /// </summary>
        private static string _springServiceFactoryFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.Factories.xml";
        /// <summary>
        /// Property configurer 
        /// </summary>
        private static string _springExtensionFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.Extensions.xml";
        /// <summary>
        ///  BO's
        /// </summary>
        private static string _springBusinessObjectFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.BusinessObject.xml";
        /// <summary>
        /// Controllers 
        /// </summary>
        private static string _springViewControllerFile = "assembly://sre.common/Ubs.Collateral.Sre.Common/Configuration.Spring.Spring.Views.Controllers.xml";


        private static string _writeableConfigFile = "Ubs.Collateral.Sre.Common.Configuration.Spring.Writable.Config.xml";

        public IRunnerManager RunnerManager { get; private set; }

        public Bootstrap()
        {
            RunnerManager runner = new RunnerManager();
            runner.ProcessCommandLine();
            MfcSpringManager.Initialise(runner);
            RunnerManager = runner;


            MfcSpringManager.SetupExceptionHandlers();
            IMfcSpringResources resources = new MfcSpringResources(_springEnvironmentXmlConfigFile, _springViewConfigFile, _springConfigurationFile, _springServiceFactoryFile, _springExtensionFile, _springBusinessObjectFile, _springViewControllerFile, _writeableConfigFile);
            MfcSpringManager.ConnectViaSpring(true, resources);

        }

    }
      
}
