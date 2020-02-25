using System.Linq;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper.Configuration;
using System;
using System.Windows;

namespace FRSP2.CSVExport
{
    public class CSVExporter
    {
        Robot robot = new Robot();
        static List<Robot> robots = new List<Robot>();
        public static Robot current;
        //public static string path = @"C:\\Programming232\\test.csv";
        public static string path = @"C:\\Users\\castl\\Desktop\\test.csv";
        public static string csvFirstLine;
        static Boolean headerExists = false;
        static string header = "g";
        CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = !File.Exists(path)
        };
        
        public static string GetHeader()
        {
            try
            {
                csvFirstLine = File.ReadLines(path).ToArray()[0];
            }
            catch (Exception)
            {
                csvFirstLine = "";
            }
            return csvFirstLine;
        }
        public void Read()
        {
            // get header string
            if (!csvFirstLine.Contains(header))
            {
                //MessageBox.Show(csvFirstLine);
                headerExists = false;
            }
            else
            {
                headerExists = true;
            }
            if (!headerExists)
            {
                File.WriteAllText(path, header + Environment.NewLine); // replace all text with header (file was empty anyhow)
            }
            using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            {     
                using (StreamReader reader = new StreamReader(filestream))
                {
                    using (var csv = new CsvReader(reader, config))
                    {
                        csv.Configuration.RegisterClassMap<RobotMap>();
                        robots = csv.GetRecords<Robot>().ToList();
                    }
                }
            }
        }

        public void Write(Robot r)
        {
            //Read();

            using (FileStream filestream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                using (StreamWriter streamwriter = new StreamWriter(filestream))
                {
                    using (var csv = new CsvWriter(streamwriter, config))
                    {
                        
                        csv.Configuration.RegisterClassMap<RobotMap>();
                        robots.Add(r);
                        csv.WriteRecord(r);
                    }
                }
            }
        }
    }
}