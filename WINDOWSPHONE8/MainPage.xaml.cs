using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using WINDOWSPHONE8.Resources;

namespace WINDOWSPHONE8
{
    public partial class MainPage : PhoneApplicationPage
    {
        public static string _userName;
        public MainPage()
        {
            InitializeComponent();

        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            _userName = this.txtUserName.Text;
            NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            Application.Current.Terminate();
        }
    }
}