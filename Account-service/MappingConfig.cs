using AutoMapper;
using account_service.Models;

namespace account_service;

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