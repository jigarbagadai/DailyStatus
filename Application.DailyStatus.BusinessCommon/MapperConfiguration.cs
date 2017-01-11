using Application.DailyStatus.BusinessEntities;
using Application.DailyStatus.DataAccessEntities;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DailyStatus.BusinessCommon
{
    public static class MapperConfiguration
    {
        public static void IntlializeMapperConfiguration()
        {
            Mapper.Initialize(cfg =>
            {
                GetUserMappingConfiguration(cfg);
            });
        }

        private static IMappingExpression<User,UserEntity> GetUserMappingConfiguration(IMapperConfigurationExpression cfg)
        {
            return cfg.CreateMap<User, UserEntity>()
                      .ForMember(des => des.UserId, opt => opt.MapFrom(src => src.Id))
                      .ForMember(des => des.UserRole, opt => opt.MapFrom(src => src.Role.Name))
                      .ForMember(des => des.UserName, opt => opt.MapFrom(src => src.Name))
                      .ForMember(des => des.TimeZone, opt => opt.MapFrom(src => src.TimeZone.Name));
        }
    }
}
