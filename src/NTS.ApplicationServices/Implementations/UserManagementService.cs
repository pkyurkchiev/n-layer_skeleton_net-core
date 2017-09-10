namespace NTS.ApplicationServices.Implementations
{
    using Data.Entities;
    using Interfaces.Users;
    using Microsoft.Extensions.Logging;
    using Shared;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Utils.Extensions;
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

        public void Delete(int id)
        {
            try
            {
                _unitOfWork.Users.Delete(id);
                _unitOfWork.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }

        public void Save(IUser item)
        {
            User user = null;//_mapper.Map<EditUserVM, User>((EditUserVM)item);

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
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }

        }
        #endregion
    }
}
