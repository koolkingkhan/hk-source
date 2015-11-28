using System;
using System.Diagnostics;
using NUnit.Framework;
using NUnit.Framework.Interfaces;

namespace hk.Common.Tests
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class |
                    AttributeTargets.Interface | AttributeTargets.Assembly,
        AllowMultiple = true)]
    public class ConsoleActionAttribute : Attribute, ITestAction
    {
        private readonly string _message;
        private readonly Stopwatch _stopwatch;

        public ConsoleActionAttribute(string message)
        {
            _message = message;
            _stopwatch = new Stopwatch();
        }

        public void BeforeTest(ITest test)
        {
            _stopwatch.Start();
            WriteToConsole("Before", test);
        }

        public void AfterTest(ITest test)
        {
            _stopwatch.Stop();
            if (test.IsSuite)
            {
                WriteToConsole("After", test);
            }
            else
            {
                Console.WriteLine("Time taken: {0}", _stopwatch.Elapsed);
            }
        }

        public ActionTargets Targets
        {
            get { return ActionTargets.Test | ActionTargets.Suite; }
        }

        private void WriteToConsole(string eventMessage, ITest test)
        {
            Console.WriteLine("{0} {1}: {2} - {3}.{4}.",
                eventMessage,
                test.IsSuite ? "Suite" : "Case",
                _message,
                test.GetType().Name,
                test.Name);
        }
    }
}