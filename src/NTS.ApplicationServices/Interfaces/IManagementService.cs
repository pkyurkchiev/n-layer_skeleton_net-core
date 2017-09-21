namespace NTS.ApplicationServices.Interfaces
{
    using System.Collections.Generic;

    public interface IManagementService<TObject> : IService where TObject : IObject
    {
        TObject GetById(int id);

        IEnumerable<TObject> GetAll();

        int Save(TObject item);

        int Delete(int id);

        //IPagedList<TObject> Find(TFilter filters, PagerVM pager);

    }
}
