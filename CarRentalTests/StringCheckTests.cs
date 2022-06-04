using CarRental.ViewModel;
using CarRentalLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace CarRentalTests
{
    [TestClass]
    public class StringCheckTests
    {
        /// <summary>
        /// 1. Пустая строка
        /// </summary>
        [TestMethod]
        public void String_Empty_Returned()
        {
            //Arrange
            string nullString = "";
            string expected = String.Empty;
            //Act
            //Assert
            Assert.AreEqual(nullString, expected);
        }

        /// <summary>
        /// 2. Корректность логина 
        /// </summary>
        [TestMethod]
        public void Login_Correct_Returned()
        {
            //Arrange
            string Login = "Vasya33";
            string pattern = @"([A-Za-z0-9]+)$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.LoginCorrect(Login, pattern);
            //Assert
            Assert.IsTrue(success);
        }

        /// <summary>
        /// 3. Некорректность логина 
        /// </summary>
        [TestMethod]
        public void Login_NoCorrect_Returned()
        {
            //Arrange
            string Login = "_vasya33_";
            string pattern = @"([A-Za-z0-9]+)$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.LoginCorrect(Login, pattern);
            //Assert
            Assert.IsFalse(success);
        }

        /// <summary>
        /// 4. Корректность пароля 
        /// </summary>
        [TestMethod]
        public void Password_Correct_Returned()
        {
            //Arrange
            string password = "Vasya334";
            string pattern = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.PasswordCorrect(password, pattern);
            //Assert
            Assert.IsTrue(success);
        }

        /// <summary>
        /// 5. Некорректность пароля 
        /// </summary>
        [TestMethod]
        public void Password_NoCorrect_Returned()
        {
            //Arrange
            string password = "vasya33";
            string pattern = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.PasswordCorrect(password, pattern);
            //Assert
            Assert.IsFalse(success);
        }

        /// <summary>
        /// 6. Корректность почты
        /// </summary>
        [TestMethod]
        public void Email_Correct_Returned()
        {
            //Arrange
            string email = "Mihail2@gmail.com";
            string pattern = @"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.EmailCorrect(email, pattern);
            //Assert
            Assert.IsTrue(success);
        }

        /// <summary>
        /// 7. Некорректность почты
        /// </summary>
        [TestMethod]
        public void Email_NoCorrect_Returned()
        {
            //Arrange
            string email = "Mihail2@g_mAiL.com";
            string pattern = @"(\w+@[a-z]+?\.[a-z]{2,6})$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.EmailCorrect(email, pattern);
            //Assert
            Assert.IsFalse(success);
        }

        /// <summary>
        /// 8. Корректность телефона
        /// </summary>
        [TestMethod]
        public void Phone_Correct_Returned()
        {
            //Arrange
            string phone = "89911129358";
            string pattern = @"([0-9]{11})$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.PhoneCorrect(phone, pattern);
            //Assert
            Assert.IsTrue(success);
        }

        /// <summary>
        /// 9. Некорректность телефона
        /// </summary>
        [TestMethod]
        public void Phone_NoCorrect_Returned()
        {
            //Arrange
            string phone = "8x012e10t958";
            string pattern = @"([0-9]{11})$";
            //Act
            StringCheckLibrary obj = new StringCheckLibrary();
            bool success = obj.PhoneCorrect(phone, pattern);
            //Assert
            Assert.IsFalse(success);
        }
    }
}
