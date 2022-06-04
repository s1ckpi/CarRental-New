using CarRental.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarRental.ViewModel
{
    public class UsersViewModel
    {
        Core db = new Core();

        /// <summary>
        /// Авторизация пользователя
        /// </summary>
        /// <param name="login">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <returns></returns>
        public bool Autorization(string login, string password)
        {
            List<Users> arrUser = db.context.Users.Where(x => x.Login == login && x.Password == password).ToList();
            int countUsers = arrUser.Count();

            if (countUsers == 0)
            {
                MessageBox.Show("Такой пользователь отсутствует!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                App.currentUser = db.context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault();
                return true;
            }
        }

        /// <summary>
        /// Определение роли пользователя
        /// </summary>
        /// <param name="login">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <returns></returns>
        public int GetRole(string login, string password)
        {
            return (int)db.context.Users.Where(x => x.Login == login && x.Password == password).FirstOrDefault().IdRole;
        }

        /// <summary>
        /// Регистрация пользователя
        /// </summary>
        /// <param name="login">
        /// Идентификатор пользователя
        /// </param>
        /// <param name="password">
        /// Пароль пользователя
        /// </param>
        /// <param name="email">
        /// Почта пользователя
        /// </param>
        /// <param name="driverLicenseNumber">
        /// Водительские права пользователя
        /// </param>
        /// <param name="firstName">
        /// Имя пользователя
        /// </param>
        /// <param name="lastName">
        /// Фамилия пользователя
        /// </param>
        /// <param name="patronymicName">
        /// Отчество пользователя
        /// </param>
        /// <param name="phone">
        /// Телефон пользователя
        /// </param>
        /// <returns></returns>
        public bool Registration(string login, string password, string email, string driverLicenseNumber, string firstName, string lastName, string patronymicName, string phone)
        {
            Users newUser = new Users()
            {
                Login = login,
                Password = password,
                Email = email,
                IdRole = 2
            };

            Clients newClient = new Clients()
            {
                DriverLicenseNumber = driverLicenseNumber,
                Login = login,
                FirstName = firstName,
                LastName = lastName,
                PatronymicName = patronymicName,
                Phone = phone,
                ImageClient = "Client.png"
            };
            if (login == String.Empty || password == String.Empty || email == String.Empty ||driverLicenseNumber == String.Empty ||
                firstName == String.Empty || lastName == String.Empty || patronymicName == String.Empty || phone == String.Empty)
            {
                MessageBox.Show("Заполните все поля", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return false;
            }
            else
            {
                db.context.Users.Add(newUser);
                db.context.Clients.Add(newClient);
                db.context.SaveChanges();
                MessageBox.Show("Регистрация прошла успешно!", "Уведомление", MessageBoxButton.OK, MessageBoxImage.Information);
                return true;
            }
        }
    }
}
