using Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderDTO(int OrderId, double OrderSum, DateOnly OrderDate, string UserUsername,List<OrderItemDTO> OrderItems);

    public record PostOrderDTO( DateOnly OrderDate, double OrderSum, int UserId, List<OrderItemDTO> OrderItems);
}
