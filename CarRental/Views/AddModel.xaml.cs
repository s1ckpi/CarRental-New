using CarRental.Models;
using CarRental.ViewModel;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.IO;
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
    /// Логика взаимодействия для AddModel.xaml
    /// </summary>
    public partial class AddModel : Page
    {
        Core db = new Core();
        Cars currentCars;
        string fileString;
        private byte[] _mainImageData;
        string ImageAutomobilePath;
        string ImageAboveAutomobilePath;
        List<Brand> arrayBrandCars;
        List<CarsModels> arrayModelCars;
        List<CarcassType> arrayCarcassCars;
        List<Models.Color> arrayColorCars;
        public AddModel(CarRentalEntities context, Cars activeCar)
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

            arrayModelCars = new List<CarsModels>()
            {
                new CarsModels()
                    {
                        ModelCar="Выберите автомобиль",
                        IdModel=0
                    }
            };

            arrayModelCars.AddRange(db.context.CarsModels.ToList());

            NewModelComboBox.ItemsSource = arrayModelCars;
            NewModelComboBox.DisplayMemberPath = "ModelCar";
            NewModelComboBox.SelectedValuePath = "IdModel";

            arrayCarcassCars = new List<CarcassType>()
            {
                new CarcassType()
                    {
                        CarcassName="Выберите кузов",
                        IdCarcassType=0
                    }
            };

            arrayCarcassCars.AddRange(db.context.CarcassType.ToList());

            CarcassComboBox.ItemsSource = arrayCarcassCars;
            CarcassComboBox.DisplayMemberPath = "CarcassName";
            CarcassComboBox.SelectedValuePath = "IdCarcassType";

            arrayColorCars = new List<Models.Color>()
            {
                new Models.Color()
                    {
                        ColorName="Выберите цвет",
                        IdColor=0
                    }
            };

            arrayColorCars.AddRange(db.context.Color.ToList());

            ColorComboBox.ItemsSource = arrayColorCars;
            ColorComboBox.DisplayMemberPath = "ColorName";
            ColorComboBox.SelectedValuePath = "IdColor";



            BrandComboBox.SelectedIndex = 0;
            NewModelComboBox.SelectedIndex = 0;
            CarcassComboBox.SelectedIndex = 0;
            ColorComboBox.SelectedIndex = 0;



            currentCars = activeCar;
            this.db.context = context;
            this.DataContext = currentCars;
        }

        private void SelectImageAutomoboleButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg, *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                fileString = ofd.FileName;
                ImageAutomobile.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);

                string newfilename = "\\Assets\\Images\\Car\\FrontSide\\";
                //путь к проекту
                string appFolderPath = Directory.GetCurrentDirectory();
                //Console.WriteLine(appFolderPath);
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                //Console.WriteLine(appFolderPath);
                string imageName = System.IO.Path.GetFileName(fileString);//имя картинки с расширением
                //Console.WriteLine(imageName);

                newfilename = appFolderPath + newfilename + imageName;
                //Console.WriteLine(newfilename);
                File.Delete(newfilename);
                File.Copy(fileString, newfilename);

                ImageAutomobilePath = "Car\\FrontSide\\" + imageName;
                Console.WriteLine(ImageAutomobilePath);
            }
        }
        private void SelectImageAutomobileAboveButtonClick(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image |*.png; *.jpg, *.jpeg";
            if (ofd.ShowDialog() == true)
            {
                _mainImageData = File.ReadAllBytes(ofd.FileName);
                fileString = ofd.FileName;
                ImageAutomobileAbove.Source = (ImageSource)new ImageSourceConverter().ConvertFrom(_mainImageData);

                string newfilename = "\\Assets\\Images\\Car\\AboveSide\\";
                //путь к проекту
                string appFolderPath = Directory.GetCurrentDirectory();
                //Console.WriteLine(appFolderPath);
                appFolderPath = appFolderPath.Replace("\\bin\\Debug", "");//обрезанный путь

                //Console.WriteLine(appFolderPath);
                string imageName = System.IO.Path.GetFileName(fileString);//имя картинки с расширением
                //Console.WriteLine(imageName);

                newfilename = appFolderPath + newfilename + imageName;
                //Console.WriteLine(newfilename);
                File.Delete(newfilename);
                File.Copy(fileString, newfilename);

                ImageAboveAutomobilePath = "Car\\AboveSide\\" + imageName;
                Console.WriteLine(ImageAboveAutomobilePath);
            }
        }

        private void AddModelButtonClick(object sender, RoutedEventArgs e)
        {
            CarsViewModel obj = new CarsViewModel();
            obj.AddСar(Convert.ToDouble(PriceTextBox.Text), Convert.ToDouble(AccelerationTextBox.Text), Convert.ToInt32(MaxSpeedTextBox.Text),
                       Convert.ToInt32(YearOfIssueTextBox.Text), ImageAutomobilePath, ImageAboveAutomobilePath, Convert.ToInt32(CarcassComboBox.SelectedValue),
                       Convert.ToInt32(ColorComboBox.SelectedValue), Convert.ToInt32(NewModelComboBox.SelectedValue));

            NavigationService.Navigate(new AdminPage());
            
        }

        private void BackButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AdminPage());
        }

        private void AddCarsModelsClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddCarsModels());
        }

        private void AddBrandClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddBrand());
        }
    }
}
