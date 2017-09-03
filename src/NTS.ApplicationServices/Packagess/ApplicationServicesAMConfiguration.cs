namespace NTS.ApplicationServices.Packagess
{
    using AutoMapper;
    using Data.Entities;
    
    public class ApplicationServicesAMConfiguration : Profile
    {

        public ApplicationServicesAMConfiguration()
        {
            CreateMap<User, ViewModels.Users.UserVM>().ReverseMap();
        }
    }
}