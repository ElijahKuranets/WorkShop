using System;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using PasswordManager.Interfaces;
using HW;

namespace PasswordManager.Tests
{
    [TestFixture] //Test
   public class LogAnalyzerTests
    {  
        [Test]
        public void IsValidName_NameSupportedExtension_ReturnTrue()
        {
            FakeExtensionManager myFakeManager = new FakeExtensionManager();//Заглушка, которая будет возвращать true
            myFakeManager.willBeValid = true;
            LogAnalyzer log = new LogAnalyzer(myFakeManager); //передача заглушки
            bool result = log.IsValidLogFileName("");
            Assert.True(result);
        }

        [Test]
        public void MoqTEST_IsValidName_NameSupportedExtension_ReturnTrue()
        {
            //Arrange
            var mock = new Mock<IExtensionManager>();
            mock.Setup(a => a.IsValid("short.ext")).Returns(true);
            //Act
            LogAnalyzer log = new LogAnalyzer(mock.Object);
            //Assert
            Assert.True(log.IsValidLogFileName("short.ext"));
        }
    }

    internal class FakeExtensionManager : IExtensionManager//Определение заглушки
    {
        public bool willBeValid = false;

        public bool IsValid(string fileleName)
        {
            return willBeValid;
        }
    }

   

}
