using System;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Diagnostics;
using CsvHelper.Configuration;

namespace FRSP2.CSVExport
{
    public class CSVExporter
    {
        Robot robot = new Robot();
        static List<Robot> robots = new List<Robot>();
        public static Robot current;
        public static string path = @"C:\\Programming232\\testx.csv";
        public IEnumerable<Robot> Read()
        {
            IEnumerable<Robot> records;
            using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Read, FileShare.Read))
            {
                using (StreamReader reader = new StreamReader(filestream))
                {
                    using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                    {
                        
                        records = csv.GetRecords<Robot>();
                    }
                }
            }
            return records;
        }

        public void Write(List<Robot> list, Robot r)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(path)
            };

            using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamwriter = new StreamWriter(filestream))
                {
                    using (var csv = new CsvWriter(streamwriter, config))
                    {
                        list.Add(r);
                        csv.WriteRecords(list);
                    }
                }
            }
        }
    }
}