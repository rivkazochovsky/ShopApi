using AutoMapper;
using DTO;
using Entite;


namespace Shope
{
    public class Mapper : Profile
    {
        public Mapper()
        {

            CreateMap<User, UserDTO>();
            CreateMap<Order, OrderDTO>();
            CreateMap<Product, ProductDTO>();
            CreateMap<Category, CategoryDTO>();
            CreateMap<RegisterUserDTO, User>();
            CreateMap<PostOrderDTO, Order>();


        }
    }
}
