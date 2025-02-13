using Entite;
using Moq;
using Repository;
using Moq.EntityFrameworkCore;



namespace TestProject
{
    public class UnitTest1
    {
        [Fact]
        public async Task Test1()
        {
            var user = new User {  UserName = "y0504130776",Password="38612164" };
            var mockContext = new Mock<ShopApiContext>();
            var users = new List<User>() { user };
            mockContext.Setup(x => x.Users).ReturnsDbSet(users);
            var userRepository = new RepositoryUser(mockContext.Object);


            var result = await userRepository.Login(user.UserName,user.Password);

            Assert.Equal(user, result);



               
        }
    }
}