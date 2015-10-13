// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 10-08-2013
//
// Last Modified By : bethunro
// Last Modified On : 10-08-2013
// ***********************************************************************
// <copyright file="IMfcApplicationErrorHandler.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Interface IMfcApplicationErrorHandler
    /// </summary>
    public interface IMfcApplicationErrorHandler
    {
        /// <summary>
        /// Gets or sets the exception title.
        /// </summary>
        /// <value>The exception title.</value>
        string ExceptionTitle { get; set; }

        /// <summary>
        /// Gets or sets the unknown exception title.
        /// </summary>
        /// <value>The unknown exception title.</value>
        string UnknownExceptionTitle { get; set; }

        /// <summary>
        /// Setups the application unhandled error handler.
        /// </summary>
        void SetupApplicationUnhandledErrorHandler();
    }
}