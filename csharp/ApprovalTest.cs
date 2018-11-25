using System;
using System.IO;
using System.Text;
using NUnit.Framework;

namespace csharp
{
    [TestFixture]
    public class ApprovalTest
    {
        [Test]
        public void ThirtyDays()
        {
            string[] lines = File.ReadAllLines("ThirtyDays.txt");

            StringBuilder fakeoutput = new StringBuilder();
            Console.SetOut(new StringWriter(fakeoutput));
            Console.SetIn(new StringReader("a\n"));

            Program.Main(new string[] { });
            String output = fakeoutput.ToString();

            string[] outputLines = output.Split('\n');
            string currentDay = "";
            for(var i = 0; i<Math.Min(lines.Length, outputLines.Length); i++) 
            {
                if(lines[i].Contains("- day"))
                {
                    currentDay = lines[i];
                }
                outputLines[i] = outputLines[i].TrimEnd('\r');
                Assert.AreEqual(lines[i], outputLines[i],message:currentDay);
            }
        }
    }
}
