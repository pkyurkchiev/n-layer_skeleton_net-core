namespace NTS.ApplicationServices.ViewModels
{
    using Microsoft.AspNetCore.Mvc.Rendering;

    public class PagerVM
    {
        #region Properties
        public string Action { get; set; }

        public string Controller { get; set; }

        public int CurrentPage { get; set; }

        public int PageSize { get; set; }

        public SelectList PageSizeList { get; set; }
        #endregion

        #region Constructors
        public PagerVM(string action, string controller) : this()
        {
            Action = action;
            Controller = controller;
        }

        public PagerVM() : this(0, 1, 0) { }

        public PagerVM(int totalItems, int? page, int pageSize)
        {
            if (pageSize == 0) pageSize = 10;

            CurrentPage = page ?? 1;
            PageSize = pageSize;
            PageSizeList = new SelectList(new int[] { 10, 20, 50, 100 });
        }
        #endregion
    }
}
