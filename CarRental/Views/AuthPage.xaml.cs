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
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {

        Core db = new Core();
        public AuthPage() 
        {
            InitializeComponent();
        }

        private void CreateAccountTextBlockMouseDown(object sender, MouseButtonEventArgs e)
        {
            NavigationService.Navigate(new RegPage());
        }

        private void SingInButtonClick(object sender, RoutedEventArgs e)
        {
            UsersViewModel obj = new UsersViewModel();
            obj.Autorization(AuthLoginTextBox.Text, AuthPasswordTextBox.Text);

            if (obj.Autorization(AuthLoginTextBox.Text, AuthPasswordTextBox.Text) == true)
            {
                obj.GetRole(AuthLoginTextBox.Text, AuthPasswordTextBox.Text);
                if (obj.GetRole(AuthLoginTextBox.Text, AuthPasswordTextBox.Text) == 1)
                {
                    NavigationService.Navigate(new AdminMenu());
                }
                if (obj.GetRole(AuthLoginTextBox.Text, AuthPasswordTextBox.Text) == 2)
                {
                    NavigationService.Navigate(new AutomobilePage());
                }
            }
        }
    }
}
