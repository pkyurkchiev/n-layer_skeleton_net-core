namespace NTS.ApplicationServices.Implementations
{
    using Data.Entities;
    using Interfaces.Users;
    using Microsoft.Extensions.Logging;
    using Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using Utils.Extensions;
    using ViewModels;
    using ViewModels.Users;

    public class UserManagementService : BaseService, IUserManagementService
    {
        #region Constructors
        public UserManagementService(IServiceProvider serviceProvider)
            : base(serviceProvider) { }
        #endregion

        #region Public Methods
        public IEnumerable<IUser> GetAll()
        {
            IEnumerable<UserVM> allUsers = null;

            try
            {
                allUsers = _mapper.Map<IEnumerable<User>, IEnumerable<UserVM>>(
                    _unitOfWork.Users.GetAll().AsEnumerable());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return allUsers;

        }

        public IEnumerable<IUser> Find(FilterUserVM filters, PagerVM pager)
        {
            IEnumerable<UserVM> allUsers = null;
            Expression<Func<User, bool>> filter = null;

            try
            {
                if (!String.IsNullOrEmpty(filters.Name)) filter = x => x.FirstName.Contains(filters.Name);
                allUsers = _mapper.Map<IEnumerable<User>, IEnumerable<UserVM>>(
                    _unitOfWork.Users.Find(pager.CurrentPage, pager.PageSize, filter, null, String.Empty, !filters.IsActiveDisplayed));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return allUsers;
        }

        public IUser GetById(int id)
        {
            UserVM user = null;

            try
            {
                user = _mapper.Map<User, UserVM>(
                    _unitOfWork.Users.GetById(id));
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

            return user;

        }

        public int ActivateDeactivate(int id)
        {
            try
            {
                _unitOfWork.Users.ActivateDeactivate(id);
                _unitOfWork.SaveChanges();

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return -1;
            }
        }

        public int Delete(int id)
        {
            try
            {
                _unitOfWork.Users.Delete(id);
                _unitOfWork.SaveChanges();

                return id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return -1;
            }

        }

        public int Save(IUser item)
        {
            User user = _mapper.Map<UserVM, User>((UserVM)item);

            try
            {
                if (item.Id.IsAnyNullOrEmpty())
                {
                    user.Password = EncryptionUtils.ToSHA512(user.Password);
                    _unitOfWork.Users.Insert(user);
                }
                else
                {
                    _unitOfWork.Users.Update(user);
                }

                _unitOfWork.SaveChanges();

                return user.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return -1;
            }

        }
        #endregion
    }
}
