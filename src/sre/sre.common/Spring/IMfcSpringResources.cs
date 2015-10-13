// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 07-04-2013
// ***********************************************************************
// <copyright file="IMfcSpringResources.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Ubs.Collateral.Sre.Common.Spring
{
    /// <summary>
    /// Interface IMfcSpringResources
    /// </summary>
    public interface IMfcSpringResources
    {
        /// <summary>
        /// Checks the spring resources.
        /// </summary>
        void CheckSpringResources();

        /// <summary>
        /// Gets or sets the spring environment XML config file.
        /// </summary>
        /// <value>The spring environment XML config file.</value>
        string SpringEnvironmentXmlConfigFile { get; set; }

        /// <summary>
        /// Gets or sets the spring view config file.
        /// </summary>
        /// <value>The spring view config file.</value>
        string SpringViewConfigFile { get; set; }

        /// <summary>
        /// Gets or sets the spring configuration file.
        /// </summary>
        /// <value>The spring configuration file.</value>
        string SpringConfigurationFile { get; set; }

        /// <summary>
        /// Gets or sets the spring service factory file.
        /// </summary>
        /// <value>The spring service factory file.</value>
        string SpringServiceFactoryFile { get; set; }

        /// <summary>
        /// Gets or sets the spring extension file.
        /// </summary>
        /// <value>The spring extension file.</value>
        string SpringExtensionFile { get; set; }

        /// <summary>
        /// Gets or sets the spring business object file.
        /// </summary>
        /// <value>The spring business object file.</value>
        string SpringBusinessObjectFile { get; set; }

        /// <summary>
        /// Gets or sets the spring view controller file.
        /// </summary>
        /// <value>The spring view controller file.</value>
        string SpringViewControllerFile { get; set; }

        /// <summary>
        /// Gets or sets the writeable config file.
        /// </summary>
        /// <value>The writeable config file.</value>
        string WriteableConfigFile { get; set; }
    }
}