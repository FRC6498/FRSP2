using System.Linq;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Globalization;
using CsvHelper.Configuration;
using System.Reflection;
using System.Windows;

namespace FRSP2.CSVExport
{
    public class CSVExporter
    {
        Robot robot = new Robot();
        static List<Robot> robots = new List<Robot>();
        public static Robot current;
        string f;
        static bool headerExists = false;
        public static string path = Assembly.GetExecutingAssembly().CodeBase + "/test.csv";
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
            if (File.Exists(path))
            {
                f = File.ReadLines(path).First();
            }
            else
            {
                f = "";
            }

            //Read();
            //MessageBox.Show(config.HasHeaderRecord.ToString());
            using (FileStream filestream = new FileStream(path, FileMode.Append, FileAccess.Write, FileShare.ReadWrite))
            {

                if (f == "TeamNumber,MatchNumber,WatchPosition,BallsAutoInner,BallsAutoOuter,BallsAutoLower,CrossedLine,BallsTeleopInner,BallsTeleopOuter,BallsTeleopLower,CanHang,CanLevel,WheelPosition,WheelRotation")
                {
                    headerExists = true;
                }
                using (StreamWriter streamwriter = new StreamWriter(filestream))
                {
                    using (var csv = new CsvWriter(streamwriter, config))
                    {
                        config.HasHeaderRecord = File.Exists(path);
                        csv.Configuration.RegisterClassMap<RobotMap>();
                        if (!headerExists)
                        {
                            csv.WriteHeader<Robot>();
                        }
                        // TODO: add to list on update, write on quit
                        csv.NextRecord();
                        csv.WriteRecord(r);
                    }
                }
            }
            //try
            //{
            //    export(r);
            //}
            //catch (FileNotFoundException)
            //{
            //    File.Create(path);
            //    export(r);
            //}
        }

        public void export(Robot r)
        {
            string f = File.ReadLines(path).First();
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