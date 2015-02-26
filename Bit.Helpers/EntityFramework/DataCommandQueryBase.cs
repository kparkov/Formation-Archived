using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core.Objects;
using System.Data.Entity.Infrastructure;
using System.Linq;
using AutoMapper;

namespace Bit.Helpers.EntityFramework
{
    public abstract class DataCommandQueryBase
    {
        protected DbContext Context { get; set; }
        private bool AutoSaveDisabledUntilNextManual { get; set; }

        public DataCommandQueryBase(DbContext context)
        {
            Context = context;
        }

        protected IDbSet<T> Set<T>() where T : class
        {
            return Context.Set<T>();
        }

        protected TModel New<TModel>(TModel model) where TModel : class 
        {
            Context.Entry(model).State = EntityState.Added;
            return model;
        }

        protected TModel Modified<TModel>(TModel model) where TModel : class
        {
            Context.Entry(model).State = EntityState.Modified;
            return model;
        }

        protected TModel Unchanged<TModel>(TModel model) where TModel : class
        {
            Context.Entry(model).State = EntityState.Unchanged;
            return model;
        }

        protected TModel Deleted<TModel>(TModel model) where TModel : class
        {
            Context.Entry(model).State = EntityState.Deleted;
            return model;
        }

        protected TModel Detached<TModel>(TModel model) where TModel : class
        {
            Context.Entry(model).State = EntityState.Detached;
            return model;
        }

        protected void Autosave()
        {
            if (!AutoSaveDisabledUntilNextManual)
            {
                Save();
            }
        }

        protected void Save()
        {
            Context.SaveChanges();
            
            AutoSaveDisabledUntilNextManual = false;
        }

        protected void SuspendAutoSaveUntilManual()
        {
            AutoSaveDisabledUntilNextManual = true;
        }

        protected void ConservativeAutoTypeMapping<TSource, TDestination>()
        {
            if (Mapper.FindTypeMapFor<TSource, TDestination>() == null)
            {
                Mapper.CreateMap<TSource, TDestination>();
            }
        }

        protected virtual string[] GetKeyNames<TModel>() where TModel : class
        {
            ObjectContext o = ((IObjectContextAdapter)Context).ObjectContext;
            ObjectSet<TModel> set = o.CreateObjectSet<TModel>();
            IEnumerable<string> keys = set.EntitySet.ElementType.KeyMembers.Select(x => x.Name);

            return keys.ToArray();
        }
    }
}