using Entite;

namespace Repository
{
    public interface IRepositoryCategory
    {
        Task<List<Category>> GetCategory();
        //Task<Category> GetCategoryById(int id);
    }
}