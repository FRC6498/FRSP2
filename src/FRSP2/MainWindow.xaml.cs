﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using FRSP2.CSVExport;
using FRSP2.ViewModel;

namespace FRSP2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CSVExporter csvExport = new CSVExporter();
        public static Robot r = new Robot();
        public string exc;
        [DllImport("Kernel32")]
        public static extern void AllocConsole();

        [DllImport("Kernel32")]
        public static extern void FreeConsole();

        public MainWindow()
        {
            InitializeComponent();

            Robot.self = r;
            List<String> watchPositions = new List<String>
            {
                "Red 1",
                "Red 2",
                "Red 3",
                "Blue 1",
                "Blue 2",
                "Blue 3"
            };

           

            cboPosition.ItemsSource = watchPositions;

            GrdTop.DataContext = r;
            AllocConsole();
            
        }

        // Inner Value Variable
        int iv = 0;

        private void BtnExit_Click(object sender, RoutedEventArgs e)
        {
            FreeConsole();
            Application.Current.Shutdown();
        }

        private void BtnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // match info
                r.TeamNumber = int.Parse(txtRobotNum.Text);
                r.MatchNumber = int.Parse(txtMatchNum.Text);
                r.WatchPos = cboPosition.SelectedItem.ToString();

                // auto
                r.BallsAutoInner = int.Parse(txtAutoInnerValue.Text);
                r.BallsAutoOuter = int.Parse(txtAutoOuterValue.Text);
                r.BallsAutoLower = int.Parse(txtAutoLowerValue.Text);
                r.CrossedAutoLine = (bool)AutoCrossedLine.IsChecked;

                //teleop
                r.BallsTeleInner = int.Parse(teleopInnerValue.Text);
                r.BallsTeleLower = int.Parse(teleopLowerValue.Text);
                r.BallsTeleOuter = int.Parse(teleopOuterValue.Text);
                r.CanHang = (bool)chkClimb.IsChecked;
                r.CanPark = (bool)chkPark.IsChecked;
                r.IsLevel = (bool)chkCanLevel.IsChecked;
                r.WheelRotation = (bool)chkPanelRotation.IsChecked;
                r.WheelPosition = (bool)chkPanelPosition.IsChecked;
                MessageBox.Show("Values assigned");
                
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex.InnerException);
            }

            CSVExporter.current = r;
            MessageBox.Show("robot sent to exporter");
            csvExport.Export();
            MessageBox.Show("Thread Started");
            r.Reset();
        }

        private void Decrement(object sender)
        {
            TextBlock txt = (TextBlock)sender;
            int val = 0;
            try
            {
                int.TryParse(txt.Text, out val);
            }
            catch(Exception e)
            {
                exc = e.ToString();
            }
            if (val == 0)
            {
                txt.Text = "0";
            }
            else if(val > 0)
            {
                val--;
                txt.Text = val.ToString();
            }
        }

        private void Increment(object sender)
        {
            TextBlock txt = (TextBlock)sender;
            int val;
            int.TryParse(txt.Text, out val);
            val++;
            txt.Text = val.ToString();
        }

        private void BtnAutoInnerIncrement_Click(object sender, RoutedEventArgs e)
        {
            Increment(txtAutoInnerValue);
        }
        private void BtnAutoInnerDecrement_Click(object sender, RoutedEventArgs e)
        {
            Decrement(txtAutoInnerValue);
        }

        private void BtnAutoOuterDecrement_Click(object sender, RoutedEventArgs e)
        {
            Decrement(txtAutoOuterValue);
        }

        private void BtnAutoOuterIncrement_Click(object sender, RoutedEventArgs e)
        {
            Increment(txtAutoOuterValue);
        }

        private void BtnAutoLowerDecrement_Click(object sender, RoutedEventArgs e)
        {
            Decrement(txtAutoLowerValue);
        }

        private void BtnAutoLowerIncrement_Click(object sender, RoutedEventArgs e)
        {
            Increment(txtAutoLowerValue);
        }

        private void ResetForm()
        {
            txtAutoInnerValue.Text = 0.ToString();
            txtAutoLowerValue.Text = 0.ToString();
            txtAutoOuterValue.Text = 0.ToString();
            chkClimb.IsChecked = false;
            chkPanelPosition.IsChecked = false;
            chkPanelRotation.IsChecked = false;
        }

        private void BtnTeleopInnerDecrement_Click(object sender, RoutedEventArgs e)
        {
            Decrement(teleopInnerValue);
        }

        private void BtnTeleopInnerIncrement_Click(object sender, RoutedEventArgs e)
        {
            Increment(teleopInnerValue);
        }

        private void BtnTeleopOuterDecrement_Click(object sender, RoutedEventArgs e)
        {
            Decrement(teleopOuterValue);
        }

        private void BtnTeleopOuterIncrement_Click(object sender, RoutedEventArgs e)
        {
            Increment(teleopOuterValue);
        }

        private void BtnTeleopLowerDecrement_Click(object sender, RoutedEventArgs e)
        {
            Decrement(teleopLowerValue);
        }

        private void BtnTeleopLowerIncrement_Click(object sender, RoutedEventArgs e)
        {
            Increment(teleopLowerValue);
        }
    }
}