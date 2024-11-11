using Entite;

namespace Repository
{
    public interface IRepositoryUser
    {
        User AddUser(User user);
        User GetUserById(int id);
        User Login(string UserName, string Password);
        void UpdateUser(int id, User value);
    }
}