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
        List<Kysymys> kyssarit = KysymystenLuoja.LuoKysymykset();
        Kysymys kysymys;
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
                kysymys = kyssarit[int.Parse(msg) - 1];
                txtQuestion.Text = "Kysymys numero " + kysymys.KysymysNro + ": " + kysymys.KysymysTxt;
                answer1Btn.Content = kysymys.VastausVaihtoehdot[0];
                answer2Btn.Content = kysymys.VastausVaihtoehdot[1];
                answer3Btn.Content = kysymys.VastausVaihtoehdot[2];
                answer4Btn.Content = kysymys.VastausVaihtoehdot[3];
            }

        }

        private void btnHome_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
        }

        protected override void OnBackKeyPress(System.ComponentModel.CancelEventArgs e)
        {
            //MessageBox.Show("Haluatko poistua?");
            //e.Cancel = true;
            //Do your work here
            //base.OnBackKeyPress(e);
            NavigationService.Navigate(new Uri("/HomePage.xaml", UriKind.Relative));
        }

        private void VastausPalaute(int kysymysNro)
        {
            
            if (kysymys.VastausVaihtoehdot[kysymysNro - 1] == kysymys.OikeaVastaus)
            {
                if (HomePage.vastauksiaOikein == 0)
                {
                    HomePage.vastauksiaOikein = 1;
                }
                else
                {
                    HomePage.vastauksiaOikein++;
                }
            }
            else
            {
                if (HomePage.vastauksiaVaarin == 0)
                {
                    HomePage.vastauksiaVaarin = 1;
                }
                else
                {
                    HomePage.vastauksiaVaarin++;
                }
            }
        }

    
        private void answer1Btn_Click(object sender, RoutedEventArgs e)
        {
            VastausPalaute(1);
        }

        private void answer2Btn_Click(object sender, RoutedEventArgs e)
        {
            VastausPalaute(2);
        }

        private void answer3Btn_Click(object sender, RoutedEventArgs e)
        {
            VastausPalaute(3);
        }

        private void answer4Btn_Click(object sender, RoutedEventArgs e)
        {
            VastausPalaute(4);
        }
    }
}