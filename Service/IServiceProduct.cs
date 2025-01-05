using Entite;

namespace Service
{
    public interface IServiceProduct
    {
        //Task<Product> AddProduct(Product product);
        Task<Product> GetProductbyId(int id);
        Task<List<Product>> GetProducts(int? minPrise, int? maxPrise, int?[] categoryIds, string? desc);
        //Task UpdateProduct(int id, Product value);
    }
}