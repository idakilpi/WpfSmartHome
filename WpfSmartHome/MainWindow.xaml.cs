using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.ConstrainedExecution;
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
using System.Windows.Threading;

namespace WpfSmartHome
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Lights KitchenLight = new Lights();
        Lights LivingroomLight = new Lights();
        Sauna HouseSauna = new Sauna();
        Thermostat HouseTemperature = new Thermostat();

        public DispatcherTimer SaunaTimerUp = new DispatcherTimer();
        public DispatcherTimer SaunaTimerDown = new DispatcherTimer();

        public MainWindow()
        {
            InitializeComponent();

            cgSaunaTimer.CurrentValue = 20;
            HouseSauna.SaunaTemperature = 20;

            SaunaTimerUp.Tick += SaunaTimerUp_Tick;
            SaunaTimerUp.Interval = new TimeSpan(0, 0, 0, 1);

            SaunaTimerDown.Tick += SaunaTimerDown_Tick;
            SaunaTimerDown.Interval = new TimeSpan(0, 0, 0, 1);


        }
        private void SaunaTimerDown_Tick(object sender, EventArgs e)
        {
            if(HouseSauna.SaunaTemperature >20)
            {
                btnSaunaOff.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                SaunaTimerDown.Stop();
            }
        }
        private void SaunaTimerUp_Tick(object sender, EventArgs e)
        {
            if(HouseSauna.SaunaTemperature < 100)
            {
                btnSaunaOn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                SaunaTimerUp.Stop();
                txtSauna.Text = "Sauna is ready!";
            }
        }


        private void btnKitchenLightOn_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnKitchenLightOn)
            {
                KitchenLight.LightOn();
                if (KitchenLight.Switched == true)
                {
                    btnOnOff.Background = Brushes.Yellow;
                    btnOnOff.Content = "LIGHT ON!";
                    btnOnOff.Foreground = Brushes.Black;
                }
            }
        }

        private void btnKitchenLightOff_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnKitchenLightOff)
            {
                KitchenLight.LightOff();
                if (KitchenLight.Switched2 == false)
                {
                    btnOnOff.Background = Brushes.White;
                    btnOnOff.Content = "LIGHT OFF!";
                    btnOnOff.Foreground = Brushes.Black;
                }
            }
        }

        private void btnLivingroomLightsOn_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnLivingroomLightsOn)
            {
                LivingroomLight.LightOn();
                if (LivingroomLight.Switched == true)
                {
                    btnOnOff2.Background = Brushes.Yellow;
                    btnOnOff2.Content = "LIGHT ON!";
                    btnOnOff2.Foreground = Brushes.Black;
                }
            }
        }

        private void btnLivingroomLightsOff_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnLivingroomLightsOff)
            {
                LivingroomLight.LightOff();
                if (LivingroomLight.Switched2 == false)
                {
                    btnOnOff2.Background = Brushes.White;
                    btnOnOff2.Content = "LIGHT OFF!";
                    btnOnOff2.Foreground = Brushes.Black;
                }
            }
        }

        private void sliderKitchen_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            KitchenLight.Dimmer = sliderKitchen.Value.ToString();
            if (sliderKitchen.Value > 0)
            {
                KitchenLight.Switched2 = true;
                txtKitchen.Text = sliderKitchen.Value.ToString();
                btnKitchenLightOn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                btnKitchenLightOff.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void sliderLivingroom_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            LivingroomLight.Dimmer = sliderLivingroom.Value.ToString();
            if (sliderLivingroom.Value > 0)
            {
                LivingroomLight.Switched2 = true;
                txtLivingroom.Text = sliderLivingroom.Value.ToString();
                btnLivingroomLightsOn.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            else
            {
                btnLivingroomLightsOff.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        private void btnSaunaOn_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSaunaOn)
            {
                HouseSauna.SaunaOn();
                if (HouseSauna.SaunaSwitched == true)
                {
                    SaunaTimerUp.Start();
                    btnSauna.Background = Brushes.Red;
                    btnSauna.Content = "...";
                    btnSauna.Foreground = Brushes.Black;
                    txtSauna.Text = "";
                    txtSauna.Text = "Sauna is heating" + "\n" +
                                    HouseSauna.SaunaTemperature.ToString();
                    cgSaunaTimer.CurrentValue = HouseSauna.SaunaTemperature;
                }
            }
        }



        private void btnSaunaOff_Click(object sender, RoutedEventArgs e)
        {
            if (sender == btnSaunaOff)
            {
                HouseSauna.SaunaOff();
                if (HouseSauna.SaunaSwitched2 == false)
                {
                    SaunaTimerDown.Start();
                    SaunaTimerUp.Stop();
                    btnSauna.Background = Brushes.White;
                    btnSauna.Content = "";
                    btnSauna.Foreground = Brushes.White;
                    txtSauna.Text = "Sauna is switched off" + "\n" +
                                    HouseSauna.SaunaTemperature.ToString();
                    cgSaunaTimer.CurrentValue = HouseSauna.SaunaTemperature;
                }
            }
        }

        private void btnTemperature_Click(object sender, RoutedEventArgs e)
        {
            Boolean ok = true;
            try
            {
                HouseTemperature.SetTemperature(int.Parse(txtHeat1.Text));
                txtHeat2.Text = int.Parse(txtHeat1.Text).ToString();
            }
            catch (Exception)
            {
                txtHeat1.Text = "";
                txtHeat1.Focus();
                ok = false;
            }
            if (ok)
            {
                txtHeat1.Text = "";
                txtHeat1.Focus();
            }
        }
    }
}

