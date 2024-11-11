using Entite;

namespace Service
{
    public interface IServiceUser
    {
        //int AddUser(User user);
        User AddUser(User user);
        User GetUserById(int id);
        User Login(string UserName, string Password);
        void UpdateUser(int id, User value);
        public int CheckPassword(string password);
    }
}