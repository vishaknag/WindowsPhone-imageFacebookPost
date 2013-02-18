using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Microsoft.Phone.Controls;

namespace $safeprojectname$
{
    public partial class logout : PhoneApplicationPage
    {
        public logout()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            txtStatus.Text = "Logging out";

            string strLogoutURL2 = "http://m.facebook.com/logout.php?confirm=1&next=" + HttpUtility.UrlEncode("http://www.facebook.com");
            wbLogout.Navigate(new Uri(strLogoutURL2, UriKind.Absolute));
        }

        private void wbLogout_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

            txtStatus.Text = "Successfully logged out";

            App.AccessToken = null;

            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));

        }

        
    }
}