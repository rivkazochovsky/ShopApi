using Entite;

namespace Service
{
    public interface IServiceProduct
    {
        //Task<Product> AddProduct(Product product);
        //Task<Product> GetProductbyId(int id);
        Task<List<Product>> GetProducts();
        //Task UpdateProduct(int id, Product value);
    }
}