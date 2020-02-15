using System;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Threading;
using System.Globalization;
using System.Windows;

namespace FRSP2.CSVExport
{
    public class CSVExporter
    {
        Robot robot = new Robot();
        static List<Robot> robots = new List<Robot>();
        public static Robot current;
        public static Thread thread;
        static Properties.Settings settings = Properties.Settings.Default;

        public void Write(Robot r)
        {
            if (!File.Exists(@"E:\NewDesktop\test.csv"))
            {
                File.Create(@"E:\NewDesktop\test.csv");
            }
            using (var writer = new StreamWriter(@"E:\NewDesktop\test.csv"))
            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                try
                {
                    robots.Add(r);
                    csv.Configuration.RegisterClassMap<RobotMap>();
                    if (String.IsNullOrEmpty(r.WatchPos))
                    {
                        MessageBox.Show("Please Select a Watch Position");
                        return;
                    }
                    if (String.IsNullOrEmpty(File.ReadAllText(@"E:\NewDesktop\test.csv")))
                    {
                        List<Robot> rs = new List<Robot>();
                        rs.Add(r);
                        csv.WriteRecords(rs);
                    }

                }
                catch (Exception)
                {

                }
            }
        }
    }


}