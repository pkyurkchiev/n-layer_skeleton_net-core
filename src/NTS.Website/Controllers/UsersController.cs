namespace NTS.Website.Controllers
{
    using ApplicationServices.Interfaces.Users;
    using ApplicationServices.ViewModels;
    using ApplicationServices.ViewModels.Users;
    using Shared;
    using System;
    using System.Collections.Generic;

    public class UsersController : BaseManagementController<IUser, ListUserVM, UserVM, FilterUserVM>
    {
        public UsersController(IUserManagementService userManagementService,
                                IServiceProvider serviceProvider)
            : base(userManagementService, serviceProvider) { }

        protected override ListUserVM PrepareModelForList(ListUserVM model, IEnumerable<IUser> collection, PagerVM pager)
        {
            model.Users = _mapper.Map<IEnumerable<IUser>, IEnumerable<UserVM>>(collection);

            return model;
        }
    }
}