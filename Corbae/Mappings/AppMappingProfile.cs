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
            CreateMap<UserDB, UserToCreate>().ReverseMap();
            CreateMap<User, UserToCreate>().ReverseMap();

            CreateMap<ProductDB, Product>().ReverseMap();
            CreateMap<Product, ProductToCreate>().ReverseMap();
            CreateMap<ProductDB, ProductToCreate>().ReverseMap();

            CreateMap<OrderDB, Order>().ReverseMap();

            CreateMap<Comment, CommentDB>().ReverseMap();

            CreateMap<Cart, CartDB>().ReverseMap();

            CreateMap<Wish, WishDB>().ReverseMap();

            CreateMap<Notification, NotificationDB>().ReverseMap();

            
        }
    }
}
