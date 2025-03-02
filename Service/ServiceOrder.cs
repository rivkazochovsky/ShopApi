using Entite;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client;
using Microsoft.IdentityModel.Tokens;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceOrder : IServiceOrder
    {
        private readonly ILogger<ServiceOrder> _logger;

        IRepositoryProduct repository2;
        IRepositoryOrder repository;
        public ServiceOrder(IRepositoryOrder _repositoryOrder, IRepositoryProduct repository22, ILogger<ServiceOrder> logger)
        {
            repository = _repositoryOrder;
            repository2 = repository22;
            _logger = logger;
        }
        public async Task<Order> AddOrder(Order order)
        {

            double sum= await GetcureenrSumProduct(order);
            if(sum!=order.OrderSum)
            {
                order.OrderSum = sum;
               
                    _logger.LogCritical(" order sum not good");
               
              
            }
            

            return await repository.AddOrder(order);
        }

        public async Task<Order> GetOrderbyId(int id)
        {
            return await repository.GetOrderById(id);
        }

      private async Task<double> GetcureenrSumProduct(Order order)
        {
            double sum = 0;
            foreach (var item in order.OrderItems)
            {
                Product p=await repository2.GetProductById(item.ProductId);
                sum+= p.Price;
            }
            return sum;
        }



    }
}
