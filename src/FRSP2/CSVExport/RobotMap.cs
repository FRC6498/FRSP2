using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRSP2.CSVExport
{
    public sealed class RobotMap : ClassMap<Robot>
    {
        public RobotMap()
        {
            Map(m => m.TeamNumber);
        }
    }
}
