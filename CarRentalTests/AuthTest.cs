using CarRental.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Text.RegularExpressions;

namespace CarRentalTests
{
    [TestClass]
    public class AuthTest
    {

        [TestMethod]
        public void String_Empty_Returned()
        {
            //Arrange
            string nullstring = "";
            string expected = String.Empty;
            //Act
            //Assert
            Assert.AreEqual(nullstring, expected);
        }
        [TestMethod]
        public void String_Empty_FalseReturned()
        {
            //Arrange
            string nullstring = "abcd";
            string expected = String.Empty;
            //Act
            //Assert
            Assert.AreEqual(expected, nullstring);
        }

        [TestMethod]
        public void Login_Correct_Returned()
        {
            //Arrange
            string Login = "vasya33";
            string pattern = @"([A-Za-z0-9]+)$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Login).Success;
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Login_NoCorrect_Returned()
        {
            //Arrange
            string Login = "_vasya33_";
            string pattern = @"([A-Za-z0-9]+)$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Login).Success;
            //Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Password_Correct_Returned()
        {
            //Arrange
            string Password = "Vasya334";
            string pattern = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Password).Success;
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Password_NoCorrect_Returned()
        {
            //Arrange
            string Password = "vasya33";
            string pattern = @"((?=.*\d)(?=.*[a-z])(?=.*[A-Z]).{8,15})$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Password).Success;
            //Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Email_Correct_Returned()
        {
            //Arrange
            string Email = "Mihail2@gmail.com";
            string pattern = @"(\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,6})$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Email).Success;
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Email_NoCorrect_Returned()
        {
            //Arrange
            string Email = "Mihail2@g_mAiL.com";
            string pattern = @"(\w+@[a-z]+?\.[a-z]{2,6})$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Email).Success;
            //Assert
            Assert.IsFalse(success);
        }

        [TestMethod]
        public void Phone_Correct_Returned()
        {
            //Arrange
            string Phone = "89012109958";
            string pattern = @"([0-9]{11})$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Phone).Success;
            //Assert
            Assert.IsTrue(success);
        }

        [TestMethod]
        public void Phone_NoCorrect_Returned()
        {
            //Arrange
            string Phone = "89012e10e958";
            string pattern = @"([0-9]{11})$";
            //Act
            Regex regex = new Regex(pattern);
            bool success = regex.Match(Phone).Success;
            //Assert
            Assert.IsFalse(success);
        }
    }
}
