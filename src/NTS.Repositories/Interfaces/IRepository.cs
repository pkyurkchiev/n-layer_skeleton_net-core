namespace NTS.Repositories.Interfaces
{
        using Data.Entities;
        using Data.Entities.Interfaces;
        using System;
        using System.Linq;
        using System.Linq.Expressions;

        public interface IRepository<T> where T : Entity, IIsActive
        {
            IQueryable<T> GetAll(bool isActive = true);

            T GetById(object id, bool isActive = true);

            void Insert(T entity);

            void Update(T entity, string excludeProperties = "");

            void ActivateDeactivate(T entity);

            void ActivateDeactivate(object id);

            void Delete(object id);

            void Delete(T entity);

            void Detach(T entity);

            IQueryable<T> Find(Expression<Func<T, bool>> where,
                Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending = null, string includeProperties = "", bool isActive = true);
        }
}
