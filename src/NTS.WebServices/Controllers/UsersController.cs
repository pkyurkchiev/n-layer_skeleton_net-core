namespace NTS.WebServices.Controllers
{
    using ApplicationServices.Interfaces.Users;
    using ApplicationServices.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;
    using NTS.ApplicationServices.ExceptionHandler.Enums;
    using NTS.ApplicationServices.ExceptionHandler.Exceptions;
    using NTS.Utils.Extensions;
    using Shared;

    [Route("api/[controller]")]
    public class UsersController : BaseManagementController<IUser, FilterUserVM>
    {
        #region Constructors
        public UsersController(IUserManagementService userManagementService) 
            : base(userManagementService) { }
        #endregion

        // POST: api/[controller]
        [HttpPost("save")]
        public JsonResult Post(UserVM model)
        {
            int result = _managementService.Save(model);
            if (result == -1)
                throw new BusinessException(BusinessExceptionEnum.NotSaveObject.GetDescription());

            return Json(result);
        }
    }
}
