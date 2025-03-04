using Entite;

namespace Service
{
    public interface IServiceProduct1
    {
        Task<Product> GetProductbyId(int id);
        Task<List<Product>> GetProducts(int? minPrise, int? maxPrise, int?[] categoryIds, string? desc);
    }
}