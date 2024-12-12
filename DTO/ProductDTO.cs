using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entite;

namespace DTO
{
    public record ProductDTO(string ProductName, string Descreption , CategoryDTO Category ,double Price);
}
