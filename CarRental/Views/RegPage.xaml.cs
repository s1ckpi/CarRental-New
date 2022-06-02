using CarRental.Models;
using CarRental.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CarRental.Views
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        Core db = new Core();
        public RegPage()
        {
            InitializeComponent();
        }

        private void SingUpTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new AuthPage());
        }

        private void RegButtonClick(object sender, RoutedEventArgs e)
        {
            if (RegPasswordTextBox.Text == RegConfirmPasswordTextBox.Text)
            {
                UsersViewModel obj = new UsersViewModel();
                obj.Registration(RegLoginTextBox.Text, RegPasswordTextBox.Text, RegEmailTextBox.Text, DriverLicenseNumberTextBox.Text,
                    RegFirstNameTextBox.Text, RegLastNameTextBox.Text, RegPatronymicNameTextBox.Text, PhoneTextBox.Text);
            }

            NavigationService.Navigate(new AuthPage());
        }
    }
}
