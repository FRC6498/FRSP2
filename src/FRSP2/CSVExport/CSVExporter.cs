using System;
using System.IO;
using CsvHelper;
using System.Collections.Generic;
using System.Threading;

namespace FRSP2.CSVExport
{
    public class CSVExporter
    {
        Robot robot = new Robot();
        //TODO: read robot, then write current one in addition
        static List<Robot> robots = new List<Robot>();
        public static Robot current;
        public static Thread thread;
        ThreadStart ts = new ThreadStart(ThreadWrite);
        
        //IEnumerable<Robot> records;

        public CSVExporter()
        {
            thread = new Thread(ts, 1000000000);
        }

        public void Export()
        {
            if (thread.ThreadState == ThreadState.Unstarted)
            {
                thread.Start();
            }
            else if (thread.ThreadState != ThreadState.Running)
            {
                thread.Abort();
            }
            
        }
        public static void ThreadWrite()
        {
            Write(current);
        }
        public static void Write(Robot r)
        {
            robots.Add(r);
            if (!File.Exists(@"C:\Users\312679\Desktop\test.csv"))
            {
                File.Create(@"C:\Users\312679\Desktop\test.csv");
            }
            using (var writer = new StreamWriter(@"C:\Users\312679\Desktop\test.csv"))
            using (var csv = new CsvWriter(writer))
            {
                try
                {
                    csv.WriteRecord<Robot>(r);
                }
                catch (Exception)
                {

                }
            }
        }
    }


}