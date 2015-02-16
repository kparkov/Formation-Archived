using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using Bit.Helpers.EntityFramework;
using Formation.Data.Model;

namespace Formation.GameLogic.Flow
{
    public class Persistence : DataCommandQueryBase
    {
        public Persistence(DbContext context) : base(context)
        {
        }

        public Game LoadGame(Guid id)
        {
            return Set<Game>().Find(id);
        }

        public void SaveGame(Game game)
        {
            MarkToBottom(game);
            
            Save();
        }

        public Player CreateOrGetPlayer(string name)
        {
            var existing = Enumerable.SingleOrDefault(Set<Player>().Where(x => x.Name.ToLower() == name.ToLower()));

            if (existing != null)
            {
                return existing;
            }

            var player = new Player() { Name = name };

            Mark(player);

            Save();

            return player;
        }

        public void ResetGameDatabase()
        {
            if (Context.Database.Exists())
            {
                Context.Database.Delete();
            }

            Context.Database.Create();
        }

        private HashSet<Base> _cache = new HashSet<Base>(); 

        private void MarkToBottom(Base model, bool recursiveCall = false)
        {
            if (!recursiveCall) _cache.Clear();

            if (_cache.Contains(model)) return;

            Mark(model);

            _cache.Add(model);

            var publicProperties = model.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);

            var directProperties = publicProperties.Where(x => typeof(Base).IsAssignableFrom(x.PropertyType));

            directProperties.Select(x => x.GetValue(model))
                .Cast<Base>()
                .ToList()
                .ForEach(x => MarkToBottom(x, true));

            var collectionProperties = publicProperties.Where(x => typeof(IEnumerable<Base>).IsAssignableFrom(x.PropertyType));
                
            collectionProperties.Select(x => x.GetValue(model))
                .Cast<IEnumerable<Base>>()
                .ToList()
                .ForEach(x => x.ToList().ForEach(y => MarkToBottom(y, true)));
        }

        private void Mark(Base model)
        {
            if (model.IsNew())
            {
                model.GenerateId();
                New(model);
            }
            else
            {
                Modified(model);
            }
        }
    }
}