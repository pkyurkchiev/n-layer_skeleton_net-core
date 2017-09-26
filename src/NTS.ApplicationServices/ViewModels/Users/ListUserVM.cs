namespace NTS.ApplicationServices.ViewModels.Users
{
    using System.Collections.Generic;

    public class ListUserVM : ListVM<FilterUserVM>
    {
        #region Properties
        public IEnumerable<UserVM> Users { get; set; }
        #endregion

        #region Constructors
        public ListUserVM()
            : base()
        {
            Filters = new FilterUserVM();
        }
        #endregion
    }
}
