using System;
using System.Collections.Generic;
using System.DirectoryServices.AccountManagement;
using System.Net;
using System.Security.Principal;
using Newtonsoft.Json;

namespace hk.Common.Model
{
    public interface IGlsRequest
    {
        [JsonRequired]
        IUser CurrentUser { get; set; }

        [JsonRequired]
        string DocumentTitle { get; set; }

        List<IIssuer> Issuers { get; set; }

        List<IUser> Analysts { get; set; }
    }

    public abstract class MessagingRequest
    {
        private string _clientId;

        [JsonRequired]        
        [JsonProperty(PropertyName = "clientId")]
        public string ClientId
        {
            get { return _clientId ?? (_clientId = "RAP"); }
            set { _clientId = value; }
        }
    }

    public class GlsRequest : MessagingRequest, IGlsRequest
    {
        private IUser _user;
        private List<IIssuer> _issuers;
        private string _documentTitle;
        private List<IUser> _analysts;

        [JsonProperty(PropertyName = "supervisoryAnalyst")]
        public IUser CurrentUser
        {
            get { return _user ?? (_user = new User()); }
            set { _user = value; }
        }

        [JsonProperty(PropertyName = "documentTitle")]
        public string DocumentTitle
        {
            get { return _documentTitle ?? (_documentTitle = String.Empty); }
            set { _documentTitle = value; }
        }

        [JsonProperty(PropertyName = "issuers")]
        public List<IIssuer> Issuers
        {
            get { return _issuers ?? (_issuers = new List<IIssuer>()); }
            set { _issuers = value; }
        }

        [JsonProperty(PropertyName = "analysts")]
        public List<IUser> Analysts
        {
            get { return _analysts ?? (_analysts = new List<IUser>()); }
            set { _analysts = value; }
        }
    }

    public interface IUser
    {
        [JsonRequired]
        int Gpin { get; set; }
    }

    public class User : IUser
    {
        public User()
        {
            Username = WindowsIdentity.GetCurrent().Name;
            UserPrincipalName = UserPrincipal.Current.UserPrincipalName;
            int index = !string.IsNullOrEmpty(UserPrincipalName) ? UserPrincipalName.IndexOf("@", StringComparison.OrdinalIgnoreCase) : -1;
            if (-1 != index)
            {
                int value;
                Gpin = int.TryParse(UserPrincipalName.Substring(0, index), out value) ? value : -1;
            }
            else
            {
                Gpin = -1;
            }            
            HostName = Dns.GetHostName();
            EmailAddress = UserPrincipal.Current.EmailAddress;
        }

        [JsonIgnore]
        public string Username { get; private set; }

        [JsonIgnore]
        public string UserPrincipalName { get; private set; }

        [JsonIgnore]
        public string HostName { get; private set; }

        [JsonIgnore]
        public string EmailAddress { get; private set; }

        [JsonProperty(PropertyName = "gpin")]
        public int Gpin { get; set; }
    }

    public interface IIssuer
    {
        [JsonRequired]
        int UbsPartyId { get; set; }

        AssetType AssetType { get; set; }
    }

    public class Issuer : IIssuer
    {
        public Issuer()
        {
            UbsPartyId = -1;
            AssetType = AssetType.NotSpecified;
        }

        [JsonIgnore]
        public AssetType AssetType { get; set; }

        [JsonProperty(PropertyName = "ubsPartyId")]
        public int UbsPartyId { get; set; }
    }

    public enum AssetType
    {
        NotSpecified = 0,
        FixedIncome,
        Equity,
        Governments
    }
}
