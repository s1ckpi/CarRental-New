using CarRental.Models;
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
    /// Логика взаимодействия для ClientsPage.xaml
    /// </summary>
    public partial class ClientsPage : Page
    {
        Core db = new Core();
        List<Clients> arrayClients;
        public ClientsPage()
        {
            InitializeComponent();
            arrayClients = db.context.Clients.ToList();
            ListClientListView.ItemsSource = arrayClients;
        }

        private void UpdateServices()
        {
            arrayClients = db.context.Clients.ToList();
            ListClientListView.ItemsSource = arrayClients;

            //Поиск по названию (регистронезавимый)
            arrayClients = arrayClients.Where(x => x.DriverLicenseNumber.ToLower().Contains(SearchDriverLicenseTextBox.Text.ToLower())).ToList();

            ListClientListView.ItemsSource = null;
            ListClientListView.ItemsSource = arrayClients;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMenu());
        }

        private void SearchTextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }
    }
}
