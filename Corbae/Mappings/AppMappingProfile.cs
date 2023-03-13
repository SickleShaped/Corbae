using AutoMapper;
using Corbae.Models;

namespace Corbae.Mappings
{
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<User, Product>().ReverseMap();
        }
    }
}
