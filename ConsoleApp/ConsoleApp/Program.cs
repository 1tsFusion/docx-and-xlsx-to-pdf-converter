using System;
using System.IO;
using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Укажите пути к файлам
            string xlsxPath = @"C:\Users\MarkovaDM\Desktop\convert\input.xlsx"; // путь к исходному XLSX
            string pdfPath = @"C:\Users\MarkovaDM\Desktop\convert\output.pdf";  // путь для сохранения PDF

            // Проверка существования файла
            if (!File.Exists(xlsxPath))
            {
                Console.WriteLine("Файл XLSX не найден!");
                return;
            }

            ConvertXlsxToPdf(xlsxPath, pdfPath);
            Console.WriteLine("Конвертация завершена успешно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }

    static void ConvertXlsxToPdf(string xlsxPath, string pdfPath)
    {
        // Открываем XLSX файл
        using (var workbook = new XLWorkbook(xlsxPath))
        {
            using (var document = new Document())
            {
                using (var stream = new FileStream(pdfPath, FileMode.Create))
                {
                    using (var writer = PdfWriter.GetInstance(document, stream))
                    {
                        document.Open();

                        // Обрабатываем каждый лист
                        foreach (var worksheet in workbook.Worksheets)
                        {
                            // Заголовок — имя листа
                            var title = new Paragraph(worksheet.Name, FontFactory.GetFont("Arial", 12, Font.BOLD));
                            document.Add(title);

                            // Создаём таблицу для данных листа
                            var table = new PdfPTable(worksheet.LastCellUsed().Address.ColumnNumber);
                            table.WidthPercentage = 100;

                            // Заполняем таблицу данными
                            foreach (var row in worksheet.RowsUsed())
                            {
                                for (int col = 1; col <= worksheet.LastCellUsed().Address.ColumnNumber; col++)
                                {
                                    var cellValue = row.Cell(col).Value.ToString();
                                    table.AddCell(cellValue);
                                }
                            }

                            document.Add(table);
                            document.Add(new Paragraph("\n")); // разделитель между листами
                        }

                        document.Close();
                    }
                }
            }
        }
    }
}
