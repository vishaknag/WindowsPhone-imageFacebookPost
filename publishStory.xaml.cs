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
using System.Windows.Media.Imaging;
using $safeprojectname$.HelperClasses;

namespace $safeprojectname$
{
    public partial class Page2 : PhoneApplicationPage
    {
        
        public Page2()
        {

            InitializeComponent();

        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            Page1 appObject = new Page1();

            Uri uri = new Uri(App.imageSelected);
            BitmapImage bmp = new BitmapImage(uri);
            
            publishImage.Source = bmp;
            title.Text = App.titleEntered;
    
        }

        private WebClient webClientObj;

        private void button3_Click(object sender, RoutedEventArgs e)
        {

            if (webClientObj == null)
            {

                webClientObj = new WebClient();
                webClientObj.UploadStringCompleted += new UploadStringCompletedEventHandler(UploadString);

            }

            try
            {

                // Form a string of the form
                // access_token=765985689876764879857509439&caption=aaaaaaaaa&message=aaaaaaaa&picture=aaaaaaa

                string publishString = "access_token=" + App.AccessToken;

                if (!string.IsNullOrEmpty(App.titleEntered))
                {
                    publishString += "&caption=" + HttpUtility.UrlEncode(App.titleEntered);
                }
                
                if (!string.IsNullOrEmpty(message.Text))
                {
                    publishString += "&message=" + HttpUtility.UrlEncode(message.Text);
                }

                if (!string.IsNullOrEmpty(App.imageSelected))
                {
                    publishString += "&picture=" + HttpUtility.UrlEncode(App.imageSelected);
                }

                // Send the message title and image to facebook wall
                webClientObj.UploadStringAsync(FBUris.GetPostMessageUri(), "POST", publishString);

            }
            catch (Exception obj)
            {

                result.Text = "post to wall failed!" + obj.Message;

            }

            // Navigate back to your application
            NavigationService.Navigate(new Uri("/VishakW7App.xaml", UriKind.Relative));

        }

        void UploadString(object sender, UploadStringCompletedEventArgs e)
        {
            if (e.Error != null)
            {

                result.Text = "Post to wall failed!";
                return;

            }
            try
            {

                result.Text = "Successfully posted to wall!";

            }
            catch (Exception obj)
            {

                result.Text = "Post to wall failed!" + obj.Message;

            }
        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/VishakW7App.xaml", UriKind.Relative));
        }

    }
}