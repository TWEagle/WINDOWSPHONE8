using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace WINDOWSPHONE8
{
    public partial class HomePage : PhoneApplicationPage
    {
        public static int vastauksiaOikein;
        public static int vastauksiaVaarin;
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            AlustaOikeinVaarin();
            this.txtUser.Text = "Tervetuloa pelaamaan " + MainPage._userName + ".";
        }


        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            base.OnNavigatingFrom(e);
        }
        private void btnToQuestion_Click(object sender, RoutedEventArgs e)
        {
            //string kysymys = "Mikä on aakkosten ensimmäinen kirjain?";
            NavigationService.Navigate(new Uri("/QuestionPage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //Do your work here

            //MessageBox.Show("Haluatko poistua?");
            //e.Cancel = true;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }

        private void cameraBtn_Tap(object sender, System.Windows.Input.GestureEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScannerPage.xaml", UriKind.Relative));
        }

        private void AlustaOikeinVaarin()
        {
            int sumOikein = vastauksiaOikein;
            int sumVaarin = vastauksiaVaarin; 

            if(sumOikein == 0)
            {
                oikeinTxt.Text = "Vastauksia oikein: - ";
            }
            else
            {
                oikeinTxt.Text = "Vastauksia oikein: " + sumOikein;
            }
            
            if(sumVaarin == 0)
            {
                vaarinTxt.Text = "Vastauksia väärin: - ";
            }
            else
            {
                vaarinTxt.Text = "Vastauksia väärin: " + sumVaarin;
            }
        }
    }
}