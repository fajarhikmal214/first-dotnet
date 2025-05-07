using AutoMapper;
using HelloWorld.Models;
using HelloWorld.Dtos;

namespace HelloWorld.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<Category, CategoryDto>();
        }
    }
}