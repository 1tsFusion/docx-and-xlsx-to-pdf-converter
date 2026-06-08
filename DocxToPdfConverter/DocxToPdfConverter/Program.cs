using System;
using Aspose.Words;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Конвертер DOCX в PDF");
        Console.Write("Введите путь к DOCX-файлу: ");
        string docxPath = Console.ReadLine();

        if (!System.IO.File.Exists(docxPath))
        {
            Console.WriteLine("Файл не найден!");
            return;
        }

        Console.Write("Введите путь для сохранения PDF: ");
        string pdfPath = Console.ReadLine();

        try
        {
            // Загружаем DOCX
            Document doc = new Document(docxPath);
            // Сохраняем как PDF
            doc.Save(pdfPath, SaveFormat.Pdf);
            Console.WriteLine("Конвертация завершена успешно!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
        }
    }
}
