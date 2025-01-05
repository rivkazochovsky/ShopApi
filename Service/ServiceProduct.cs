using Entite;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceProduct : IServiceProduct

    {
        IRepositoryProduct repository;
        public ServiceProduct(IRepositoryProduct _repositoryProduct)
        {
            repository = _repositoryProduct;
        }
        public async Task<Product> GetProductbyId(int id)
        {
            return await repository.GetProductById(id);
        }

        public async Task<List<Product>> GetProducts(int? minPrise, int? maxPrise, int?[] categoryIds, string? desc)
        {
            return await repository.GetProducts( minPrise,  maxPrise,  categoryIds, desc);
        }

        //public async Task UpdateProduct(int id, Product value)
        //{
        //    await repository.UpdateProduct(id, value);
        //}

        //public async Task<Product> AddProduct(Product product)
        //{
        //    return await repository.AddProduct(product);
        //}


    }
}
