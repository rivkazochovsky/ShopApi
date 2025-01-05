using Entite;

namespace Repository
{
    public interface IRepositoryProduct
    {
        //Task<Product> AddProduct(Product product);
        Task<Product> GetProductById(int id);
        Task<List<Product>> GetProducts(int? minPrise, int? maxPrise, int?[] categoryIds, string? desc);
        //Task UpdateProduct(int id, Product value);
    }
}