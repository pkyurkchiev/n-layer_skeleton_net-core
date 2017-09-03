﻿namespace NTS.WebServices.Controllers.Shared
{
    using ApplicationServices.Interfaces;
    using Microsoft.AspNetCore.Mvc;

    public class BaseController<TObject> : Controller where TObject : IObject
    {
        #region Fields
        public IManagementService<TObject> _managementService;
        #endregion

        #region Constructors
        public BaseController(IManagementService<TObject> managementService)
        {
            _managementService = managementService;
        }
        #endregion
    }
}