// ***********************************************************************
// Assembly         : Common
// Author           : bethunro
// Created          : 07-29-2013
//
// Last Modified By : bethunro
// Last Modified On : 07-29-2013
// ***********************************************************************
// <copyright file="MfcEnumUtility.cs" company="UBS AG">
//     Copyright (c) UBS AG. All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

using System;
using System.ComponentModel;

namespace Ubs.Collateral.Sre.Common.Utility
{
    /// <summary>
    /// Class MfcEnumUtility
    /// </summary>
    public static class MfcEnumUtility {
        /// <summary>
        /// Parses the specified value.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>``0.</returns>
        public static T Parse<T>(string value)
        {
            return (T)Enum.Parse(typeof(T), value);
        }

        /// <summary>
        /// Parses the by description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>``0.</returns>
        public static T ParseByDescription<T>(string value)
        {
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                var enumValue = Parse<T>(name) as Enum;
                if (enumValue.Description().Equals(value, StringComparison.InvariantCulture))
                {
                    return Parse<T>(name);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Parses the by description.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value">The value.</param>
        /// <returns>``0.</returns>
        public static T ParseByDescriptionIgnoringDefaultComparison<T>(string value)
        {
            foreach (var name in Enum.GetNames(typeof(T)))
            {
                if (name.Equals("Default", StringComparison.InvariantCulture))
                {
                    continue;
                }

                var enumValue = Parse<T>(name) as Enum;
                if (enumValue.Description().Equals(value, StringComparison.InvariantCulture))
                {
                    return Parse<T>(name);
                }
            }

            return default(T);
        }

        /// <summary>
        /// Descriptions the specified enumeration.
        /// </summary>
        /// <param name="enumeration">The enumeration.</param>
        /// <returns>System.String.</returns>
        public static string Description(this Enum enumeration)
        {
            var value = enumeration.ToString();
            var type = enumeration.GetType();
            var descAttribute = (DescriptionAttribute[])type.GetField(value).GetCustomAttributes(typeof(DescriptionAttribute), false);
            return descAttribute.Length > 0 ? descAttribute[0].Description : value;
        }
    }
}
