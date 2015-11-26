using NUnit.Framework;

namespace hk.Core.Tests
{
    [TestFixture, ConsoleAction("CsvFormatter")]
    public class CsvFormatter
    {
        [Test]
        public void TestRead()
        {
            string[] files = new string[]
            {
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\1st.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\mid_nego.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\Last.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\parallel.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\oee1.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\lop1.csv",
                @"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\SentToOval.csv"
            };
            Core.CsvFormatter formatter = new Core.CsvFormatter();

            foreach (var file in files)
            {
                formatter.CreateFormattedFile(file);
            }
        }
    }
}
