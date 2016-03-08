using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using EntityFramework.Project;
using Moq;
using ECommerce.Project;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;

namespace ECommerce.Tests
{
    [TestClass]
    public class LoginControllerTests
    {
        [TestMethod]
        public void TestLoginViaEntityFramework_IsCalled_WhenTheLoginMethodIsCalled()
        {
            //Arrange
            string userName = "testName";
            string userPassword = "passWord";
            Mock<user> tUser = new Mock<user>();
            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            iRepo.Setup(d => d.LoginViaEntityFramework(It.IsAny<string>(), It.IsAny<string>())).Returns(tUser.Object);
            LoginController loginController = new LoginController(iRepo.Object);

            //Act
            loginController.Login(userName, userPassword);

            //Assert
            iRepo.Verify(x => x.LoginViaEntityFramework(userName, userPassword), Times.Once);
        }
        [TestMethod]
        public void TestLoginMethod_ReturnsBothTheUserObjectAndSuccessfulLoginString_WhenGivenTheUsernameAndPasswordStrings()
        {
            //Arrange
            string userName = "bobSmith";
            string userPassword = "123";

            var data = new List<user>()
            {
                new user() { username="bobSmith", user_password="123" },
                new user() { username="chrisBird", user_password="421" },
                new user() { username="samGerrett", user_password="532" },
            }.AsQueryable();

            user userToGet = data.ElementAt(0);
            string expectedString = String.Format("Welcome {0}", userToGet.username);

            var mockSet = new Mock<DbSet<user>>();
            mockSet.As<IQueryable<user>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<user>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<user>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.users).Returns(mockSet.Object);

            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            LoginController loginController = new LoginController(iRepository);

            //Act
            user loggedInUser = iRepository.LoginViaEntityFramework(userName, userPassword);
            string loggedInUserString = loginController.Login(userName, userPassword);

            //Assert
            Assert.AreEqual(userToGet, loggedInUser);
            Assert.AreEqual(expectedString, loggedInUserString);
        }
        [TestMethod]
        public void TestRegisterNewUser_IsCalled_WhenRegisterMethodIsCalled()
        {
            //Arrange
            string userName = "testName";
            string userPassword = "passWord";
            string firstName = "Bob";
            string lastName = "Smith";
            string returnedString = "";

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            Mock<ItemRepository> iRepo = new Mock<ItemRepository>(mockContext.Object);
            iRepo.Setup(d => d.RegisterNewUser(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>())).Returns(returnedString);
            LoginController loginController = new LoginController(iRepo.Object);

            //Act
            loginController.Register(firstName, lastName, userName, userPassword);

            //Assert
            iRepo.Verify(x => x.RegisterNewUser(firstName, lastName, userName, userPassword), Times.Once);
        }
        [TestMethod]
        public void VerifySaveChanges_ReturnsACountOfOne_WhenInvokedViaLoginControllerRegisterMethod()
        {
            //Arrange
            string firstName = "Bob";
            string lastName = "Smith";
            string userName = "bobSmith2";
            string passWord = "1234";

            var data = new List<user>()
            {
                new user() { username="bobSmith", user_password="123"},
                new user() { username ="chrisBird", user_password="312" },
                new user() { username="samGerrett", user_password="321" },
            }.AsQueryable();
 
            var mockSet = new Mock<DbSet<user>>();
            mockSet.As<IQueryable<user>>().Setup(m => m.Provider).Returns(data.Provider);
            mockSet.As<IQueryable<user>>().Setup(m => m.Expression).Returns(data.Expression);
            mockSet.As<IQueryable<user>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mockSet.As<IQueryable<user>>().Setup(m => m.GetEnumerator()).Returns(() => data.GetEnumerator());

            Mock<ProjectDatabaseEntities> mockContext = new Mock<ProjectDatabaseEntities>();
            mockContext.Setup(c => c.users).Returns(mockSet.Object);
            
            ItemRepository iRepository = new ItemRepository(mockContext.Object);
            LoginController loginController = new LoginController(iRepository);
            
            //Act
            string expectedResult = loginController.Register(firstName, lastName, userName, passWord);

            //Assert
            mockContext.Verify(x => x.SaveChanges(), Times.Once());
        }
    }
}
