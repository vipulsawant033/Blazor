using AutoMapper;
using RepositoryLayer.Models;
using ViewModels;

namespace Blazor.APIs
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<ProductVM, Product>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
