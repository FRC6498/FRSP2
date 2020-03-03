using CsvHelper.Configuration;

namespace FRSP2.CSVExport
{
    public sealed class RobotMap : ClassMap<Robot>
    {
        public RobotMap()
        {
            Map(m => m.TeamNumber).Index(0).Name("TeamNumber");
            Map(m => m.MatchNumber).Index(1).Name("MatchNumber");
            Map(m => m.WatchPos).Index(2).Name("WatchPosition");
            Map(m => m.BallsAutoInner).Index(3).Name("BallsAutoInner");
            Map(m => m.BallsAutoOuter).Index(4).Name("BallsAutoOuter");
            Map(m => m.BallsAutoLower).Index(5).Name("BallsAutoLower");
            Map(m => m.CrossedAutoLine).Index(6).Name("CrossedLine");
            Map(m => m.BallsTeleInner).Index(7).Name("BallsTeleopInner");
            Map(m => m.BallsTeleOuter).Index(8).Name("BallsTeleopOuter");
            Map(m => m.BallsTeleLower).Index(9).Name("BallsTeleopLower");
            Map(m => m.CanHang).Index(10).Name("CanHang");
            Map(m => m.CanPark).Index(11).Ignore();
            Map(m => m.IsLevel).Index(12).Name("CanLevel");
            Map(m => m.WheelPosition).Index(13).Name("WheelPosition");
            Map(m => m.WheelRotation).Index(14).Name("WheelRotation");
        }
    }
}
