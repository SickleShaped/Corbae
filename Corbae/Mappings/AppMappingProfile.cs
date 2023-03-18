using AutoMapper;
using Corbae.Models;
using Corbae.DAL.Models.DBModels;
using Corbae.DAL.Models.DTO;
using Corbae.DAL.Models.Auxiliary_Models;

namespace Corbae.Mappings
{
    /// <summary>
    /// Класс, в котором описываются все маппинги
    /// </summary>
    public class AppMappingProfile:Profile
    {
        public AppMappingProfile()
        {
            CreateMap<UserDB, User>().ReverseMap();

            CreateMap<UserDB, UserToEdit>().ReverseMap();

            CreateMap<ProductDB, Product>().ReverseMap();
        }
    }
}
