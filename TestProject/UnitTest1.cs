using Entite;
using Repository;
using Moq;
using Moq.EntityFrameworkCore;
using DTO;
using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.EntityFrameworkCore;
namespace TestProject1
{
    public class UnitTest1
    {
        [Fact]
        public async Task Login_ValidCredentialsREturnsUser()
        {
            var user = new User { UserName = "y0504130776@gmail.com", Password = "214982472" };
            var mokContext = new Mock<ShopApiContext>();
            var users = new List<User>() { user };
            mokContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new RepositoryUser(mokContext.Object);
            var result = await userRepository.Login(user.UserName, user.Password);
            Assert.Equal(user, result);

        }

        [Fact]
        public async void Login_InvalidEmailReturnsNull()
        {
            var user = new User { FirstName = "aa", LastName = "bb", UserName = "Tz@123cvv", Password = "secure123" };
            var users = new List<User>() { user };
            var mockContext = new Mock<ShopApiContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new RepositoryUser(mockContext.Object);

            var result = await userRepository.Login("wrong@email.com", user.Password);

            Assert.Null(result);
        }
        [Fact]
        public async Task Get_UserDoesNotExist_ReturnsNull()
        {

            var mockContext = new Mock<ShopApiContext>();
            var users = new List<User>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            mockContext.Setup(m => m.Users.FindAsync(It.IsAny<int>())).ReturnsAsync((User)null);

            var Reposetory = new RepositoryUser(mockContext.Object);

            var result = await Reposetory.GetUserById(999);


            Assert.Null(result);
        }
        [Fact]

        public async Task Login_InvalidPasswordReturnsNull()
        {
            // Arrange
            var user = new User { UserName = "test@example.com", Password = "password123", FirstName = "John", LastName = "Doe" };
            var users = new List<User> { user };
            var mockContext = new Mock<ShopApiContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);

            var repository = new RepositoryUser(mockContext.Object);

            // Act
            var result = await repository.Login(user.UserName, "wrongpassword");

            // Assert
            Assert.Null(result);
        }


        [Fact]
        public async Task UpdateUser_ExistingUser_UpdatesUser()
        {
            var user = new User { UserId = 20, FirstName = "nnn", LastName = "bbb" };
            var mockContext = new Mock<ShopApiContext>();
            mockContext.Setup(x => x.Users).ReturnsDbSet(new List<User>() { user });
            mockContext.Setup(x => x.SaveChangesAsync(default)).ReturnsAsync(1);
            mockContext.Setup(x => x.Users.FindAsync(20)).ReturnsAsync(user);

            var userRepository = new RepositoryUser(mockContext.Object);
            var updatedUser = new User { FirstName = "updated", LastName = "user" };

            user = await userRepository.UpdateUser(20, updatedUser);

            Assert.Equal("updated", user.FirstName);
            Assert.Equal("user", user.LastName);
            mockContext.Verify(x => x.SaveChangesAsync(default), Times.Once);
        }

    }
}