using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using DocxToPdfConverter;

namespace DocxToPdfConverter.Tests
{
    [TestClass]
    public class DocxToPdfConverterTests
    {
        private const string TestInputDir = "TestData";
        private const string TestOutputDir = "TestOutput";

        [TestInitialize]
        public void Setup()
        {

        }

        [TestMethod]
        public void ConvertDocxToPdf_ValidInput_CreatesPdfFile()
        {

        }

        [TestMethod]
        public void ConvertDocxToPdf_NonExistentFile_ThrowsFileNotFoundException()
        {

        }

        [TestMethod]
        public void ConvertDocxToPdf_InvalidFormat_ThrowsException()
        {

        }
    }
}
