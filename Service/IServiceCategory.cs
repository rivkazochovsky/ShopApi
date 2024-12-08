using Entite;

namespace Service
{
    public interface IServiceCategory
    {
        Task<List<Category>> GetCategory();
        //Task<Category> GetCategorybyId(int id);
    }
}