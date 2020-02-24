﻿using CsvHelper.Configuration;
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
            //TODO: map by name?
            Map(m => m.TeamNumber);
            Map(m => m.MatchNumber);
            Map(m => m.WatchPos);
            Map(m => m.BallsAutoInner);
            Map(m => m.BallsAutoOuter);
            Map(m => m.BallsAutoLower);
            Map(m => m.CrossedAutoLine);
            Map(m => m.BallsTeleInner);
            Map(m => m.BallsTeleOuter);
            Map(m => m.BallsTeleLower);
            Map(m => m.CanHang);
            Map(m => m.CanPark);
            Map(m => m.IsLevel);
            Map(m => m.WheelPosition);
            Map(m => m.WheelRotation);
        }
    }
}
