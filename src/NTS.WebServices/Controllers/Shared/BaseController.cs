namespace NTS.WebServices.Controllers.Shared
{
    using ApplicationServices.Interfaces;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize]
    public class BaseController<TObject, TFilter> 
        : Controller where TObject : IObject where TFilter : class
    {
        #region Fields
        public IManagementService<TObject, TFilter> _managementService;
        #endregion

        #region Constructors
        public BaseController(IManagementService<TObject, TFilter> managementService)
        {
            _managementService = managementService;
        }
        #endregion

        #region Public Methods
        public virtual ActionResult Index()
        {
            return View();
        }
        #endregion
    }
}
