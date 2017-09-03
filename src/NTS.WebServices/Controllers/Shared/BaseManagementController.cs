namespace NTS.WebServices.Controllers.Shared
{
    using ApplicationServices.Interfaces;

    public class BaseManagementController<TObject> 
        : BaseController<TObject> where TObject : IObject
    {
        #region Constructors
        public BaseManagementController(IManagementService<TObject> managementService) 
            : base(managementService) { }
        #endregion
    }
}
