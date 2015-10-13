 

using System;

namespace Ubs.Collateral.Sre.Common.Spring
{
    public class MfcSpringResources : IMfcSpringResources
    {

        private string _springEnvironmentXmlConfigFile;
        private string _springViewConfigFile;
        private string _springConfigurationFile;
        private string _springServiceFactoryFile;
        private string _springExtensionFile;
        private string _springBusinessObjectFile;
        private string _springViewControllerFile;
        private string _writeableConfigFile;

        public MfcSpringResources(string springEnvironmentXmlConfigFile, 
            string springViewConfigFile, 
            string springConfigurationFile, 
            string springServiceFactoryFile, 
            string springExtensionFile, 
            string springBusinessObjectFile, 
            string springViewControllerFile, 
            string writeableConfigFile)
        {
            this._springEnvironmentXmlConfigFile = springEnvironmentXmlConfigFile;
            this._springViewConfigFile = springViewConfigFile;
            this._springConfigurationFile = springConfigurationFile;
            this._springServiceFactoryFile = springServiceFactoryFile;
            this._springExtensionFile = springExtensionFile;
            this._springBusinessObjectFile = springBusinessObjectFile;
            this._springViewControllerFile = springViewControllerFile;
            this._writeableConfigFile = writeableConfigFile;
        }

        private void CheckForNull(string arg)
        {
            if (arg == null)
            {
                throw new ArgumentNullException(arg);
            }
        }

        public void CheckSpringResources()
        {
        CheckForNull(_springEnvironmentXmlConfigFile);
        CheckForNull(_springViewConfigFile);
        CheckForNull(_springConfigurationFile);
        CheckForNull(_springServiceFactoryFile);
        CheckForNull( _springExtensionFile);
        CheckForNull(_springBusinessObjectFile);
        CheckForNull(_springViewControllerFile);
        CheckForNull(_writeableConfigFile);	
        }
    
        public string SpringEnvironmentXmlConfigFile
        {
            get
            {
                return _springEnvironmentXmlConfigFile;
            }
            set
            {
                _springEnvironmentXmlConfigFile = value;
            }
        }

        public string SpringViewConfigFile
        {
            get
            {
                return _springViewConfigFile;
            }
            set
            {
                _springViewConfigFile = value;
            }
        }

        public string SpringConfigurationFile
        {
            get
            {
                return _springConfigurationFile;
            }
            set
            {
                _springConfigurationFile = value;
            }
        }

        public string SpringServiceFactoryFile
        {
            get
            {
                return _springServiceFactoryFile;
            }
            set
            {
                _springServiceFactoryFile = value;
            }
        }

        public string SpringExtensionFile
        {
            get
            {
                return _springExtensionFile;
            }
            set
            {
                _springExtensionFile = value;
            }
        }

        public string SpringBusinessObjectFile
        {
            get
            {
                return _springBusinessObjectFile;
            }
            set
            {
                _springBusinessObjectFile = value;
            }
        }

        public string SpringViewControllerFile
        {
            get
            {
                return _springViewControllerFile;
            }
            set
            {
                _springViewControllerFile = value;
            }
        }

        public string WriteableConfigFile
        {
            get
            {
                return _writeableConfigFile;
            }
            set
            {
                _writeableConfigFile = value;
            }
        }
    }
}
