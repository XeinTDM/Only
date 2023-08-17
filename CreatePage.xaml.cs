using System;
using System.Windows;
using System.Windows.Controls;


namespace OnlyDox
{
    public partial class CreatePage : UserControl
    {
        private OnlyPage _onlyPage;

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
            _onlyPage.SwitchToOnlyPageWithBox(firstName, secondName);
        }

    }
}