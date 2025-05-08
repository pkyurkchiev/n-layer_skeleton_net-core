﻿namespace NTS.Repositories.Implementations
{
    using Data.Entities;
    using Data.Entities.Interfaces;
    using Interfaces;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.ChangeTracking;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using X.PagedList;
    using X.PagedList.Extensions;

    public class Repository<T> : IRepository<T> where T : Entity, IIsActive
    {
        #region Constructors
        public Repository(DbContext context)
        {
            this.Context = context ?? throw new ArgumentException("An instance of DbContext is required to use this repository.", nameof(context));
            this.DbSet = this.Context.Set<T>();
        }

        #endregion

        #region Properties

        protected DbSet<T> DbSet { get; set; }

        protected DbContext Context { get; set; }

        #endregion

        #region  Methods

        public virtual IEnumerable<T> GetAll(bool isActive = true)
        {
            var query = this.DbSet.AsQueryable();

            return SoftDeleteQueryFilter(query, isActive);
        }

        public virtual T GetById(object id, bool isActive = true)
        {
            return this.DbSet.Find(id);
        }

        public virtual void Insert(T entity)
        {
            //entity.CreatedBy = ;
            entity.CreatedOn = DateTime.UtcNow;

            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Detached)
            {
                entry.State = EntityState.Added;
            }
            else
            {
                this.DbSet.Add(entity);
            }
        }

        public virtual void Update(T entity, string excludeProperties = "")
        {
            //entity.UpdatedBy = ;
            entity.UpdatedOn = DateTime.UtcNow;

            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State == EntityState.Detached)
            {
                this.DbSet.Attach(entity);
            }

            entry.State = EntityState.Modified;

            entry.Property("CreatedBy").IsModified = false;
            entry.Property("CreatedOn").IsModified = false;

            foreach (var excludeProperty in excludeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
            {
                entry.Property(excludeProperty).IsModified = false;
            }
        }

        public virtual void Save(T entity)
        {
            if (entity.Id == 0)
            {
                this.Insert(entity);
            }
            else
            {
                this.Update(entity);
            }
        }

        public virtual void ActivateDeactivate(T entity)
        {
            entity.IsActive = !entity.IsActive;
            this.Update(entity);
        }

        public virtual void ActivateDeactivate(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                ActivateDeactivate(entity);
            }
        }
    
        public virtual void Delete(T entity)
        {
            EntityEntry<T> entry = this.Context.Entry(entity);
            if (entry.State != EntityState.Deleted)
            {
                entry.State = EntityState.Deleted;
            }
            else
            {
                this.DbSet.Attach(entity);
                this.DbSet.Remove(entity);
            }
        }

        public virtual void Delete(object id)
        {
            var entity = this.GetById(id);

            if (entity != null)
            {
                this.Delete(entity);
            }
        }

        public virtual void Detach(T entity)
        {
            EntityEntry<T> entry = this.Context.Entry(entity);

            entry.State = EntityState.Detached;
        }
        #endregion

        #region Filters Methods

        /// <summary>
        /// Represents a method that returns a list of objects of a certain class. 
        /// The method can return a list of all objects or only the objects filtered by some condition
        /// </summary>
        /// <param name="where">Represent a filter that can be used for filtering items by some criteria</param>
        /// <param name="OrderByDescending">Represents the order of the items on each of the pages - in this case - descending</param>
        /// <param name="includeProperties">Represents some additional properties of the objects that can be included in the list</param>
        /// <param name="isActive">Represents only active or unactive user</param>
        /// <returns>Returns a list of object of a certain class - all of them or filtered by some cretiria</returns>
        public virtual IEnumerable<T> Find(Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending = null, string includeProperties = "", bool isActive = true)
        {
            var query = this.DbSet.AsQueryable();

            if (where != null)
            {
                query = query.Where(where);
            }

            foreach (var includeProperty in includeProperties.Split([','], StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (OrderByDescending != null)
            {
                query = OrderByDescending(query);
            }

            return SoftDeleteQueryFilter(query, isActive);
        }

        /// <summary>
        /// Represents a method that returns a list of objects of a certain class. 
        /// The method can return a list of all objects or only the objects filtered by some condition
        /// </summary>
        /// <param name="currentPage">Represents the start page of the pager</param>
        /// <param name="itemsPerPage">Represents the number of items that will be shown on each of the pages</param>
        /// <param name="filter">Represent a filter that can be used for filtering items by some criteria</param>
        /// <param name="OrderByDescending">Represents the order of the items on each of the pages - in this case - descending</param>
        /// <param name="includeProperties">Represents some additional properties of the objects that can be included in the list</param>
        /// <param name="isActive">Represents only active or unactive user</param>
        /// <returns>Returns a list of object of a certain class - all of them or filtered by some cretiria</returns>
        public IPagedList<T> Find(int currentPage = 0, int itemsPerPage = 0, Expression<Func<T, bool>> where = null, Func<IQueryable<T>, IOrderedQueryable<T>> OrderByDescending = null, string includeProperties = "", bool? isActive = true)
        {
            var query = this.DbSet.AsQueryable();

            if (where != null)
            {
                query = query.Where(where);
            }

            foreach (var includeProperty in includeProperties.Split
                ([','], StringSplitOptions.RemoveEmptyEntries))
            {
                query = query.Include(includeProperty);
            }

            if (OrderByDescending != null)
            {
                query = OrderByDescending(query);
            }

            if (OrderByDescending == null)
            {
                query = query.OrderByDescending(i => i.CreatedOn);
            }

            return SoftDeleteQueryFilter(query, isActive).ToPagedList(currentPage, itemsPerPage);
        }
        #endregion

        //TODO async methods

        #region Private Methods

        private static IQueryable<T> SoftDeleteQueryFilter(IQueryable<T> query, bool? isActive)
        {
            if (isActive.HasValue) query = query.Where(x => x.IsActive == isActive.Value);
            return query;
        }

        #endregion
    }
}
