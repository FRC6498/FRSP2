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
        public static string path = @"E:\\NewDesktop\\test.csv";


        public void Write(Robot r)
        {
            CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture)
            {
                HasHeaderRecord = !File.Exists(path)
            };

            if (!File.Exists(path))
            {
                //FileStream fs = File.Create(path);
                //fs.Close();
            }

            if (String.IsNullOrEmpty(r.WatchPos))
            {
                MessageBox.Show("Please Select a Watch Position");
                return;
            }

            using (FileStream filestream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {
                using (StreamWriter streamwriter = new StreamWriter(filestream))
                {
                    using (var csv = new CsvWriter(streamwriter, config))
                    {
                        robots.Add(r);
                        csv.Configuration.RegisterClassMap<RobotMap>();
                        csv.WriteRecords(robots);
                    }
                }
            }
        }
    }
}