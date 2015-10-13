using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ubs.Collateral.Sre.Common.Utility;

namespace sre.model
{
    public class Security : IEquatable<Security>
    {
        public const int RequiredIsinChars = 12;
        public const int CountryCodeRequiredChars = 2;

        private SecurityType _securityType = SecurityType.Unknown;

        public Security(string securityCode)
        {
            SecurityCode = securityCode;
        }

        public Security(string securityCode, string securityType)
        {
            SecurityCode = securityCode;
            SecurityTypeDisplayText = securityType;
        }

        public string SecurityCode
        {
            get { return _securityCode; }
            set { _securityCode = value.ToUpperInvariant(); }
        }

        public string SecurityTypeDisplayText { get; set; }

        public SecurityType SecurityType
        {
            get
            {
                if (_securityType == SecurityType.Unknown)
                {
                    _securityType = !string.IsNullOrWhiteSpace(SecurityTypeDisplayText)
                               ? MfcEnumUtility.ParseByDescription<SecurityType>(SecurityTypeDisplayText)
                               : SecurityType.Default;
                }

                return _securityType;
            }
        }

        private string _countryCode;

        public string CountryCode
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_countryCode) && SecurityType == SecurityType.Isin)
                {
                    const int offset = 0; // First component of ISIN
                    _countryCode = SecurityCode.Substring(offset, offset + CountryCodeRequiredChars);
                }
                return _countryCode;
            }
            set { _countryCode = value; }
        }

        private string _nationalSecurityId;

        public string NationalSecurityId
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_nationalSecurityId) && SecurityType == SecurityType.Isin)
                {
                    const int requiredCharsNsid = 9;
                    const int offset = 2; //Second component of ISIN
                    _nationalSecurityId = SecurityCode.Substring(offset, offset + requiredCharsNsid);
                }
                return _nationalSecurityId;

            }
        }

        private string _checkDigit;
        private string _securityCode;

        public string CheckDigit
        {
            get
            {
                if (String.IsNullOrWhiteSpace(_checkDigit) && SecurityType == SecurityType.Isin)
                {
                    const int offset = RequiredIsinChars - 1;
                    _checkDigit = SecurityCode.Substring(offset, offset + 1);
                }
                return _checkDigit;
            }
        }

        public bool IsSpecial { get; set; }

        public bool Equals(Security other)
        {
            return other.SecurityCode.Equals(SecurityCode, StringComparison.OrdinalIgnoreCase);
        }

        public override bool Equals(object obj)
        {
            if (!(obj is Security))
            {
                return false;
            }
            Security sec = (Security) obj;
            return sec.SecurityCode.Equals(SecurityCode,StringComparison.OrdinalIgnoreCase);
        }

        public override int GetHashCode()
        {
            int hash = 19;
            hash = hash*29 + SecurityCode.GetHashCode();
            return hash;
        }
    }
}
