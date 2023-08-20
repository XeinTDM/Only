using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace OnlyDox
{
    public partial class CreatePage : UserControl
    {
        private readonly OnlyPage _onlyPage;
        private bool isDragging = false;
        private Point lastPosition;

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
            string MiddleName = MiddleNameTextBox.Text;
            ImageSource selectedImageSource = SelectedImage.Source;
            double imageX = Canvas.GetLeft(SelectedImage);
            double imageY = Canvas.GetTop(SelectedImage);
            _onlyPage.SwitchToOnlyPageWithBox(firstName, secondName, MiddleName, selectedImageSource, imageX, imageY);
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

                // Always stretch the image to fill the width of the canvas
                SelectedImage.Width = 125;
                SelectedImage.Height = 125 * (image.Height / image.Width);

                // Reset image position within the canvas
                Canvas.SetLeft(SelectedImage, 0);
                Canvas.SetTop(SelectedImage, 0);
            }
        }

        private void Image_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            isDragging = true;
            lastPosition = e.GetPosition(ImageCanvas);
            SelectedImage.CaptureMouse();
        }

        private void Image_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDragging)
            {
                var currentPosition = e.GetPosition(ImageCanvas);
                var offsetX = currentPosition.X - lastPosition.X;
                var offsetY = currentPosition.Y - lastPosition.Y;

                var newX = Canvas.GetLeft(SelectedImage) + offsetX;
                var newY = Canvas.GetTop(SelectedImage) + offsetY;

                Canvas.SetLeft(SelectedImage, newX);
                Canvas.SetTop(SelectedImage, newY);

                lastPosition = currentPosition;
            }
        }

        private void Image_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            isDragging = false;
            SelectedImage.ReleaseMouseCapture();
        }
    }
}