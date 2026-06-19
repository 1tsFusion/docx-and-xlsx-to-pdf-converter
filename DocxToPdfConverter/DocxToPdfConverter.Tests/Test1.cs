using System;
using System.IO;
using Aspose.Words;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DocxToPdfConverter.Tests
{
    [TestClass]
    public sealed class DocxConverterTests
    {
        [TestMethod]
        public void ConvertDocxToPdf_ValidPaths_ConversionSuccessful()
        {
            string testDocxPath = "test_input.docx";
            string testPdfPath = "test_output.pdf";

            Document testDoc = new Document();
            DocumentBuilder builder = new DocumentBuilder(testDoc);
            builder.Write("тестовый документ для конвертации");
            testDoc.Save(testDocxPath);

            try
            {
                Document doc = new Document(testDocxPath);
                doc.Save(testPdfPath, SaveFormat.Pdf);

                Assert.IsTrue(File.Exists(testPdfPath), "pdf файл должен быть создан");
            }
            finally
            {
                if (File.Exists(testDocxPath)) File.Delete(testDocxPath);
                if (File.Exists(testPdfPath)) File.Delete(testPdfPath);
            }
        }
        [TestMethod]
        public void ConvertDocxToPdf_FileNotFound_ThrowsException()
        {
            string nonExistentPath = "non_existent.docx";
            string outputPath = "output.pdf";

            Assert.IsFalse(File.Exists(nonExistentPath), "файл не должен существовать");

            try
            {
                Document doc = new Document(nonExistentPath);
                Assert.Fail("должна быть ошибка, так как файл не найден");
            }
            catch (Exception ex)
            {
                Assert.IsInstanceOfType(ex, typeof(FileNotFoundException));
            }

            Assert.IsFalse(File.Exists(outputPath));
        }
        [TestMethod]
        public void ConvertDocxToPdf_InvalidFormat_ThrowsException()
        {
            string invalidFilePath = "invalid_file.txt";
            string pdfOutputPath = "output.pdf";

            File.WriteAllText(invalidFilePath, "это не docx файл");

            try
            {
                Document doc = new Document(invalidFilePath);
                doc.Save(pdfOutputPath, SaveFormat.Pdf);
                Assert.Fail("должна быть ошибка при конвертации неверного формата");
            }
            catch (Exception ex)
            {
                Assert.IsNotNull(ex);
            }
            finally
            {
                if (File.Exists(invalidFilePath)) File.Delete(invalidFilePath);
                if (File.Exists(pdfOutputPath)) File.Delete(pdfOutputPath);
            }
        }

    }
}
