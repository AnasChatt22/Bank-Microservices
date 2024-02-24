using AutoMapper;
using customer_service.Models;

namespace customer_service;

public class MappingConfig
{
    public static MapperConfiguration RegisterMaps()
    {
        var mappingConfig = new MapperConfiguration(
            config =>
            {
                config.CreateMap<AccountDto, Account>().ReverseMap();
            });
        return mappingConfig;
    }
}