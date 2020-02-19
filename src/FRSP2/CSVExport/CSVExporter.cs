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
        string newpath = path.Replace("x", $"{current.WatchPos}");
        public IEnumerable<Robot> Read()
        {
            IEnumerable<Robot> records;
            if (File.Exists(newpath))
            {
                using (FileStream filestream = new FileStream(newpath, FileMode.Open, FileAccess.Read, FileShare.Delete))
                {
                    using (StreamReader reader = new StreamReader(filestream))
                    {
                        using (var csv = new CsvReader(reader, CultureInfo.CurrentCulture))
                        {
                            records = csv.GetRecords<Robot>();
                        }
                    }
                }
                File.Delete(path);
            }
            else records = new List<Robot>();
            return records;
        }

        public void Write(IEnumerable<Robot> list)
        {

            
            CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(newpath)
            };

            if (!File.Exists(path))
            {
                //FileStream fs = File.Create(path);
                //fs.Close();
            }

            using (FileStream filestream = new FileStream(newpath, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamwriter = new StreamWriter(filestream))
                {
                    using (var csv = new CsvWriter(streamwriter, config))
                    {
                        csv.WriteRecords(list);
                    }
                }
            }
        }
    }
}