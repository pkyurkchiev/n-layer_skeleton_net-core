namespace NTS.WebServices.Controllers
{
    using ApplicationServices.Interfaces.Users;
    using ApplicationServices.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;
    using Shared;

    [Route("api/[controller]")]
    public class UsersController : BaseManagementController<IUser, FilterUserVM>
    {
        #region Constructors
        public UsersController(IUserManagementService userManagementService) 
            : base(userManagementService) { }
        #endregion
    }
}
