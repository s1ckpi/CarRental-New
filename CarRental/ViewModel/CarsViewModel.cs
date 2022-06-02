using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace CarRental.ViewModel
{
    public class CarsViewModel
    {
        Core db = new Core();

        public bool AddСar(double price, double acceleration, int maxSpeed, int yearOfIssue, string image,
                              string imageAbove, int idCarcassType, int idColor, int IdModel)
        {
            Cars newCar = new Cars()
            {
                Price = price,
                Acceleration = acceleration,
                MaxSpeed = maxSpeed,
                YearOfIssue = yearOfIssue,
                Image = image,
                ImageAbove = imageAbove,
                IdCarcassType = idCarcassType,
                IdColor = idColor,
                IdModel = IdModel
            };
            if (price == null || acceleration == null || maxSpeed == null || yearOfIssue == null || image == null || 
                imageAbove == null || (idCarcassType == null || idCarcassType == 0) || (idColor == null || idColor == 0) || (IdModel == null || IdModel == 0))
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                db.context.Cars.Add(newCar);
                db.context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
        }
    }
}
