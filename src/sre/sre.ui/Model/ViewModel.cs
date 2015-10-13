using System;
using System.Collections.Generic;
using System.Linq;
using Ubs.Collateral.Sre.Common.Rules.Settings;
using sre.ui.Settings;

namespace sre.ui.Model
{
    public class ViewModel
    {
        public ColumnConfig ColumnConfig { get; set; }
        public IEnumerable<Rules> Rules { get; set; }

        private readonly RulesCollection _ruleParameterCollection;

        public ViewModel(RulesCollection ruleParameterCollection)
        {
            if (ruleParameterCollection == null)
            {
                throw new ArgumentNullException("ruleParameterCollection");
            }

            _ruleParameterCollection = ruleParameterCollection;

            var columns = new List<Column>();
            int count = _ruleParameterCollection.RuleParameterCollection.Select(m => m.Arguments.Count).Max();
            columns.Add(new Column { Header = "Name", DataField = "Name"});

            for (int i = 1; i <= count; i++)
            {
                string s = string.Format("Parameter{0}", i);
                columns.Add(new Column { Header = s, DataField = s, CanEdit = true});
            }

            ColumnConfig = new ColumnConfig { Columns = columns };

            List<Rules> rules = _ruleParameterCollection.RuleParameterCollection.Select(parameter => new Rules
                {
                    Name = parameter.RuleName, Parameter1 = parameter.Arguments[0].Value, Parameter2 = parameter.Arguments.Count > 1 ? parameter.Arguments[1].Value : null
                }).ToList();

            Rules = rules;
        }

        public void Save(bool emergencySwitch)
        {
            _ruleParameterCollection.Update(emergencySwitch);
        }


    }
}