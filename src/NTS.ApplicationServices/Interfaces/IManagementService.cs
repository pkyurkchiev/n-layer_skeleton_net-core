namespace NTS.ApplicationServices.Interfaces
{
    using System.Collections.Generic;
    using ViewModels;

    public interface IManagementService<TObject, TFilter> : IService where TObject : IObject where TFilter : class
    {
        TObject GetById(int id);

        IEnumerable<TObject> GetAll();

        int ActivateDeactivate(int id);

        int Save(TObject item);

        int Delete(int id);

        IEnumerable<TObject> Find(TFilter filters, PagerVM pager);

    }
}
