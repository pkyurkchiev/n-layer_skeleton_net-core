namespace NTS.ApplicationServices.Interfaces
{
    using System.Collections.Generic;
    using ViewModels;
    using X.PagedList;

    public interface IManagementService<TObject, TFilter> : IService where TObject : IObject where TFilter : class
    {
        TObject GetById(int id);

        IEnumerable<TObject> GetAll();

        int ActivateDeactivate(int id);

        int Save(TObject item);

        int Delete(int id);

        IPagedList<TObject> Find(TFilter filters, PagerVM pager);

    }
}
