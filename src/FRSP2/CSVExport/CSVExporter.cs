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
        static string header = "BallsAutoLower,BallsAutoOuter,BallsAutoInner,WatchPos,CrossedAutoLine,BallsTeleLower,BallsTeleOuter,BallsTeleInner,WheelRotation,WheelPosition,CanHang,CanPark,IsLevel,TeamNumber,MatchNumber,";
        CsvConfiguration config = new CsvConfiguration(CultureInfo.CurrentCulture)
        {
            HasHeaderRecord = File.Exists(path),
            Delimiter = ","
        };
        
        public void Read()
        {
            // get header string
            //if (!csvFirstLine.Contains(header))
            //{
            //    //MessageBox.Show(csvFirstLine);
            //    headerExists = false;
            //}
            //else
            //{
            //    headerExists = true;
            //}
            //if (!headerExists)
            //{
            //    File.WriteAllText(path, header + Environment.NewLine); // replace all text with header (file was empty anyhow)
            //}
            //using (FileStream filestream = new FileStream(path, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite))
            //{     
            //    using (StreamReader reader = new StreamReader(filestream))
            //    {
            //        using (var csv = new CsvReader(reader, config))
            //        {
                        
            //            csv.Configuration.RegisterClassMap<RobotMap>();
            //            robots = csv.GetRecords<Robot>().ToList();
            //        }
            //    }
            //}
        }

        public void Write(Robot r)
        {

            //Read();
            //MessageBox.Show(config.HasHeaderRecord.ToString());
            //using (FileStream filestream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write))
            //{
            //    //string f = File.ReadLines(path).ToArray()[0];
            //    using (StreamWriter streamwriter = new StreamWriter(filestream))
            //    {
            //        using (var csv = new CsvWriter(streamwriter, config))
            //        {
            //            config.HasHeaderRecord = File.Exists(path);
            //            csv.Configuration.RegisterClassMap<RobotMap>();
            //            // robots.Add(r);
            //            csv.WriteHeader<Robot>();
            //            csv.NextRecord();
            //            csv.WriteRecord(r);
            //        }
            //    }
            //}
            try
            {
                export(r);
            }
            catch (FileNotFoundException fnf)
            {
                File.Create(path);
                export(r);
            }
        }

        public void export(Robot r)
        {
            string f = File.ReadLines(path).ToArray()[0];
            FileStream stream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.Write);
            StreamWriter writer = new StreamWriter(stream);
            var csv = new CsvWriter(writer, config);
            config.HasHeaderRecord = true;
            csv.Configuration.RegisterClassMap<RobotMap>();
            csv.WriteHeader<Robot>();
            csv.NextRecord();
            csv.WriteRecord(r);
            csv.Flush();
            writer.Close();
            stream.Close();
        }
    }
}