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
    /// Логика взаимодействия для AddCarsModels.xaml
    /// </summary>
    public partial class AddCarsModels : Page
    {
        Core db = new Core();
        List<Brand> arrayBrandCars;
        public AddCarsModels()
        {
            InitializeComponent();

            arrayBrandCars = new List<Brand>()
            {
                new Brand()
                {
                    BrandName="Выберите бренд",
                    IdBrand=0
                }
            };

            arrayBrandCars.AddRange(db.context.Brand.ToList());

            BrandComboBox.ItemsSource = arrayBrandCars;
            BrandComboBox.DisplayMemberPath = "BrandName";
            BrandComboBox.SelectedValuePath = "IdBrand";
            BrandComboBox.SelectedIndex = 0;
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void AddCarsModelButtonClick(object sender, RoutedEventArgs e)
        {
            CarsModelsViewModel obj = new CarsModelsViewModel();
            obj.AddСarModel(Convert.ToInt32(BrandComboBox.SelectedValue), NewCarsModelTextBox.Text);

            NavigationService.Navigate(new AdminPage());
        }
    }
}
