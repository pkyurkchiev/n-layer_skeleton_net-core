namespace NTS.ApplicationServices.Interfaces.Users
{
    using ViewModels.Users;

    public interface IUserManagementService : IManagementService<IUser, FilterUserVM>
    {
    }
}
