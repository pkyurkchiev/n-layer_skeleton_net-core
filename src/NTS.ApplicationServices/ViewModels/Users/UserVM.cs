namespace NTS.ApplicationServices.ViewModels.Users
{
    using Interfaces.Roles;
    using Interfaces.Users;
    using System.Collections.Generic;

    public class UserVM : BaseVM, IUser
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserName { get; set; }

        public string Password { get; set; }

        public string ConfirmPassword { get; set; }

        public int RoleId { get; set; }
        public IEnumerable<IRole> Roles { get; set; }

        public string RoleName { get; set; }
    }
}
