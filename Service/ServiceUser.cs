using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Entite;
using Zxcvbn;
using Microsoft.Extensions.Logging;


namespace Service
{
    public class ServiceUser : IServiceUser

    {
        private readonly ILogger<ServiceUser> _logger;

        IRepositoryUser repository;
        public ServiceUser(IRepositoryUser _repositoryUser, ILogger<ServiceUser> logger)
        {
            _logger = logger;
            repository = _repositoryUser;
        }


        public async Task<User> GetUserById(int id)
        {
            return await repository.GetUserById(id);

        }

        public async Task<User> AddUser(User user)
        {
            
                return await repository.AddUser(user);
        
               
        }
        public async Task<User> Login(string UserName, string Password)
        {
            return await repository.Login(UserName, Password);
        }

        public async Task<User> updateuser(int id, User user)
        {
          
            return await repository.UpdateUser(id, user);
        }
        public int CheckPassword(string password)
        {
            var result = Zxcvbn.Core.EvaluatePassword(password);
            return result.Score;
        }

        public async Task<User> ValidateDuplicateUser(string UserName, string Password)
        {
            return await repository.ValidateDuplicateUser(UserName, Password);
        }

    }
}
