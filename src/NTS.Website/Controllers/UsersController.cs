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

            if (String.IsNullOrEmpty(editUserVM.Password))
            {
                ModelState.AddModelError(String.Empty, "Полето за парола е задължително.");
                editUserVM.Roles = _roleManagementService.GetAll();

                return View(editUserVM);
            }

            if (!ModelState.IsValid) throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            _managementService.Save(editUserVM);

            return RedirectToAction(ListViewName);
        }

        public override IActionResult Edit(int? id)
        {
            if (!id.HasValue) throw new BusinessException(BusinessExceptionEnum.NotFoundException.GetDescription());

            var user = _managementService.GetById(id.Value);

            if (user == null) throw new BusinessException(BusinessExceptionEnum.NotValideObject.GetDescription());

            UserVM editUserVM = _mapper.Map<IUser, UserVM>(user);
            editUserVM.Roles = _roleManagementService.GetAll();

            return View(EditViewName, editUserVM);
        }

        protected override ListUserVM PrepareModelForList(ListUserVM model, IPagedList<IUser> collection, PagerVM pager)
        {
            model.Users = _mapper.Map<IPagedList<IUser>, IPagedList<UserVM>>(collection);

            return model;
        }
    }
}