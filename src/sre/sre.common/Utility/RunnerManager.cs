// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-29-2013
//
// Last Modified By : bethunro
// Last Modified On : 08-05-2013
// ***********************************************************************
// <copyright file="RunnerManager.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;
using System.Reflection;
using Ubs.Collateral.Sre.Common.Spring;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Class RunnerManager
    /// </summary>
    public class RunnerManager : IRunnerManager
    {
        /// <summary>
        /// Enum NitroLocation
        /// </summary>
        public enum NitroLocation
        {
            /// <summary>
            /// The default
            /// </summary>
            [Description("Europe")]
            Default,
            /// <summary>
            /// The europe
            /// </summary>
            [Description("Europe")]
            Europe,
            /// <summary>
            /// The united states
            /// </summary>
            [Description("US")]
            UnitedStates
        };

        /// <summary>
        /// The plugins path arg
        /// </summary>
        private const string PluginsPathArg = "pluginspath";
        /// <summary>
        /// The plugins path minus arg
        /// </summary>
        private const string PluginsPathMinusArg = "-pluginspath";
        /// <summary>
        /// The auto connect arg
        /// </summary>
        private const string AutoConnectArg = "autoconnect";
        /// <summary>
        /// The auto connect minus arg
        /// </summary>
        private const string AutoConnectMinusArg = "-autoconnect";
        /// <summary>
        /// The env path arg
        /// </summary>
        private const string EnvPathArg = "envpath";
        /// <summary>
        /// The env path minus arg
        /// </summary>
        private const string EnvPathMinusArg = "-envpath";
        /// <summary>
        /// The commons path arg
        /// </summary>
        private const string CommonsPathArg = "commonfiles";
        /// <summary>
        /// The commons path minus arg
        /// </summary>
        private const string CommonsPathMinusArg = "-commonfiles";

        /// <summary>
        /// The addons path arg
        /// </summary>
        private const string AddonsPathArg = "addonspath";
        /// <summary>
        /// The addons path minus arg
        /// </summary>
        private const string AddonsPathMinusArg = "-addonspath";

        /// <summary>
        /// The nitro location arg
        /// </summary>
        private const string NitroLocationArg = "location";
        /// <summary>
        /// The nitro location minus arg
        /// </summary>
        private const string NitroLocationMinusArg = "-location";

        /// <summary>
        /// Gets or sets the nitro run mode.
        /// </summary>
        /// <value>The nitro run mode.</value>
        public NitroLocation NitroRunMode { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is running nitro in united states.
        /// </summary>
        /// <value><c>true</c> if this instance is running nitro in united states; otherwise, <c>false</c>.</value>
        public bool IsRunningNitroInUnitedStates
        {
            get
            {
                return NitroRunMode == NitroLocation.UnitedStates;
            }
            private set
            {
            }
        }

        /// <summary>
        /// Gets a value indicating whether this instance is running nitro in europe.
        /// </summary>
        /// <value><c>true</c> if this instance is running nitro in europe; otherwise, <c>false</c>.</value>
        public bool IsRunningNitroInEurope
        {
            get
            {
                return (NitroRunMode == NitroLocation.Europe) | (NitroRunMode == NitroLocation.Default);
            }
            private set
            {
            }
        }

        /// <summary>
        /// Gets or sets the nitro run mode as string.
        /// </summary>
        /// <value>The nitro run mode as string.</value>
        public string NitroRunModeAsString { get; set; }

        /// <summary>
        /// Gets or sets the default env.
        /// </summary>
        /// <value>The default env.</value>
        public string DefaultEnv { get; set; }

        /// <summary>
        /// Gets or sets the plugins path.
        /// </summary>
        /// <value>The plugins path.</value>
        public string PluginsPath { get; set; }

        /// <summary>
        /// Gets or sets the addons path.
        /// </summary>
        /// <value>The addons path.</value>
        public string AddonsPath { get; set; }

        /// <summary>
        /// Gets or sets the commons path.
        /// </summary>
        /// <value>The commons path.</value>
        public string CommonsPath { get; set; }

        /// <summary>
        /// Gets or sets the runtime environment.
        /// </summary>
        /// <value>The runtime environment.</value>
        public string RuntimeEnvironment { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether [auto connect].
        /// </summary>
        /// <value><c>true</c> if [auto connect]; otherwise, <c>false</c>.</value>
        public bool AutoConnect { get; set; }

        /// <summary>
        /// Gets a value indicating whether this instance is valid environment.
        /// </summary>
        /// <value><c>true</c> if this instance is valid environment; otherwise, <c>false</c>.</value>
        public bool IsValidEnvironment { get; private set; }

        /// <summary>
        /// Uses the supplied default env.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool UseSuppliedDefaultEnv()
        {
            return !String.IsNullOrEmpty(DefaultEnv);
        }

        /// <summary>
        /// Gets the version info.
        /// </summary>
        /// <value>The version info.</value>
        public static System.Version VersionInfo { get; private set; }

        /// <summary>
        /// Uses the supplied plugins path.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool UseSuppliedPluginsPath()
        {
            return !String.IsNullOrEmpty(PluginsPath);
        }

        /// <summary>
        /// Uses the supplied addons path.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool UseSuppliedAddonsPath()
        {
            return !String.IsNullOrEmpty(AddonsPath);
        }

        /// <summary>
        /// Uses the supplied commons path.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool UseSuppliedCommonsPath()
        {
            return !String.IsNullOrEmpty(CommonsPath);
        }

        /// <summary>
        /// Uses the supplied env path.
        /// </summary>
        /// <returns><c>true</c> if XXXX, <c>false</c> otherwise</returns>
        public bool UseSuppliedEnvPath()
        {
            return !String.IsNullOrEmpty(RuntimeEnvironment);
        }

        /// <summary>
        /// Gets or sets a value indicating whether [use supplied auto connect arg].
        /// </summary>
        /// <value><c>true</c> if [use supplied auto connect arg]; otherwise, <c>false</c>.</value>
        public bool UseSuppliedAutoConnectArg { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="RunnerManager" /> class.
        /// </summary>
        /// <param name="app">The app.</param>
        public RunnerManager()
        {
            DefaultEnv = MfcSpringManagerConstants.UatEnvironment;
            NitroRunMode = NitroLocation.Default;
            NitroRunModeAsString = MfcEnumUtility.Description(NitroRunMode);
            VersionInfo = Assembly.GetExecutingAssembly().GetName().Version;
        }

        /// <summary>
        /// The token
        /// </summary>
        private const char Token = '=';
        /// <summary>
        /// The kv P length
        /// </summary>
        private const int KvPLength = 2;
        /// <summary>
        /// The value item
        /// </summary>
        private const int ValueItem = 1;
        /// <summary>
        /// The key item
        /// </summary>
        private const int KeyItem = 0;

        /// <summary>
        /// Processes the command line.
        /// </summary>
        public void ProcessCommandLine()
        {
            string[] args = Environment.GetCommandLineArgs();
            foreach (string item in args)
            {
                string[] keyAndValue = item.Split(new char[] { Token }, StringSplitOptions.RemoveEmptyEntries);
                if (keyAndValue.Length == KvPLength)
                {
                    switch ((keyAndValue[KeyItem].ToLowerInvariant()))
                    {
                        case NitroLocationArg:
                        case NitroLocationMinusArg:
                            NitroLocation location = MfcEnumUtility.ParseByDescription<NitroLocation>(keyAndValue[ValueItem]);
                            NitroRunMode = location;
                            NitroRunModeAsString = MfcEnumUtility.Description(location);

                            break;
                        case PluginsPathArg:
                        case PluginsPathMinusArg:
                            PluginsPath = keyAndValue[ValueItem];
                            break;
                        case AddonsPathArg:
                        case AddonsPathMinusArg:
                            AddonsPath = keyAndValue[ValueItem];
                            break;
                        case CommonsPathArg:
                        case CommonsPathMinusArg:
                            CommonsPath = keyAndValue[ValueItem];
                            break;
                        case EnvPathArg:
                        case EnvPathMinusArg:
                            IsValidEnvironment = false;
                            if (MfcSpringManager.ValidEnvString(keyAndValue[ValueItem]))
                            {
                                RuntimeEnvironment = keyAndValue[ValueItem];
                                DefaultEnv = RuntimeEnvironment;
                                IsValidEnvironment = true;
                            }
                            break;
                        case AutoConnectArg:
                        case AutoConnectMinusArg:
                            bool autoconnect;
                            if (!Boolean.TryParse(keyAndValue[ValueItem], out autoconnect))
                            {
                                UseSuppliedAutoConnectArg = false;
                            }
                            else
                            {
                                UseSuppliedAutoConnectArg = autoconnect;
                            }
                            break;
                        default:
                            // Ignore ////
                            break;
                    }
                }
            }
        }
    }
}