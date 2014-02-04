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
    public partial class QuestionPage : PhoneApplicationPage
    {
        public QuestionPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            string msg = "";

            if (NavigationContext.QueryString.TryGetValue("kysymys", out msg))
            {
                txtQuestion.Text = msg;
            }

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show("Haluatko poistua?");
            e.Cancel = true;
            //Do your work here
            //base.OnBackKeyPress(e);
        }
    }
}