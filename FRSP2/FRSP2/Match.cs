using FRSP2.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FRSP2
{
    namespace Modules
    {
        public class Match
        {
            private int _matchid;
            private WatchPosition _pos;

            public Int32 MatchID
            {
                get
                {
                    return _matchid;
                }
                set
                {
                    _matchid = value;
                }
            }
            public WatchPosition Position
            {
                get
                {
                    return _pos;
                }
                set
                {
                    _pos = value;
                }
            }

            public Match(int id, WatchPosition pos)
            {
                MatchID = id;
                Position = pos;
            }
        }
    }
    
}
