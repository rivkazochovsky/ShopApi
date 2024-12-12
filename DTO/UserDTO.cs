


using Entite;

namespace DTO
{
    public record UserDTO(string UserName, string FirstName, string LastName,List<Order>Orders);

    public record RegisterUserDTO(string UserName, string FirstName, string LastName,string password);
}
