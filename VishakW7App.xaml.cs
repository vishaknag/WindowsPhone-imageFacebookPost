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
    public partial class Page1 : PhoneApplicationPage
    {

        public Page1()
        {
            InitializeComponent();
        }

        private void PhoneApplicationPage_Loaded(object sender, RoutedEventArgs e)
        {

            bool bWeAreLoggedIn = !string.IsNullOrEmpty(App.AccessToken);
            postToWallBtn.IsEnabled = bWeAreLoggedIn;

        }

        private void postToWallBtn_Click(object sender, RoutedEventArgs e)
        {

            // Fetch the text entered and the image selected by the user  
            App.imageSelected = App.imageLinks[App.selected];
            App.titleEntered = fbMessage.Text;

            // Navigate to the publish story page
            NavigationService.Navigate(new Uri("/publishStory.xaml", UriKind.Relative));

        }

        private void button2_Click(object sender, RoutedEventArgs e)
        {

            NavigationService.Navigate(new Uri("/logout.xaml", UriKind.Relative));
     
        }

        private void image1_Click(object sender, RoutedEventArgs e)
        {

            // Image 1 is selected
            App.selected = 0;
            image1.Opacity = 1;
            image2.Opacity = 0.4;
            image3.Opacity = 0.4;
            image4.Opacity = 0.4;

        }

        private void image2_Click(object sender, RoutedEventArgs e)
        {

            // Image 2 is selected
            App.selected = 1;
            image1.Opacity = 0.4;
            image2.Opacity = 1;
            image3.Opacity = 0.4;
            image4.Opacity = 0.4;

        }

        private void image3_Click(object sender, RoutedEventArgs e)
        {

            // Image 3 is selected
            App.selected = 2;
            image1.Opacity = 0.4;
            image2.Opacity = 0.4;
            image3.Opacity = 1;
            image4.Opacity = 0.4;

        }

        private void image4_Click(object sender, RoutedEventArgs e)
        {

            // Image 4 is selected
            App.selected = 3;
            image1.Opacity = 0.4;
            image2.Opacity = 0.4;
            image3.Opacity = 0.4;
            image4.Opacity = 1;

        }

    }
}