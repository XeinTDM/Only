using System;
using System.Windows;
using System.Windows.Controls;


namespace OnlyDox
{
    public partial class OnlyPage : UserControl
    {
        public OnlyPage()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            // Switch to CreatePage user control
            contentControl.Content = new CreatePage(this);
        }

        public void SwitchToOnlyPage()
        {
            // Switch back to OnlyPage user control
            contentControl.Content = null;
        }
    }
}