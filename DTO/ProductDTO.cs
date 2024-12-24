using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entite;

namespace DTO
{
    public record ProductDTO(int Productid,string ProductName, string Descreption, string CategoryCategoryName ,double Price,string? Image);
}
