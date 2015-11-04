namespace BookStore.Services.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    
    using Models;

    class InMemoryRepository<T> : IRepository<T>
        where T : IEntity
    {
        private static Dictionary<string, List<object>> db;
        private List<object> data;
        private int lastUsedId;

        static InMemoryRepository()
        {
            db = new Dictionary<string, List<object>>();
        }

        public InMemoryRepository()
        {
            if (!db.ContainsKey(typeof(T).FullName))
            {
                db[typeof(T).FullName] = new List<object>();
            }
            this.data = db[typeof(T).FullName];
            if (this.data.Count > 0)
            {
                this.lastUsedId = this.data.Max(obj => ((IEntity)obj).Id);
            }
            else
            {
                this.lastUsedId = 0;
            }
        }

        public void Add(T entity)
        {
            entity.Id = ++lastUsedId;
            this.data.Add(entity);
        }

        public IQueryable<T> All()
        {
            return this.data.Select(obj => (T)obj)
                    .AsQueryable();
        }

        public T Find(int id)
        {
            var entity = this.data.FirstOrDefault(obj => ((T)obj).Id == id);
            if (entity == null)
            {
                throw new NullReferenceException("Entity with such ID does not exists");
            }
            return (T)entity;
        }

        public IQueryable<T> Search(Expression<Func<T, bool>> filter)
        {
            return this.data.Select(obj => ((T)obj))
                            .AsQueryable()
                            .Where(filter);
        }
    }
}
