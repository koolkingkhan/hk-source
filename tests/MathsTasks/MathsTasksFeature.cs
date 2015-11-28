using System.Collections.Generic;
using Machine.Specifications;

namespace hk.MathsTasks.Tests
{
    [Subject(typeof (MathsTasks))]
    public class when_a_regular_customer_is_made_preferred
    {
        private static List<int> primes;

        private Establish context = () => { primes = new List<int>(); };

        private Because of = () => { primes.AddRange(MathsTasks.CalculatePrimeNumbers(50)); };

        private It should_mark_the_customer_as_preferred = () => { primes.Count.ShouldEqual(15); };
    }
}