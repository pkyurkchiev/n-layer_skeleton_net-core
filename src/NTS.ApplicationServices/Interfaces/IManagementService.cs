namespace NTS.ApplicationServices.Interfaces
{
    using System.Collections.Generic;

    public interface IManagementService<TObject> : IService where TObject : IObject
    {
        void Save(TObject item);

        void Delete(int id);

        TObject GetById(int id);

        IEnumerable<TObject> GetAll();

        //IPagedList<TObject> Find(TFilter filters, PagerVM pager);

    }
}
