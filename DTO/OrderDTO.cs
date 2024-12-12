using Entite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public record OrderDTO(double OrderSum, DateOnly OrderDate, string UserUsername);

    public record PostOrderDTO(DateOnly OrderDate, int OrderSum, int UserId);
}
