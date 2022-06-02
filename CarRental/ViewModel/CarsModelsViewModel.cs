using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRental.ViewModel
{
    public class CarsModelsViewModel
    {
        Core db = new Core();

        public bool AddСarModel(int idBrand, string modelCar)
        {
            CarsModels newCarModel = new CarsModels()
            {
                IdBrand = idBrand,
                ModelCar = modelCar
            };
            if ((idBrand == null || idBrand == 0) || modelCar == null)
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                db.context.CarsModels.Add(newCarModel);
                db.context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
        }
    }
}
