namespace NTS.ApplicationServices.ViewModels.Roles
{
    using Interfaces.Roles;
    using System.ComponentModel.DataAnnotations;

    public class RoleVM : BaseVM, IRole
    {
        [Display(Name = "Name")]
        public string Name { get; set; }
    }
}
