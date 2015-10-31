using System;
using System.Xml.Serialization;

namespace hk.Core
{
    [XmlRoot(ElementName = "settings", IsNullable = false)]
    public class Settings
    {

        [XmlElement("singularRule")]
        public Rule[] SingularRule { get; set; }


        [XmlElement("table")]
        public Table[] Table { get; set; }
    }

    [Serializable]
    public class Rule
    {

        private ArgumentType[] argumentField;

        private string nameField;

        private string descriptionField;

        private bool enabledField;

        private bool enabledFieldSpecified;

        private int ruleGroupIdField;

        private bool ruleGroupIdFieldSpecified;

        private ruleGroupsEnums ruleGroupNameField;

        private bool ruleGroupNameFieldSpecified;

        private int ruleIdField;

        private bool toggleableField;

        private bool toggleableFieldSpecified;


        [XmlElement("argument")]
        public ArgumentType[] Argument
        {
            get
            {
                return this.argumentField;
            }
            set
            {
                this.argumentField = value;
            }
        }


        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }


        [XmlAttribute("description")]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }


        [XmlAttribute("enabled")]
        public bool Enabled
        {
            get
            {
                return this.enabledField;
            }
            set
            {
                this.enabledField = value;
            }
        }


        [XmlIgnore]
        public bool EnabledSpecified
        {
            get
            {
                return this.enabledFieldSpecified;
            }
            set
            {
                this.enabledFieldSpecified = value;
            }
        }


        [XmlAttribute("ruleGroupId")]
        public int RuleGroupId
        {
            get
            {
                return this.ruleGroupIdField;
            }
            set
            {
                this.ruleGroupIdField = value;
            }
        }


        [XmlIgnore]
        public bool RuleGroupIdSpecified
        {
            get
            {
                return this.ruleGroupIdFieldSpecified;
            }
            set
            {
                this.ruleGroupIdFieldSpecified = value;
            }
        }


        [XmlAttribute("ruleGroupName")]
        public ruleGroupsEnums RuleGroupName
        {
            get
            {
                return this.ruleGroupNameField;
            }
            set
            {
                this.ruleGroupNameField = value;
            }
        }


        [XmlIgnore]
        public bool RuleGroupNameSpecified
        {
            get
            {
                return this.ruleGroupNameFieldSpecified;
            }
            set
            {
                this.ruleGroupNameFieldSpecified = value;
            }
        }


        [XmlAttribute("ruleId")]
        public int RuleId
        {
            get
            {
                return this.ruleIdField;
            }
            set
            {
                this.ruleIdField = value;
            }
        }


        [XmlAttribute("toggleable")]
        public bool Toggleable
        {
            get
            {
                return this.toggleableField;
            }
            set
            {
                this.toggleableField = value;
            }
        }


        [XmlIgnore]
        public bool ToggleableSpecified
        {
            get
            {
                return this.toggleableFieldSpecified;
            }
            set
            {
                this.toggleableFieldSpecified = value;
            }
        }
    }



    [Serializable]
    public class ArgumentType
    {

        private keyEnums idField;

        private bool idFieldSpecified;

        private typeEnums typeField;

        private bool typeFieldSpecified;

        private string valueField;


        [XmlAttribute("id")]
        public keyEnums Id
        {
            get
            {
                return this.idField;
            }
            set
            {
                this.idField = value;
            }
        }


        [XmlIgnore]
        public bool IdSpecified
        {
            get
            {
                return this.idFieldSpecified;
            }
            set
            {
                this.idFieldSpecified = value;
            }
        }


        [XmlAttribute("type")]
        public typeEnums Type
        {
            get
            {
                return this.typeField;
            }
            set
            {
                this.typeField = value;
            }
        }


        [XmlIgnore]
        public bool TypeSpecified
        {
            get
            {
                return this.typeFieldSpecified;
            }
            set
            {
                this.typeFieldSpecified = value;
            }
        }


        [XmlText()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
    }



    [Serializable]
    public enum keyEnums
    {


        ruleGroupName,


        softRejectCountToHardReject,


        checkBidEconomics,


        bidEconThreshold,


        cptyGroupName,


        minFee,


        minFeeUSD,


        kipCodes,


        externalSystems,


        reasonCodes,


        counterparties,


        counterpartyExceptions,


        productTypes,


        assetClass,


        quotationCountries,


        quotationCountryExceptions,


        isins,


        isSpecialSecurity,


        businessState,


        straightToFirm,


        straightToDI,


        usdValue,


        requestedUsdValue,


        bid,


        offer,


        feeDifferentFromSoft,


        allocatedQtyDifferentFromSoft,


        bidOfferRange,


        currency,


        totalAvailable,


        valueToGo,


        daysToRecordDate,


        daysToMaturity,


        daysToExDividendDate,


        totalAvailMinusDCCAlloc,


        DCCAlloc,


        totalClientsHolding,


        totalAllocationValue,


        checkBilateralReceivedGreaterThanDCCAlloc,


        totalRestricted,


        percentageAllocated,


        dividendRate,


        setNextRuleGroup,


        outcome,


        linkedOutcome,


        kipCode,


        checkIfBidLessThanOffer,


        checkIfBidGreaterThanOffer,


        amendOfferToMatchBid,


        setOffer,


        applyDefaultMinFeeForCCY,


        setMinFee,
    }



    [Serializable]
    public enum typeEnums
    {


        boolean,


        @string,


        integer,


        @decimal,


        originating_systems,


        counterparties,


        product_types,


        securities,


        security_classifications,


        countries,


        business_states,


        kip_codes,


        reason_codes,


        outcome,
    }



    [Serializable]
    public enum ruleGroupsEnums
    {


        [XmlEnum("Setup")]
        Setup,


        [XmlEnum("Emergency Switch")]
        EmergencySwitch,

        [XmlEnum("Health Check")]
        HealthCheck,


        [XmlEnum("EQ - Reference Data Check")]
        EqReferenceDataCheck,


        [XmlEnum("FI - Reference Data Check")]
        FiReferenceDataCheck,


        [XmlEnum("EQ - Availability Restrictions")]
        EqAvailabilityRestrictions,


        [XmlEnum("FI - Availability Restrictions")]
        FiAvailabilityRestrictions,


        [XmlEnum("EQ - Instrument Restrictions")]
        EqInstrumentRestrictions,


        [XmlEnum("FI - Instrument Restrictions")]
        FiInstrumentRestrictions,


        [XmlEnum("Common Order Checks")]
        CommonOrderChecks,


        [XmlEnum("EQ - Warms Trades")]
        EqWarmsTrades,


        [XmlEnum("EQ - Big Tickets")]
        EqBigTickets,


        [XmlEnum("EQ - Small Tickets")]
        EqSmallTickets,


        [XmlEnum("EQ - General Tickets")]
        EqGeneralTickets,


        [XmlEnum("Offer Restrictions")]
        OfferRestrictions,


        [XmlEnum("EQ - Counterparty Restrictions")]
        EqCounterpartyRestrictions,


        [XmlEnum("FI - Counterparty Restrictions")]
        FiCounterpartyRestrictions,


        [XmlEnum("EquiLend Order Checks")]
        EquiLendOrderChecks,


        [XmlEnum("BondLend Order Checks")]
        BondLendOrderChecks,


        [XmlEnum("EQ - Maelstrom Order Checks")]
        EqMaelstromOrderChecks,


        [XmlEnum("FI - Maelstrom Order Checks")]
        FiMaelstromOrderChecks,

        [XmlEnum("Highlight")]
        Highlight,


        [XmlEnum("Final Decisions")]
        FinalDecisions,


        [XmlEnum("")]
        None,
    }


    [Serializable]
    public partial class Table
    {

        private Rule[] _tabularRules;

        private string _description;

        private string _name;

        private int _ruleGroupId;

        private ruleGroupsEnums _ruleGroupName;

        private bool _ruleGroupNameSpecified;

        private int _templateId;

        private bool _templateIdSpecified;


        [XmlElement("tabularRule")]
        public Rule[] TabularRule
        {
            get
            {
                return this._tabularRules;
            }
            set
            {
                this._tabularRules = value;
            }
        }


        [XmlAttribute("description")]
        public string Description
        {
            get
            {
                return this._description;
            }
            set
            {
                this._description = value;
            }
        }


        [XmlAttribute("name")]
        public string Name
        {
            get
            {
                return this._name;
            }
            set
            {
                this._name = value;
            }
        }


        [XmlAttribute("ruleGroupId")]
        public int RuleGroupId
        {
            get
            {
                return this._ruleGroupId;
            }
            set
            {
                this._ruleGroupId = value;
            }
        }


        [XmlAttribute("ruleGroupName")]
        public ruleGroupsEnums RuleGroupName
        {
            get
            {
                return this._ruleGroupName;
            }
            set
            {
                this._ruleGroupName = value;
            }
        }


        [XmlIgnore]
        public bool RuleGroupNameSpecified
        {
            get
            {
                return this._ruleGroupNameSpecified;
            }
            set
            {
                this._ruleGroupNameSpecified = value;
            }
        }


        [XmlAttribute("templateId")]
        public int TemplateId
        {
            get
            {
                return this._templateId;
            }
            set
            {
                this._templateId = value;
            }
        }


        [XmlIgnore]
        public bool TemplateIdSpecified
        {
            get
            {
                return this._templateIdSpecified;
            }
            set
            {
                this._templateIdSpecified = value;
            }
        }
    }
}