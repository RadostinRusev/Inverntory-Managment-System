using Inverntory_Managment_System.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Inverntory_Managment_System.Entity
{
        public abstract class BaseRepository<T>
          where T : BaseEntity
        {
            protected DbContext Context { get; set; }
            protected DbSet<T> Items { get; set; }

            public BaseRepository()
            {
                Context = new InventoryDbContext();
                Items = Context.Set<T>();
            }

            public BaseRepository(UnitOfWork uow)
            {
                Context = uow.Context;
                Items = Context.Set<T>();
            }

            protected virtual IQueryable<T> CascadeInclude(IQueryable<T> query)
            {
                return query;
            }
        public int Count(Expression<Func<T, bool>> filter = null)
        {
            IQueryable<T> query = Items;

            if (filter != null)
                query = query.Where(filter);

            return query.Count();
        }
        public List<T> GetAll(Expression<Func<T, bool>> filter = null, bool cascadeInclude = false)
            {
                IQueryable<T> query = Items;

                if (filter != null)
                    query = query.Where(filter);

                if (cascadeInclude)
                    query = CascadeInclude(query);

                return query.ToList();
            }
        public List<T> GetAll(Expression<Func<T, bool>> filter = null, int page = 1, int itemsPerPage = 10, bool cascadeInclude = false)
        {
            IQueryable<T> query = Items;

            if (filter != null)
                query = query.Where(filter);

            if (cascadeInclude)
                query = CascadeInclude(query);

            query = query
                .Skip((page - 1) * itemsPerPage)
                .Take(itemsPerPage);

            return query.ToList();
        }



        public List<TResult> GetReferences<TResult>(Expression<Func<T, bool>> filter, Expression<Func<T, TResult>> selector)
            {
                return Items
                        .Where(filter)
                        .Select(selector)
                        .ToList();
            }

            public T GetById(int id, bool cascadeInclude = false)
            {
                IQueryable<T> query = Items;

                if (cascadeInclude)
                    query = CascadeInclude(query);

                return query
                        .Where(i => i.Id == id)
                        .FirstOrDefault();
            }

            public T GetFirstOrDefault(Expression<Func<T, bool>> filter, bool cascadeInclude = false)
            {
                IQueryable<T> query = Items;

                if (cascadeInclude)
                    query = CascadeInclude(query);

                return query
                          .Where(filter)
                          .FirstOrDefault();
            }

            public void Insert(T item)
            {
                Items.Add(item);
                Context.SaveChanges();
            }

            public void Update(T item)
            {
                Items.Update(item);
                Context.SaveChanges();
            }

            public void Delete(T item)
            {
                Items.Remove(item);
                Context.SaveChanges();
            }
        }
    }

