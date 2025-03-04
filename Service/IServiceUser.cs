using Entite;

namespace Service
{
    public interface IServiceUser
    {
        Task<User> AddUser(User user);
        int CheckPassword(string password);
        Task<User> GetUserById(int id);
        Task<User> Login(string UserName, string Password);
        Task<User> updateuser(int id, User user);
        Task<User> ValidateDuplicateUser(string UserName, string Password); 
    }
}