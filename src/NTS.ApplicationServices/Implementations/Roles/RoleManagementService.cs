namespace NTS.ApplicationServices.Implementations.Roles
{
    using Data.Entities;
    using Interfaces.Roles;
    using Microsoft.Extensions.Logging;
    using Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using ViewModels;
    using ViewModels.Roles;
    using X.PagedList;

    public class RoleManagementService : BaseService, IRoleManagementService
    {
        #region Constructors
        public RoleManagementService(IServiceProvider serviceProvider) 
            : base(serviceProvider) { }
        #endregion

        #region Public Methods
        public int ActivateDeactivate(int id)
        {
            throw new NotImplementedException();
        }

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IPagedList<IRole> Find(FilterRoleVM filters, PagerVM pager)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IRole> GetAll()
        {
            IEnumerable<RoleVM> allRoles = null;

            try
            {
                allRoles = _mapper.Map<IEnumerable<Role>, IEnumerable<RoleVM>>(_unitOfWork.Roles.GetAll().AsEnumerable());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return allRoles;
        }

        public IRole GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Save(IRole item)
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
