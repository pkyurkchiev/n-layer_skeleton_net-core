namespace NTS.WebServices.Controllers.Shared
{
    using ApplicationServices.ExceptionHandler.Enums;
    using ApplicationServices.ExceptionHandler.Exceptions;
    using ApplicationServices.Interfaces;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using Utils.Extensions;

    public class BaseManagementController<TObject> 
        : BaseController<TObject> where TObject : IObject
    {
        #region Constructors
        public BaseManagementController(IManagementService<TObject> managementService) 
            : base(managementService) { }
        #endregion

        #region Public Methods
        
        // GET: api/[controller]
        [HttpGet]
        public virtual JsonResult Get()
        {
            IEnumerable<TObject> models = _managementService.GetAll();

            return Json(models);
        }

        // GET: api/[controller]/5
        [HttpGet("{id}", Name = "Get")]
        public virtual JsonResult Get(int id)
        {
            TObject model = _managementService.GetById(id);

            return Json(model);
        }

        // POST: api/[controller]
        [HttpPost]
        public virtual JsonResult Post(TObject model)
        {
            _managementService.Save(model);

            return Json(null);
        }

        // PUT: api/[controller]
        [HttpPut]
        public virtual JsonResult Put(TObject model)
        {
            if (model.Id.IsAnyNullOrEmpty())
                throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            _managementService.Save(model);

            return Json(null);
        }

        // DELETE: api/[controller]/5
        [HttpDelete("{id}")]
        public virtual JsonResult Delete(int id)
        {
            TObject model = _managementService.GetById(id);

            if (model == null)
                throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());

            _managementService.Delete(id);

            return Json(null);
        }

        // GET api/[controller]/version
        [HttpGet("version")]
        public virtual string Version()
        {
            return "Version 1.0.0";
        }
        #endregion
    }
}
