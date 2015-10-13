// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-04-2013
//
// Last Modified By : bethunro
// Last Modified On : 07-04-2013
// ***********************************************************************
// <copyright file="MfcMsg.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.Drawing;
using System.Windows.Forms;
using Syncfusion.Windows.Forms;
using Syncfusion.Windows.Forms.Tools;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Class MfcMsg
    /// </summary>
    public static class MfcMsg
    {
        /// <summary>
        /// The type of message
        /// </summary>
        public enum MessageType
        {
            /// <summary>
            /// The question message
            /// </summary>
            QuestionMessage,
            /// <summary>
            /// The warning message
            /// </summary>
            WarningMessage,
            /// <summary>
            /// The information message
            /// </summary>
            InformationMessage,
            /// <summary>
            /// The error message
            /// </summary>
            ErrorMessage
        }

        /// <summary>
        /// Questions the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The displayName.</param>
        /// <param name="parent">The parent.</param>
        /// <returns>DialogResult.</returns>
        public static DialogResult Question(string message, string title, Form parent)
        {
            SetTheme(parent, Color.Blue);
            return MessageBoxAdv.Show(message, title, MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
        }

        /// <summary>
        /// Errors the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The displayName.</param>
        /// <param name="parent">The parent.</param>
        public static void Error(string message, string title, Form parent)
        {
            SetTheme(parent, Color.Red);
            MessageBoxAdv.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// Warnings the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The displayName.</param>
        /// <param name="parent">The parent.</param>
        public static void Warning(string message, string title, Form parent)
        {
            SetTheme(parent, Color.LightSalmon);
            MessageBoxAdv.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        /// <summary>
        /// Infoes the specified message.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="title">The displayName.</param>
        /// <param name="parent">The parent.</param>
        public static void Info(string message, string title, Form parent)
        {
            SetTheme(parent, Color.Green);     
            MessageBoxAdv.Show(message, title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// Sets the theme.
        /// </summary>
        /// <param name="parent">The parent.</param>
        /// <param name="color">The color.</param>
        private static void SetTheme(Form parent, Color color)
        {
            if (parent == null)
            {
                parent = new Form { StartPosition = FormStartPosition.CenterScreen };
            }
            MessageBoxAdv.Office2007Theme = Office2007Theme.Managed;
            Office2007Colors.ApplyManagedColors(parent, color);            
        }



        /// <summary>
        /// Inputs the box.
        /// </summary>
        /// <param name="title">The displayName.</param>
        /// <param name="promptText">The prompt text.</param>
        /// <param name="checkBoxLabel">The check box label.</param>
        /// <param name="value">The value.</param>
        /// <param name="checkBoxChecked">The check box checked.</param>
        /// <returns>DialogResult.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static DialogResult InputBox(string title, string promptText, string checkBoxLabel, ref string value, ref bool? checkBoxChecked)
        {
            Office2007Form form = new Office2007Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            CheckBox checkBox = new CheckBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            checkBox.Text = checkBoxLabel;

            ImageList imageList = MfcApplicationImageControl.NewInstance.ApplicationImages16;
            string icon = MfcApplicationImageControl.NewInstance.SaveImage16String;

            if (!imageList.Images.ContainsKey(icon))
            {
                throw new NotImplementedException(string.Format("The key :{0} has not been implemented in MfcApplicationImageControl", icon));
            }

            form.Icon = MfcApplicationImageControl.NewInstance.GetIcon(imageList.Images[icon]);

            form.UseOffice2007SchemeBackColor = true;
            form.ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Blue;
            form.Text = title;
            label.Text = promptText;
            label.BackColor = Color.Transparent;
            checkBox.BackColor = Color.Transparent;
            textBox.Text = value;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 75, 75, 23);
            buttonCancel.SetBounds(309, 75, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            if (checkBoxChecked != null)
            {
                checkBox.Checked = checkBoxChecked.Value;
                checkBox.Anchor = checkBox.Anchor | AnchorStyles.Right;
                checkBox.SetBounds(12, 60, 372, 20);
                checkBox.AutoSize = true;
            }

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel, checkBox });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            checkBoxChecked = checkBox.Checked;

            return dialogResult;
        }

        /// <summary>
        /// Inputs the box.
        /// </summary>
        /// <param name="title">The displayName.</param>
        /// <param name="promptText">The prompt text.</param>
        /// <param name="value">The value.</param>
        /// <returns>DialogResult.</returns>
        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            bool? rv = default(bool?);
            return InputBox(title, promptText, null, ref value, ref rv);
        }

        /// <summary>
        /// Inputs the DDLB.
        /// </summary>
        /// <param name="title">The displayName.</param>
        /// <param name="promptText">The prompt text.</param>
        /// <param name="items">The items.</param>
        /// <param name="value">The value.</param>
        /// <returns>DialogResult.</returns>
        /// <exception cref="System.NotImplementedException"></exception>
        public static DialogResult InputDdlb(string title, string promptText, object[] items, ref string value)
        {
            Office2007Form form = new Office2007Form();
            Label label = new Label();
            ComboBoxAdv comboBoxAdv = new ComboBoxAdv();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            comboBoxAdv.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
         
            comboBoxAdv.Name = "comboBoxAdv1";
       
            comboBoxAdv.Sorted = true;
            comboBoxAdv.Style = Syncfusion.Windows.Forms.VisualStyle.VS2010;
            comboBoxAdv.Items.AddRange(items);
          
            ImageList imageList = MfcApplicationImageControl.NewInstance.ApplicationImages16;
            string icon = MfcApplicationImageControl.NewInstance.SaveImage16String;

            if (!imageList.Images.ContainsKey(icon))
            {
                throw new NotImplementedException(string.Format("The key :{0} has not been implemented in MfcApplicationImageControl", icon));
            }

            form.Icon = MfcApplicationImageControl.NewInstance.GetIcon(imageList.Images[icon]);

            form.UseOffice2007SchemeBackColor = true;
            form.ColorScheme = Syncfusion.Windows.Forms.Office2007Theme.Blue;
            form.Text = title;
            label.Text = promptText;
            label.BackColor = Color.Transparent;
             
            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            comboBoxAdv.SetBounds(9, 35, 276, 21);
             
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            comboBoxAdv.Anchor = comboBoxAdv.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, comboBoxAdv, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = comboBoxAdv.Text;
            return dialogResult;
        }
    }
}