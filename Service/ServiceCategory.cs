using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceCategory : IServiceCategory
    {

        IRepositoryCategory repository;
        public ServiceCategory(IRepositoryCategory _repositoryCategory)
        {
            repository = _repositoryCategory;
        }
        //public async Task<Category> GetCategorybyId(int id)
        //{
        //    return await repository.GetCategoryById(id);
        //}

        public async Task<List<Category>> GetCategory()
        {
            return await repository.GetCategory();
        }
    }
}
