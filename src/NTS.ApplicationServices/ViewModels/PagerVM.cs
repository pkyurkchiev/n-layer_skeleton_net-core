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
        private static readonly int[] items = [10, 20, 50, 100];
        #endregion

        #region Constructors
        public PagerVM(string action, string controller, int pageSize = 10) : this(1, pageSize)
        {
            Action = action;
            Controller = controller;
        }

        public PagerVM() : this(1, 10) { }

        public PagerVM(int? page, int pageSize)
        {
            CurrentPage = page ?? 1;
            PageSize = pageSize;
            PageSizeList = new SelectList(items);
        }

        public PagerVM(SelectList pageSizeList)
            : this()
        {
            PageSizeList = pageSizeList ?? new SelectList(items);
        }
        #endregion
    }
}
