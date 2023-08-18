using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OnlyDox
{
    public partial class CreatePage : UserControl
    {
        private readonly OnlyPage _onlyPage;

        public CreatePage(OnlyPage onlyPage)
        {
            InitializeComponent();
            _onlyPage = onlyPage;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            // Switch back to OnlyPage user control
            _onlyPage.SwitchToOnlyPage();
        }

        private void AddProfileBtn_Click(object sender, RoutedEventArgs e)
        {
            string firstName = FirstNameTextBox.Text;
            string secondName = SecondNameTextBox.Text;
            ImageSource selectedImageSource = SelectedImage.Source;
            _onlyPage.SwitchToOnlyPageWithBox(firstName, secondName, selectedImageSource);
        }

        private void SelectImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new()
            {
                Filter = "Image files (*.png;*.jpeg;*.jpg;*.bmp)|*.png;*.jpeg;*.jpg;*.bmp"
            };

            if (openFileDialog.ShowDialog() == true)
            {
                var image = new BitmapImage(new Uri(openFileDialog.FileName));
                SelectedImage.Source = image;
            }
        }

    }
}