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
using System.Diagnostics;
using System.IO;
using Microsoft.Win32;
using System.Text.RegularExpressions;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace ShutterDown
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Process process;

        public bool shuttingDown;

        public bool trayClose;

        public DateTime shutdownTime;

        public NotifyIcon ni;

        SolidColorBrush statusOn = new SolidColorBrush(Colors.Red);
        SolidColorBrush statusOff = new SolidColorBrush(Colors.Green);

        public MainWindow()
        {
            InitializeComponent();

            process = new Process();
            process.StartInfo.FileName = "cmd.exe";

            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.WorkingDirectory = $@"C:\";
            process.StartInfo.LoadUserProfile = true;

            process.StartInfo.CreateNoWindow = true;

            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;

            process.OutputDataReceived += ProcessOutputDataHandler;
            process.ErrorDataReceived += ProcessErrorDataHandler;

            process.Start();
            process.BeginOutputReadLine();
            process.BeginErrorReadLine();

            var dispatcherTimer = new System.Windows.Threading.DispatcherTimer();
            dispatcherTimer.Tick += new EventHandler(DispatcherTimer_Tick);
            dispatcherTimer.Interval = new TimeSpan(0, 0, 1);
            dispatcherTimer.Start();


            
            customText.Text = Properties.Settings.Default.customMinutes;
            customHour.Text = Properties.Settings.Default.customHours;
            closeToTray.IsChecked = Properties.Settings.Default.closeToTray;
            Status.Background = statusOff;

            Console.WriteLine(Properties.Settings.Default.radioChecked);
            switch (Properties.Settings.Default.radioChecked)
            {
                case 10:
                    _10.IsChecked = true;
                    Console.WriteLine("hi1t");
                    break;
                case 20:
                    _20.IsChecked = true;
                    Console.WriteLine("hit2");
                    break;
                case 30:
                    _30.IsChecked = true;
                    Console.WriteLine("hit3");
                    break;
                case 40:
                    _40.IsChecked = true;
                    Console.WriteLine("hit4");
                    break;
                case 50:
                    _50.IsChecked = true;
                    Console.WriteLine("hit5");
                    break;
                case 60:
                    _60.IsChecked = true;
                    Console.WriteLine("hit6");
                    break;
                default:
                    Custom.IsChecked = true;
                    Console.WriteLine("hitc");
                    break;
            }
            
            switch (Properties.Settings.Default.TypeChecked)
            {
                case "Shutdown":
                    ShutdownType.IsChecked = true;
                    break;
                case "Restart":
                    RestartType.IsChecked = true;
                    break;
                case "Sleep":
                    SleepType.IsChecked = true;
                    break;
                case "Hibernate":
                    Hibernate.IsChecked = true;
                    break;
                default:
                    ShutdownType.IsChecked = true;
                    break;
            }

            // Notification Area
            ni = new System.Windows.Forms.NotifyIcon();

            using (var stream = System.Windows.Application.GetResourceStream(new Uri("pack://application:,,,/Icon1.ico")).Stream)
            {
                ni.Icon = new System.Drawing.Icon(stream);
            }
            //ni.Icon = new System.Drawing.Icon("/Resources/Icon1.ico");
          
            ni.Visible = true;
            ni.DoubleClick +=
                delegate (object sender, EventArgs args)
                {
                    this.Show();
                    this.WindowState = WindowState.Normal;
                };
            ni.ContextMenu = new System.Windows.Forms.ContextMenu();
            ni.ContextMenu.MenuItems.Add(new System.Windows.Forms.MenuItem("Exit", ni_Click));
            //ni.MouseClick += new System.Windows.Forms.MouseEventHandler(ni_Click); -- Can't remember why this was here
        }

        private void ni_Click(object sender, EventArgs e)
        {
            ni.Visible = false;
            ni.Icon.Dispose();

            ni.Dispose();

            System.Windows.Application.Current.Shutdown();
        }

        public void ProcessOutputDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            
            Console.WriteLine(outLine.Data);
        }

        public void ProcessErrorDataHandler(object sendingProcess, DataReceivedEventArgs outLine)
        {
            Console.WriteLine(outLine.Data);
        }

        private void DispatcherTimer_Tick(object sender, EventArgs e)
        {

            
            if (shuttingDown)
            {
                if (DateTime.Now > shutdownTime)
                {
                    Shutdown();
                    shuttingDown = false;   
                }
                double seconds = (shutdownTime - DateTime.Now).TotalSeconds;
                var timespan = TimeSpan.FromSeconds(seconds);
                if (timespan.Hours == 0)
                Status.Content = timespan.ToString(@"mm\:ss");
                else
                    Status.Content = timespan.ToString(@"hh\:mm\:ss");

            }
        }

        private void Shutdown()
        {
            //System.Diagnostics.Process.Start("ping", "127.0.0.1"); -- Testing
            if (ShutdownType.IsChecked == true)
                process.StandardInput.WriteLine("shutdown -f -s -t 0");
            if (RestartType.IsChecked == true)
                process.StandardInput.WriteLine("shutdown -f -r -t 0");

            if (SleepType.IsChecked == true)
            {
                _Cancel();
                System.Windows.Forms.Application.SetSuspendState(PowerState.Suspend, false, false);
            }

            if (SleepType.IsChecked == true)
            {
                _Cancel();
                System.Windows.Forms.Application.SetSuspendState(PowerState.Hibernate, false, false);
            }
            //System.Diagnostics.Process.Start("shutdown.exe", "-f -r -t 0"); -- Testing
        }

        private void TextBox_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //cancel
            _Cancel();
        }

        private void _Cancel()
        {
            Status.Background = statusOff;
            Status.Content = "Idle";

            Cancel.IsEnabled = false;
            _Shutdown.IsEnabled = true;

            ShutdownType.IsEnabled = true;
            RestartType.IsEnabled = true;
            SleepType.IsEnabled = true;

            shuttingDown = false;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            //
            Custom.IsChecked = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            //Shutdown
            Cancel.IsEnabled = true;
            _Shutdown.IsEnabled = false;
            ShutdownType.IsEnabled = false;
            SleepType.IsEnabled = false;
            RestartType.IsEnabled = false;
            Status.Background = statusOn;

            if (ShutdownType.IsChecked == true) Status.Content = "Shutting Down";
            if (SleepType.IsChecked == true) Status.Content = "Sleeping";
            if (RestartType.IsChecked == true) Status.Content = "Restarting";
            if (Hibernate.IsChecked == true) Status.Content = "Hibernating";
            

            double minutes = 1;
            double hours = 0;
            if (_10.IsChecked == true) minutes = 10;
            if (_20.IsChecked == true) minutes = 20;
            if (_30.IsChecked == true) minutes = 30;
            if (_40.IsChecked == true) minutes = 40;
            if (_50.IsChecked == true) minutes = 50;
            if (_60.IsChecked == true) minutes = 60;
            Properties.Settings.Default.radioChecked = (int)minutes;
            if (Custom.IsChecked == true)
            {
                string temp = customText.Text;
                Console.WriteLine(temp);
                double a=0;
                if(Double.TryParse(temp, out a))
                {
                    minutes = a;

                }

                string tempB = customHour.Text;
                double b = 0;
                if (Double.TryParse(tempB, out b))
                {
                    hours = (b);

                }
            }


            Console.WriteLine(minutes);

            shutdownTime = DateTime.Now.AddMinutes(minutes);
            shutdownTime = shutdownTime.AddHours(hours);
            shuttingDown = true;

            SaveSettings();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (trayClose)
            {
                e.Cancel = true;

                this.WindowState = WindowState.Minimized;
                this.Hide();
            }
            SaveSettings();
            ni.Visible = false;
            ni.Icon.Dispose();

            ni.Dispose();


            base.OnClosing(e);
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            trayClose = (bool)closeToTray.IsChecked;
           
        }

        private void SaveSettings()
        {
            double minutes = 1;
            if (_10.IsChecked == true) minutes = 10;
            if (_20.IsChecked == true) minutes = 20;
            if (_30.IsChecked == true) minutes = 30;
            if (_40.IsChecked == true) minutes = 40;
            if (_50.IsChecked == true) minutes = 50;
            if (_60.IsChecked == true) minutes = 60;
            Properties.Settings.Default.radioChecked = (int)minutes;
            Properties.Settings.Default.TypeChecked = _Shutdown.Content.ToString();
            Properties.Settings.Default.customMinutes = customText.Text;
            Properties.Settings.Default.customHours = customHour.Text;
            Properties.Settings.Default.closeToTray = trayClose;
            Properties.Settings.Default.Save();
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void SuspendTypeRadio_Checked(object sender, RoutedEventArgs e)
        {
            if (ShutdownType.IsChecked == true) _Shutdown.Content = "Shutdown";
            if (SleepType.IsChecked == true) _Shutdown.Content = "Sleep";
            if (RestartType.IsChecked == true) _Shutdown.Content = "Restart";
            if (Hibernate.IsChecked == true) _Shutdown.Content = "Hibernate";
        }

    }
}
