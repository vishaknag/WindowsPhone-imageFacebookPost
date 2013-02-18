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
using $safeprojectname$.HelperClasses;

namespace $safeprojectname$
{
    public partial class login : PhoneApplicationPage
    {
        public login()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {
            wbLogin.Navigate(FBUris.GetLoginUri());
        }

        private void wbLogin_LoadCompleted(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

         /* STEP1: Check if the code is obtained correctly */

         /* string strLoweredAddress = e.Uri.OriginalString.ToLower();

            if(strLoweredAddress.StartsWith("http://www.facebook.com/connect/login_success.html?code=")) {
                txtStatus.Text = "We got the code";
                txtError.Text = e.Uri.OriginalString.Substring(56);
                return;
            }
          */ 

          /* STEP2 : Check if the Access token is obtained correctly in the body of the success page */

          /*  string strLoweredAddress = e.Uri.OriginalString.ToLower();
            if(strLoweredAddress.StartsWith("http://www.facebook.com/connect/login_success.html?code=")) {
                txtStatus.Text = "Trying to retrieve access token";
                wbLogin.Navigate(FBUris.GetTokenLoadUri(e.Uri.OriginalString.Substring(56)));
                return;
            }
           */ 

           /* STEP3: */
            string strLoweredAddress = e.Uri.OriginalString.ToLower();
            if (strLoweredAddress.StartsWith("http://www.facebook.com/connect/login_success.html?code="))
            {
                txtStatus.Text = "Trying to retrieve access token";
                wbLogin.Navigate(FBUris.GetTokenLoadUri(e.Uri.OriginalString.Substring(56)));
                return;
            }

            string strTest = wbLogin.SaveToString();

            if (strTest.Contains("access_token"))
            {
                int nPos = strTest.IndexOf("access_token");
                string strPart = strTest.Substring(nPos + 13);

                nPos = strPart.IndexOf("</PRE>");
                strPart = strPart.Substring(0, nPos);
                App.AccessToken = strPart;

                //automatically leave the page after login success
                txtStatus.Text = "Authenticated";

                nPos = strPart.IndexOf("&expires=");
                if (nPos != -1)
                {
                    strPart = strPart.Substring(0, nPos);
                }

                NavigationService.Navigate(new Uri("/VishakW7App.xaml", UriKind.Relative));
                return;
            }

        }
    }
}