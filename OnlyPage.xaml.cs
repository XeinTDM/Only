using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

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

        public void SwitchToOnlyPageWithBox(string firstName, string secondName)
        {
            contentControl.Content = null;
            CreateBox(firstName, secondName);
        }

        private void CreateBox(string firstName, string secondName)
        {
            StackPanel boxContent = new();

            TextBlock firstNameTextBlock = new()
            {
                Text = "First Name: " + firstName
            };
            boxContent.Children.Add(firstNameTextBlock);

            TextBlock secondNameTextBlock = new()
            {
                Text = "Second Name: " + secondName
            };
            boxContent.Children.Add(secondNameTextBlock);

            Button closeButton = new()
            {
                Content = "X",
                Width = 20,
                Height = 20,
                HorizontalAlignment = HorizontalAlignment.Right
            };

            Border box = new()
            {
                Width = 250,
                Height = 100,
                Background = Brushes.White,
                Margin = new Thickness(5),
                Child = boxContent
            };

            closeButton.Click += (sender, e) =>
            {
                boxContainer.Children.Remove(box);
            };

            boxContent.Children.Add(closeButton);
            boxContainer.Children.Add(box);
        }

    }
}