﻿using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

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

        public void SwitchToOnlyPageWithBox(string firstName, string secondName, string MiddleName, ImageSource imageSource, double imageX, double imageY)
        {
            contentControl.Content = null;
            CreateBox(firstName, secondName, MiddleName, imageSource, imageX, imageY);
        }

        private void CreateBox(string firstName, string secondName, string MiddleName, ImageSource imageSource, double imageX, double imageY)
        {
            StackPanel boxContent = new();

            Image boxImage = new()
            {
                Width = 125,
                Height = 125,
                Source = imageSource,
                HorizontalAlignment = HorizontalAlignment.Left,
                VerticalAlignment = VerticalAlignment.Top,
                Stretch = Stretch.UniformToFill
            };

            boxContent.Children.Add(boxImage);

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

            TextBlock MiddleNameTextBox = new()
            {
                Text = "Middle Name: " + MiddleName
            };
            boxContent.Children.Add(MiddleNameTextBox);

            Button closeButton = new()
            {
                Content = "X",
                Width = 20,
                Height = 20,
                HorizontalAlignment = HorizontalAlignment.Right,
                VerticalAlignment = VerticalAlignment.Top
            };

            Border box = new()
            {
                Width = 250,
                Height = 300,
                Background = Brushes.White,
                Margin = new Thickness(15),
                Child = boxContent
            };

            Canvas.SetLeft(box, imageX);
            Canvas.SetTop(box, imageY);
            box.UpdateLayout();
            Canvas.SetZIndex(box, 1);

            closeButton.Click += (sender, e) =>
            {
                boxContainer.Children.Remove(box);
            };

            boxContent.Children.Add(closeButton);
            boxContainer.Children.Add(box);
        }

    }
}