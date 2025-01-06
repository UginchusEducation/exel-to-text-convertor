using System;
using System.IO;
using System.Windows.Forms;
using windows_app.services;
using windows_app.models;
using windows_app.utils;

namespace windows_app
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                var rows = ExcelReader.ReadExcelFile(filePath);
                string outputDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..", "output");
                Directory.CreateDirectory(outputDirectory);

                int count = 0;
                string country = "Україна";
                string military = "Збройні сили";

                foreach (var row in rows)
                {
                    count++;
                    string phone = row.PhoneNumber.Replace(",", "").Trim();
                    string blood = row.BloodType.Trim();
                    string first_name = row.FirstName.Trim();
                    string middle_name = row.MiddleName.Trim();
                    string last_name = row.LastName.Trim();
                    string info_block = $"{phone}\n{country}\n{military}";
                    string name_block = $"{last_name}\n{first_name}\n{middle_name}\n{blood}";
                    string content = $"{info_block}\n\n{name_block}\n\n\n{name_block}\n\n{info_block}";
                    string outputFilePath = Path.Combine(outputDirectory, $"{count}_{last_name}.txt");
                    FileWriter.WriteToFile(outputFilePath, content);
                }
            }
        }
    }
}