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
        public HomePage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            this.txtUser.Text = "Tervetuloa pelaamaan " + MainPage._userName + ".";
            
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void btnCamera_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/ScannerPage.xaml", UriKind.Relative));
        }

        private void btnToQuestion_Click(object sender, RoutedEventArgs e)
        {
            string kysymys = "Mikä on aakkosten ensimmäinen kirjain?";
            NavigationService.Navigate(new Uri("/QuestionPage.xaml", UriKind.Relative));
        }
    }
}