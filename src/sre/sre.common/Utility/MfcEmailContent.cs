using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Ubs.Collateral.Sre.Common.Utility
{
    public class MfcEmailContent
    {
        public string Sender { get; set; }
        public string DisplayName { get; set; }
        public List<string> Recipients { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
    }
}
