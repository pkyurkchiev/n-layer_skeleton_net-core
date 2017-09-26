namespace NTS.ApplicationServices.ViewModels
{
    public abstract class ListVM<TFilters>
    {
        public TFilters Filters { get; set; }

        public PagerVM Pager { get; set; }
    }
}
