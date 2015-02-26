using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using AutoMapper;

namespace Bit.Helpers.EntityFramework
{
    public class CrudCommands : DataCommandQueryBase
    {
        public CrudCommands(DbContext context) : base(context)
        {
        }

        public virtual TModel Create<TModel>(TModel model) where TModel : class
        {
            var result = Set<TModel>().Add(model);
            Autosave();

            return result;
        }

        public virtual IEnumerable<TModel> Create<TModel>(IEnumerable<TModel> models) where TModel : class
        {
            SuspendAutoSaveUntilManual();
            var result = models.ToList().Select(Create);
            Save();
            return result;
        }

        public virtual TModel Create<TViewModel, TModel>(TViewModel viewModel) where TModel : class
        {
            ConservativeAutoTypeMapping<TViewModel, TModel>();
            var result = Mapper.Map<TModel>(viewModel);
            Set<TModel>().Add(result);
            Autosave();

            return result;
        }

        public virtual IEnumerable<TModel> Create<TViewModel, TModel>(IEnumerable<TViewModel> viewModels) where TModel : class
        {
            SuspendAutoSaveUntilManual();
            var result = viewModels.ToList().Select(Create<TViewModel, TModel>);
            Save();
            return result;
        }

        public virtual void Update<TViewModel, TModel>(TViewModel viewModel, TModel model) where TModel : class
        {
            ConservativeAutoTypeMapping<TViewModel, TModel>();
            Mapper.Map(viewModel, model);

            Modified(model);

            Autosave();
        }

        public virtual void Update<TViewModel, TModel>(TViewModel viewModel) where TModel : class
        {
            ConservativeAutoTypeMapping<TViewModel, TModel>();
            var keyNames = GetKeyNames<TModel>();
            var viewModelKeyValues = keyNames.Select(x => viewModel.GetType().GetProperty(x).GetValue(viewModel)).ToArray();
            var dbModel = Set<TModel>().Find(viewModelKeyValues);
            Mapper.Map(viewModel, dbModel);

            Modified(dbModel);

            Autosave();
        }

        public virtual void Delete<TModel>(TModel model) where TModel : class
        {
            var dbModel = Set<TModel>().Find(GetKeyNames<TModel>().Select(x => (object)x).ToArray());
            Set<TModel>().Remove(dbModel);
            Autosave();
        }

        public virtual void Delete<TViewModel, TModel>(TViewModel viewModel) where TModel : class
        {
            var type = typeof (TViewModel);
            var keyValues = GetKeyNames<TModel>().Select(x => type.GetProperty(x).GetValue(viewModel)).ToArray();
            var dbModel = Set<TModel>().Find(keyValues);

            Set<TModel>().Remove(dbModel);

            Autosave();
        }

        public virtual IEnumerable<TModel> Retrieve<TModel>() where TModel : class
        {
            return Set<TModel>().ToList();
        }

        public virtual IEnumerable<TViewModel> Retrieve<TModel, TViewModel>() where TModel : class
        {
            ConservativeAutoTypeMapping<TModel, TViewModel>();
            return Set<TModel>().ToList().Select(Mapper.Map<TViewModel>);
        }

        public virtual IEnumerable<TModel> Retrieve<TModel>(Func<TModel, bool> predicate) where TModel : class
        {
            return Set<TModel>().Where(predicate).ToList();
        }

        public virtual IEnumerable<TViewModel> Retrieve<TModel, TViewModel>(Func<TModel, bool> predicate) where TModel : class
        {
            ConservativeAutoTypeMapping<TModel, TViewModel>();
            return Set<TModel>().Where(predicate).ToList().Select(Mapper.Map<TViewModel>);
        }

        public virtual TModel Retrieve<TModel>(params object[] id) where TModel : class
        {
            return Set<TModel>().Find(id);
        }

        public virtual TViewModel Retrieve<TModel, TViewModel>(params object[] id) where TModel : class
        {
            ConservativeAutoTypeMapping<TModel, TViewModel>();
            var model = Set<TModel>().Find(id);
            return Mapper.Map<TViewModel>(model);
        }

        public virtual TModel Retrieve<TViewModel, TModel>(TViewModel viewModel) where TModel : class
        {
            var keyValues = GetKeyNames<TModel>().Select(x => viewModel.GetType().GetProperty(x).GetValue(viewModel)).ToArray();
            var dbModel = Set<TModel>().Find(keyValues);

            return dbModel;
        }

        public virtual IQueryable<TModel> Queryable<TModel>() where TModel : class
        {
            return Set<TModel>();
        }
    }
}