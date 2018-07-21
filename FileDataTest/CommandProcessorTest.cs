using System;
using System.Text.RegularExpressions;
using FileData;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ThirdPartyTools;

namespace FileDataTest
{
    [TestClass]
    public class CommandProcessorTest
    {
        [TestMethod]
        [DataRow(new[] { "-v", "c:/test.txt" })]
        [DataRow(new[] { "--v", "c:/test.txt" })]
        [DataRow(new[] { "/v", "c:/test.txt" })]
        [DataRow(new[] { "--version", "c:/test.txt" })]
        public void CommandProcessor_Return_Version(string[] args)
        {
            var result = CommandProcessor.getFileDetails(new FileDetails(), args);

            StringAssert.Matches(result, new Regex(@"^(\d+\.)?(\d+\.)?(\d+)$"));
        }

        [TestMethod]
        [DataRow(new[] { "-s", "c:/test.txt" })]
        [DataRow(new[] { "--s", "c:/test.txt" })]
        [DataRow(new[] { "/s", "c:/test.txt" })]
        [DataRow(new[] { "--size", "c:/test.txt" })]
        public void CommandProcessor_Return_Size(string[] args)
        {
            var result = CommandProcessor.getFileDetails(new FileDetails(), args);
            int output;
            var isSize = int.TryParse(result, out output);
            Assert.IsTrue(isSize);
        }

        [TestMethod, ExpectedException(typeof(ArgumentException))]
        [DataRow(new[] { "/f", "c:/test.txt" })]
        [DataRow(new[] { "c:/test.txt" })]
        public void CommandProcessor_Throws_Exception(string[] args)
        {
            var result = CommandProcessor.getFileDetails(new FileDetails(), args);
        }
    }
}
