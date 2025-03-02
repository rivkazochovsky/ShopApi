


using Entite;
using System.ComponentModel.DataAnnotations;

namespace DTO
{
    public record UserDTO(int UserId, [StringLength(20, ErrorMessage = "password can be betwenn 2 till 20 letters", MinimumLength = 2)]
string UserName, string FirstName, string LastName/*,List<OrderDTO>Orders*/);

    public record RegisterUserDTO([EmailAddress]

string UserName, string FirstName, [StringLength(20, ErrorMessage = "LastName can be betwenn 2 till 20 letters", MinimumLength = 2)] string LastName,string password);
}
