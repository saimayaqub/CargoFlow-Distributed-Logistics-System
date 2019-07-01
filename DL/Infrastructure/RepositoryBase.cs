
using DL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace DL.Infrastructure
{
    public abstract class RepositoryBase<T> where T : class
    {
        private dbRevLogContext dataContext;
        private readonly DbSet<T> dbset;
        protected RepositoryBase(IDatabaseFactory databaseFactory)
        {
            DatabaseFactory = databaseFactory;
            dbset = DataContext.Set<T>();
        }

        protected IDatabaseFactory DatabaseFactory
        {
            get; private set;
        }

        protected dbRevLogContext DataContext
        {
            get { return dataContext ?? (dataContext = DatabaseFactory.Get()); }
        }

        //Async version of Add(long)
        public async virtual void AddAsync(T entity)
        {
            await dbset.AddAsync(entity);
        }
        public virtual void Add(T entity)
        {
            dbset.Add(entity);           
        }
        public virtual void Update(T entity)
        {
            dbset.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
        public virtual void Delete(T entity)
        {
            dbset.Remove(entity);           
        }
        public virtual void Delete(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbset.Where<T>(where).AsEnumerable();
            foreach (T obj in objects)
                dbset.Remove(obj);
        }

        //Async version of GetByIdAsync(long)
        public async virtual Task<T> GetByIdAsync(long id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual T GetById(long id)
        {
            return dbset.Find(id);
        }

        //Async version of GetByIdAsync(string)
        public async virtual Task<T> GetByIdAsync(string id)
        {
            return await dbset.FindAsync(id);
        }

        public virtual T GetById(string id)
        {
            return dbset.Find(id);
        }

        //Async Version of GetAll
        public async virtual Task<ActionResult<IEnumerable<T>>> GetAllAsync()
        {
            return await dbset.ToListAsync();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return dbset.ToList();
        }

        //Async Version of GetMany
        public async virtual Task<IEnumerable<T>> GetManyAsync(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).ToListAsync();
        }

        public virtual IEnumerable<T> GetMany(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).ToList();
        }

        //Async Version of Get
        public async Task<T> GetAsync(Expression<Func<T, bool>> where)
        {
            return await dbset.Where(where).FirstOrDefaultAsync<T>();
        }

        public T Get(Expression<Func<T, bool>> where)
        {
            return dbset.Where(where).FirstOrDefault<T>();
        }
    }
}
