// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 07-04-2013
// ***********************************************************************
// <copyright file="MfcSpringManagerConstants.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************


using Ubs.Collateral.Sre.Common.Resources;

namespace Ubs.Collateral.Sre.Common.Spring
{
    /// <summary>
    /// Class MfcSpringManagerConstants
    /// </summary>
    public class MfcSpringManagerConstants : IMfcSpringManagerConstants
    {
        /// <summary>
        /// Dev environment
        /// </summary>
        public static readonly string DevEnvironment = Strings.Login_DevEnvironment;

        /// <summary>
        /// DevMode environment
        /// </summary>
        public static readonly string DevMode = Strings.Login_DevMode;

        /// <summary>
        /// Uat environment
        /// </summary>
        public static readonly string UatEnvironment = Strings.Login_UatEnvironment;

        /// <summary>
        /// Prod environment
        /// </summary>
        public static readonly string ProdEnvironment = Strings.Login_ProdEnvironment;

        /// <summary>
        /// DevOs environment
        /// </summary>
        public static readonly string DevOSEnvironment = Strings.Login_DevOffshoreEnvironment;

        /// <summary>
        /// Resource for EnvKey
        /// </summary>
        public static readonly string EnvironmentKey = Strings.Login_EnvironmentKey;

        /// <summary>
        /// Resource for UIDKey
        /// </summary>
        public static readonly string UserIdentifierKey = Strings.Login_UIDKey;

        /// <summary>
        /// The no user
        /// </summary>
        public static readonly string NoUser = Strings.Login_NotLoggedIn;
    }
}
