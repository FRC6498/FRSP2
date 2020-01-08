using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FRSP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var dsvm = new DeepSpaceViewModel();
            // VM variable assignments
            #region Sandstorm
            dsvm.SandstormCargoLvl1 = (int)lblSandstormCargo_lvl1.Content;
            dsvm.SandstormCargoLvl2 = (int)lblSandstormCargo_lvl2.Content;
            dsvm.SandstormCargoLvl3 = (int)lblSandstormCargo_lvl3.Content;

            dsvm.SandstormHatchesLvl1 = (int)lblSandstormHatch_lvl1.Content;
            dsvm.SandstormHatchesLvl2 = (int)lblSandstormHatch_lvl2.Content;
            dsvm.SandstormHatchesLvl3 = (int)lblSandstormHatch_lvl3.Content;

            dsvm.StartLevel = (Utility.StartLevel)Enum.Parse(typeof(Utility.StartLevel), cboStartLevel.SelectedItem.ToString());
            dsvm.HabExit = (bool)chkPassLine.IsChecked;
            #endregion



            DataContext = dsvm;
            InitializeComponent();
        }
    }
}
