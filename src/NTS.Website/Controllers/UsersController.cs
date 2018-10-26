namespace NTS.Website.Controllers
{
    using ApplicationServices.Interfaces.Users;
    using ApplicationServices.ViewModels;
    using ApplicationServices.ViewModels.Users;
    using Microsoft.AspNetCore.Mvc;
    using NTS.ApplicationServices.ExceptionHandler.Enums;
    using NTS.ApplicationServices.ExceptionHandler.Exceptions;
    using NTS.ApplicationServices.Interfaces.Roles;
    using NTS.Utils.Extensions;
    using Shared;
    using System;
    using X.PagedList;

    public class UsersController : BaseManagementController<IUser, ListUserVM, UserVM, FilterUserVM>
    {
        IRoleManagementService _roleManagementService;

        public UsersController(IUserManagementService userManagementService,
                                IRoleManagementService roleManagementService,
                                IServiceProvider serviceProvider)
            : base(userManagementService, serviceProvider)
        {
            _roleManagementService = roleManagementService;
        }

        [HttpGet]
        public override IActionResult Create()
        {
            UserVM user = new UserVM
            {
                Roles = _roleManagementService.GetAll()
            };

            return View(CreateViewName, user);
        }

        [HttpPost, ActionName("Create")]
        [ValidateAntiForgeryToken]
        public override IActionResult CreateConfirm()
        {
            UserVM editUserVM = new UserVM();
            TryUpdateModelAsync(editUserVM);
            editUserVM.Roles = _roleManagementService.GetAll();

            if (!ModelState.IsValid) return View(editUserVM);
           
            int userId = _managementService.Save(editUserVM);
            if (userId == -1) throw new BusinessException(BusinessExceptionEnum.NotSaveObject.GetDescription());

            return RedirectToAction(ListViewName);
        }

        [HttpGet]
        public override IActionResult Edit(int? id)
        {
            if (!id.HasValue) throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());

            IUser user = _managementService.GetById(id.Value);

            UserVM editUserVM = _mapper.Map<IUser, UserVM>(user);
            editUserVM.Roles = _roleManagementService.GetAll();

            return View(EditViewName, editUserVM);
        }

        [HttpPost, ActionName("Edit")]
        [ValidateAntiForgeryToken]
        public override IActionResult EditConfirm()
        {
            UserVM editUserVM = new UserVM();
            TryUpdateModelAsync(editUserVM);
            editUserVM.Roles = _roleManagementService.GetAll();

            ModelState.Remove("EmailConfirm");
            ModelState.Remove("Password");
            if (!ModelState.IsValid) return View(editUserVM);

            int userId = _managementService.Save(editUserVM);
            if (userId == -1) throw new BusinessException(BusinessExceptionEnum.NotSaveObject.GetDescription());

            return RedirectToAction(ListViewName);
        }

        protected override ListUserVM PrepareModelForList(ListUserVM model, IPagedList<IUser> collection, PagerVM pager)
        {
            model.Users = _mapper.Map<IPagedList<IUser>, IPagedList<UserVM>>(collection);

            return model;
        }
    }
}