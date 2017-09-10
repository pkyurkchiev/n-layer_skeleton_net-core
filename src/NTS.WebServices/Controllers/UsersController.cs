namespace NTS.WebServices.Controllers
{
    using ApplicationServices.Interfaces.Users;
    using Microsoft.AspNetCore.Mvc;
    using Shared;

    [Route("api/[controller]")]
    public class UsersController : BaseManagementController<IUser>
    {
        #region Constructors
        public UsersController(IUserManagementService userManagementService) 
            : base(userManagementService) { }
        #endregion
    }
}
