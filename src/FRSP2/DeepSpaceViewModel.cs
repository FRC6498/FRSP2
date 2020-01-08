using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FRSP2.Utility;

namespace FRSP2
{
    public class DeepSpaceViewModel : ViewModel
    {
        private int _sandstormCargoLvl1;
        public int SandstormCargoLvl1
        {
            get => _sandstormCargoLvl1;
            set => SetProperty(ref _sandstormCargoLvl1, value);
        }
        public int SandstormCargoLvl2 { get; set; }
        public int SandstormCargoLvl3 { get; set; }

        public int SandstormHatchesLvl1 { get; set; }
        public int SandstormHatchesLvl2 { get; set; }
        public int SandstormHatchesLvl3 { get; set; }

        public StartLevel StartLevel { get; set; }

        public bool HabExit { get; set; }


    }
}
