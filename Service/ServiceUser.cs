using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entite;
using Zxcvbn;


namespace Service
{
    public class ServiceUser : IServiceUser

    {

        IRepositoryUser repository;
        public ServiceUser(IRepositoryUser _repositoryUser)
        {
            repository = _repositoryUser;
        }

 
        public User GetUserById(int id)
        {
            return repository.GetUserById(id);

        }

        public User AddUser(User user)
        {
            int passwordStrength = CheckPassword(user.Password);
            if (passwordStrength >= 2)
                return repository.AddUser(user);
            else
                return null;
        }
        public User Login(string UserName, string Password)
        {
            return repository.Login(UserName, Password);
        }

        public void UpdateUser(int id, User value)
        {
            repository.UpdateUser(id, value);
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

    }
}
