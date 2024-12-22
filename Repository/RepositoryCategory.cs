using Entite;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryCategory : IRepositoryCategory
    {

        ShopApiContext _contex;

        public RepositoryCategory(ShopApiContext shopApiContext)
        {
            _contex = shopApiContext;
        }
        

        public async Task<List<Category>> GetCategory()
        {
            return await _contex.Categories.ToListAsync();

        }

        //public async Task<Category> GetCategoryById(int id)
        //{
        //    return await _contex.Categories.FirstOrDefaultAsync(Category => Category.CategoryId == id);

        //}

    }
}
