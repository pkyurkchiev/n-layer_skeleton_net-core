namespace NTS.Website.Controllers.Shared
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using NTS.ApplicationServices.Interfaces;
    using NTS.ApplicationServices.ViewModels;
    using NTS.ApplicationServices.ExceptionHandler.Exceptions;
    using NTS.ApplicationServices.ExceptionHandler.Enums;
    using NTS.Utils.Extensions;
    using AutoMapper;
    using Microsoft.Extensions.DependencyInjection;

    public class BaseManagementController<TObject, TList, TEdit, TFilter> : BaseController where TObject : IObject where TList : ListVM<TFilter>, new() where TEdit : BaseVM, TObject, new() where TFilter : class
    {
        #region Fields
        protected const string listViewName = "Index";
        protected const string createViewName = "Create";
        protected const string editViewName = "Edit";
        protected const string deleteViewName = "Delete";

        public IManagementService<TObject, TFilter> _managementService;
        protected readonly IMapper _mapper;
        #endregion

        #region Properties
        protected string ListViewName { get; set; }
        protected string CreateViewName { get; set; }
        protected string EditViewName { get; set; }
        protected string DeleteViewName { get; set; }
        #endregion

        #region Constructors
        public BaseManagementController(IManagementService<TObject, TFilter> managementService,
                                        IServiceProvider serviceProvider)
        {
            _managementService = managementService;
            _mapper = serviceProvider.GetRequiredService<IMapper>();

            ListViewName = listViewName;
            EditViewName = editViewName;
            CreateViewName = createViewName;
            DeleteViewName = deleteViewName;
        }
        #endregion

        #region Public Methods
        public override IActionResult Index()
        {
            TList model = GenerateTList();
            TryUpdateModelAsync(model);
            var collection = _managementService.Find(model.Filters, model.Pager);

            return View(ListViewName, PrepareModelForList(model, collection, model.Pager));
        }

        [HttpGet]
        public virtual IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult CreateConfirm()
        {
            this.CreateTEdit();

            return RedirectToAction(ListViewName);
        }

        [HttpGet]
        public virtual IActionResult Edit(int? id)
        {
            if (!id.HasValue) throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());

            var viewModel = _managementService.GetById(id.Value);

            if (viewModel == null) throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            return View(EditViewName, viewModel);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult EditConfirm()
        {
            this.EditTEdit();

            return RedirectToAction(ListViewName);
        }

        [HttpGet]
        public virtual IActionResult Delete(int? id)
        {
            if (!id.HasValue) throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());

            var viewModel = _managementService.GetById(id.Value);

            if (viewModel == null) throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            return View(DeleteViewName, viewModel);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public virtual IActionResult DeleteConfirm(int? id)
        {
            try
            {
                this.DeleteTEdit(id);

                return RedirectToAction(ListViewName);
            }
            catch (BusinessException ex)
            {
                var viewModel = _managementService.GetById(id.Value);

                ModelState.AddModelError(String.Empty, ex.Message);
                return View(deleteViewName, viewModel);
            }
        }

        //[HttpGet]
        //public virtual IActionResult ActivateDeactivate(int? id)
        //{
        //    if (!id.HasValue) throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());
        //    _managementService.ActivateDeactivate(id.Value);

        //    return RedirectToAction(ListViewName);
        //}
        #endregion

        #region Protected Methods
        protected void CreateTEdit()
        {
            TEdit viewModel = new TEdit();
            TryUpdateModelAsync(viewModel);
            if (!ModelState.IsValid) throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            _managementService.Save(viewModel);
        }

        protected void EditTEdit()
        {
            TEdit viewModel = new TEdit();
            TryUpdateModelAsync(viewModel);
            if (!ModelState.IsValid) throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            _managementService.Save(viewModel);
        }

        protected void DeleteTEdit(int? id)
        {
            if (!id.HasValue) throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());

            _managementService.Delete(id.Value);
        }

        protected virtual TList PrepareModelForList(TList model, IEnumerable<TObject> collection, PagerVM pager)
        {
            return model;
        }
        #endregion

        #region Private Methods
        private TList GenerateTList()
        {
            return new TList
            {
                Pager = new PagerVM(
                    ControllerContext.RouteData.Values["action"].ToString(),
                    ControllerContext.RouteData.Values["controller"].ToString()
            )
            };
        }
        #endregion
    }
}