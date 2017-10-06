namespace NTS.ApplicationServices.ViewModels.Roles
{
    using Interfaces.Roles;

    public class RoleVM : BaseVM, IRole
    {
        public string Name { get; set; }
    }
}
