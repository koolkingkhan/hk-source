using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace hk.Core.Tests
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                    AttributeTargets.Interface | AttributeTargets.Assembly,
                    AllowMultiple = true)]
    public class ConsoleActionAttribute : Attribute, ITestAction
    {
        private readonly string _message;

        public ConsoleActionAttribute(string message) { _message = message; }

        public void BeforeTest(ITest test)
        {
            WriteToConsole("Before", test);
        }

        public void AfterTest(ITest test)
        {
            WriteToConsole("After", test);
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test | ActionTargets.Suite; }
        }

        private void WriteToConsole(string eventMessage, ITest test)
        {
            Debug.WriteLine("{0} {1}: {2}, from {3}.{4}.",
                eventMessage,
                test.IsSuite ? "Suite" : "Case",
                _message,
                test.GetType().Name,
                test.Name);
        }
    }
}
