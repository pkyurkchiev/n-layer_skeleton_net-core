namespace NTS.Repositories.Interfaces
{
    using Data.Entities;
    using Data.Entities.Interfaces;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using X.PagedList;

    public interface IRepository<T> where T : Entity, IIsActive
    {
        IEnumerable<T> GetAll(bool isActive = true);

        T GetById(object id, bool isActive = true);

        void Insert(T entity);

        void Update(T entity, string excludeProperties = "");

        void ActivateDeactivate(T entity);

        void ActivateDeactivate(object id);

        void Delete(object id);

        void Delete(T entity);

        void Detach(T entity);

        IEnumerable<T> Find(Expression<Func<T, bool>> where,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending = null, string includeProperties = "", bool isActive = true);

        IPagedList<T> Find(int currentPage = 0, int itemsPerPage = 0, Expression<Func<T, bool>> where = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending = null, string includeProperties = "", bool? isActive = true);
    }
}
