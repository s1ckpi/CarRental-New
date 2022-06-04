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
    /// Логика взаимодействия для AdminPage.xaml
    /// </summary>
    public partial class AdminPage : Page
    {
        Core db = new Core();
        List<Cars> arrayCars;
        List<Brand> arrayBrandCars;
        List<CarcassType> arrayCarcassCars;
        public AdminPage()
        {
            InitializeComponent();
            arrayCars = db.context.Cars.ToList();

            ListAutomobileListView.ItemsSource = arrayCars;

            arrayCarcassCars = new List<CarcassType>()
            {
                new CarcassType()
                    {
                        CarcassName="Все Кузова",
                        IdCarcassType=0
                    }
            };

            arrayCarcassCars.AddRange(db.context.CarcassType.ToList());

            List<string> PriceCars = new List<string> { "Все цены", "от 0 до 50 000", "от 50 000 до 100 000", "от 100 000 до 150 000" };

            arrayBrandCars = new List<Brand>()
            {
                new Brand()
                    {
                        BrandName="Все бренды",
                        IdBrand=0
                    }
            };

            arrayBrandCars.AddRange(db.context.Brand.ToList());

            CarcassComboBox.ItemsSource = arrayCarcassCars;
            CarcassComboBox.DisplayMemberPath = "CarcassName";
            CarcassComboBox.SelectedValuePath = "IdCarcassType";
            CarcassComboBox.SelectedIndex = 0;

            PriceComboBox.ItemsSource = PriceCars;

            BrandComboBox.ItemsSource = arrayBrandCars;
            BrandComboBox.DisplayMemberPath = "BrandName";
            BrandComboBox.SelectedValuePath = "IdBrand";
            BrandComboBox.SelectedIndex = 0;
            UpdateServices();
        }

        private void EditButtonClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            Cars item = selectedButton.DataContext as Cars;
            NavigationService.Navigate(new AddModel(db.context, item));
        }

        private void DeleteButtonClick(object sender, RoutedEventArgs e)
        {
            Button selectedButton = sender as Button;
            Cars item = selectedButton.DataContext as Cars; 
            MessageBoxResult result = MessageBox.Show("Вы действительно хотите удалить строку?", "Удаление", MessageBoxButton.YesNo, MessageBoxImage.Question);
            if (result == MessageBoxResult.Yes)
            {
                db.context.Cars.Remove(item);
                db.context.SaveChanges();
                MessageBox.Show("Данные удалены");
            }

            //обновление DataGrid
            ListAutomobileListView.ItemsSource = db.context.Cars.ToList();
        }

        private void AddAutomobileButtonClick(object sender, RoutedEventArgs e)
        {
            Cars item = new Cars();
            db.context.Cars.Add(item);
            NavigationService.Navigate(new AddModel(db.context, item));
        }

        private void UpdateServices()
        {
            arrayCars = db.context.Cars.ToList();
            ListAutomobileListView.ItemsSource = arrayCars;
            //Сортировка по цене
            if (PriceComboBox.SelectedIndex != 0)
            {
                if (PriceComboBox.SelectedIndex == 1)
                {
                    arrayCars = arrayCars.Where(x => x.Price >= 0 && x.Price <= 50000).ToList();
                }
                if (PriceComboBox.SelectedIndex == 2)
                {
                    arrayCars = arrayCars.Where(x => x.Price >= 50000 && x.Price <= 100000).ToList();
                }
                if (PriceComboBox.SelectedIndex == 3)
                {
                    arrayCars = arrayCars.Where(x => x.Price >= 100000 && x.Price <= 150000).ToList();
                }
            }
            //сортироска по брэнду
            if (BrandComboBox.SelectedItem != null && BrandComboBox.SelectedIndex != 0)
            {
                int activeIdBrand = Convert.ToInt32(BrandComboBox.SelectedValue);
                arrayCars = arrayCars.Where(x => x.CarsModels.Brand.IdBrand == activeIdBrand).ToList();
            }
            //сортироска по кузову
            if (CarcassComboBox.SelectedIndex != 0 && CarcassComboBox.SelectedItem != null)
            {
                int activeIdCarcassType = Convert.ToInt32(CarcassComboBox.SelectedValue);
                Console.WriteLine(activeIdCarcassType);
                arrayCars = arrayCars.Where(x => x.IdCarcassType == activeIdCarcassType).ToList();

                foreach (var item in arrayCars)
                {
                    Console.WriteLine(item.CarsModels.ModelCar);
                }
            }

            //Поиск по названию (регистронезавимый)
            arrayCars = arrayCars.Where(x => x.CarsModels.ModelCar.ToLower().Contains(AdminSearchModelTextBox.Text.ToLower())).ToList();

            ListAutomobileListView.ItemsSource = null;
            ListAutomobileListView.ItemsSource = arrayCars;
        }

        private void PriceComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void SearchTextBoxSelectionChanged(object sender, RoutedEventArgs e)
        {
            UpdateServices();
        }

        private void CarcassComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void BrandComboBoxSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateServices();
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminMenu());
        }
    }
}