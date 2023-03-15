using AutoMapper;
using Corbae.Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;

namespace Corbae.Mappings
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserDB, User>().ReverseMap();
        }
    }
}
