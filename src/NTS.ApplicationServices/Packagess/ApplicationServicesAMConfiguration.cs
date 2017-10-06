namespace NTS.ApplicationServices.Packagess
{
    using AutoMapper;
    using Data.Entities;
    using X.PagedList;

    public class ApplicationServicesAMConfiguration : Profile
    {
        public ApplicationServicesAMConfiguration()
        {
            // IPagedList custom mapper
            CreateMap(typeof(IPagedList<>), typeof(IPagedList<>)).ConvertUsing(typeof(PagedListConverter<,>));

            CreateMap<User, ViewModels.Users.UserVM>()
                    .ForMember(dest => dest.RoleName, m => m.MapFrom(src => src.Role.Name)).ReverseMap();
            CreateMap<Role, ViewModels.Roles.RoleVM>().ReverseMap();
        }
    }
}