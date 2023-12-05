using AutoMapper;
using Entytess;
using ODT;

namespace project
{
    public class Mapper : Profile
    {
  public Mapper()
        {
            CreateMap<User, UserDTO>().ReverseMap();

            CreateMap<Category, CategoryDTO>();



            CreateMap<OrderDTO, Order>().ReverseMap();

            CreateMap<OrderItemDTO, OrderItem>().ReverseMap();

            CreateMap<Product, ProductDTO>().ForMember(dest => dest.CategoryId, opts => opts.MapFrom(src => src.Category.CategoryId));


        }

    }
}
