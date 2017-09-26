namespace NTS.ApplicationServices.ViewModels.Users
{
    using System;

    public class FilterUserVM : FilterVM
    {
        public string Name { get; set; }

        public override bool IsActive { get { return !String.IsNullOrEmpty(Name) || IsActiveDisplayed; } }
    }
}
