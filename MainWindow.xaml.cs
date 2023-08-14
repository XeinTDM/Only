using OnlyDox;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;

namespace  OnlyDox
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            NavigateToPage(new HomePage());
        }

        private void NavigateToPage(UserControl page)
        {
            // Animation
            DoubleAnimation fadeAnimation = new DoubleAnimation
            {
                From = 0.0,
                To = 1.0,
                Duration = new Duration(TimeSpan.FromSeconds(0.5))
            };
            page.BeginAnimation(UIElement.OpacityProperty, fadeAnimation);

            ContentFrame.Content = page;
        }

        private void HomeBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new HomePage());
        }

        private void OnlyBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new OnlyPage());
        }

        private void SettingsBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigateToPage(new SettingsPage());
        }
    }
}
