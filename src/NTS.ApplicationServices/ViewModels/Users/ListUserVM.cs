namespace NTS.ApplicationServices.ViewModels.Users
{
    using X.PagedList;

    public class ListUserVM : ListVM<FilterUserVM>
    {
        #region Properties
        public IPagedList<UserVM> Users { get; set; }
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
