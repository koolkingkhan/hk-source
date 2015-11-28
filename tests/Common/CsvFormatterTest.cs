using NUnit.Framework;

namespace hk.Common.Tests
{
    [TestFixture, ConsoleAction("CsvFormatter")]
    public class CsvFormatterTest
    {
        [Test, Ignore("")]
        public void TestRead()
        {
            string[] files =
            {
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\1st.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\mid_nego.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\Last.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\parallel.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\oee1.csv",
                //@"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\lop1.csv",
                @"C:\Users\Hussain\Desktop\SOURCE\ProgrammingTasks\HKFC\SentToOval.csv"
            };
            CsvFormatter formatter = new CsvFormatter();

            foreach (var file in files)
            {
                formatter.CreateFormattedFile(file);
            }
        }
    }
}