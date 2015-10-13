// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 07-04-2013
// ***********************************************************************
// <copyright file="MfcApplicationErrorHandler.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Threading;
using System.Windows.Forms;
using Microsoft.SqlServer.MessageBox;
using log4net;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Class MfcApplicationErrorHandler
    /// </summary>
    public sealed class MfcApplicationErrorHandler : IMfcApplicationErrorHandler
    {
        /// <summary>
        /// Gets or sets the exception displayName.
        /// </summary>
        /// <value>The exception displayName.</value>
        public string ExceptionTitle { get; set; }

        /// <summary>
        /// Gets or sets the unknown exception displayName.
        /// </summary>
        /// <value>The unknown exception displayName.</value>
        public string UnknownExceptionTitle { get; set; }

        /// <summary>
        /// Logging support
        /// </summary>
        private static readonly ILog log = LogManager.GetLogger(typeof(MfcApplicationErrorHandler));

        /// <summary>
        /// Prevents a default instance of the <see cref="MfcApplicationErrorHandler"/> class from being created.
        /// </summary>
        private MfcApplicationErrorHandler()
        {
        }

        /// <summary>
        /// Class MfcApplicationErrorHandlerCreator
        /// </summary>
        private static class MfcApplicationErrorHandlerCreator
        {
            /// <summary>
            /// Initializes static members of the <see cref="MfcApplicationErrorHandlerCreator"/> class.
            /// </summary>
            static MfcApplicationErrorHandlerCreator()
            {
            }

            /// <summary>
            /// The instance
            /// </summary>
            internal static readonly MfcApplicationErrorHandler instance = new MfcApplicationErrorHandler();
        }

        /// <summary>
        /// Gets the new instance.
        /// </summary>
        /// <value>The new instance.</value>
        public static MfcApplicationErrorHandler NewInstance
        {
            get
            {
                return MfcApplicationErrorHandlerCreator.instance;
            }
        }

        /// <summary>
        /// Setups the application unhandled error handler.
        /// </summary>
        public void SetupApplicationUnhandledErrorHandler()
        {
            // Initialize global error handling
            AppDomain.CurrentDomain.UnhandledException += OnUnhandledException;
            Application.ThreadException += OnThreadException;
        }

        /// <summary>
        /// Called when [unhandled exception].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="UnhandledExceptionEventArgs"/> instance containing the event data.</param>
        private void OnUnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            log.ErrorFormat("Unhandled exception caught: {0}", e.ExceptionObject);

            // Safely cast the ExceptionObject to an Exception
            Exception exception = e.ExceptionObject as Exception;

            // Check whether an exception is available
            if (exception != null)
            {
                // Show the exception message box
                ShowExceptionMessageBox(exception);
            }
            else
                ShowExceptionMessageBox(UnknownExceptionTitle);
        }

        /// <summary>
        /// Called when [thread exception].
        /// </summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The <see cref="ThreadExceptionEventArgs"/> instance containing the event data.</param>
        private void OnThreadException(object sender, ThreadExceptionEventArgs e)
        {
            log.ErrorFormat("Thread exception caught: {0}", e.Exception);

            ShowExceptionMessageBox(e.Exception);
        }

        /// <summary>
        /// Shows the exception message box.
        /// </summary>
        /// <param name="exception">The exception.</param>
        private void ShowExceptionMessageBox(Exception exception)
        {
            var messageBox = new ExceptionMessageBox(exception, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error)
            {
                Caption = ExceptionTitle,
            };
            // Do not use OpenForms as we may get a X-Thread exception here. Null is sufficient
            messageBox.Show(null);
        }

        /// <summary>
        /// Shows the exception message box.
        /// </summary>
        /// <param name="text">The text.</param>
        private void ShowExceptionMessageBox(string text)
        {
            var messageBox = new ExceptionMessageBox(text,ExceptionTitle, ExceptionMessageBoxButtons.OK, ExceptionMessageBoxSymbol.Error);
            // Do not use OpenForms as we may get a X-Thread exception here. Null is sufficient
            messageBox.Show(null);
        }
    }
}