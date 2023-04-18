using AutoMapper;
using PharmacyOrderApi.Models;
using PharmacyOrderApi.Models.Dtos;

namespace PharmacyOrderApi
{
    public class MappingProfile : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<OrderDto, Order>().ReverseMap();
                
            });

            return mappingConfig;
        }
    }
}
