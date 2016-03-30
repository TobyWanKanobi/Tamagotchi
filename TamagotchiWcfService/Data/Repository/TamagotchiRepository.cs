using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using TamagotchiWcfService.BusinessLogic;

namespace TamagotchiWcfService.Data.Repository
{

    public class TamagotchiRepository : ITamagotchiRepository
    {

        private TamagotchiContext _context;

        public TamagotchiRepository()
        {
            _context = new TamagotchiContext();
        }

        private IQueryable<Tamagotchi> All()
        {
            return _context.Tamagotchies.Select(t => new TamagotchiWcfService.BusinessLogic.Tamagotchi()
            {
                Name = t.Name,
                Boredom = t.Boredom,
                Cooldown = t.Cooldown,
                Health = t.Health,
                Hunger = t.Hunger,
                IsAlive = t.IsAlive,
                LastAccess = t.LastAccess,
                LastAction = t.ActionStarted,
                Sleep = t.Sleep,
            });
        }

        public Tamagotchi GetByName(string name)
        {
            return this.All().Where(t => t.Name == name).FirstOrDefault();
        }

        public List<Tamagotchi> GetAll()
        {
            return this.All().ToList();
        }

        public bool Save(Tamagotchi tamagotchi)
        {
            Model.Tamagotchi result = _context.Tamagotchies
                .Where(t => t.Name == tamagotchi.Name)
                .FirstOrDefault();

            if (result == null)
            {
                result.Name = tamagotchi.Name;
                result.IsAlive = tamagotchi.IsAlive;
                result.Health = tamagotchi.Health;
                result.Hunger = tamagotchi.Hunger;
                result.Sleep = tamagotchi.Sleep;
                result.Boredom = tamagotchi.Boredom;
                result.Cooldown = tamagotchi.Cooldown;
                result.ActionStarted = tamagotchi.LastAction;
                result.LastAccess = tamagotchi.LastAccess;
               
                _context.Tamagotchies.Add(result);
            }
            else
            {
                result.Name = tamagotchi.Name;
                result.ActionStarted = tamagotchi.LastAction;
                result.Hunger = tamagotchi.Hunger;
                result.IsAlive = tamagotchi.IsAlive;
                result.LastAccess = tamagotchi.LastAccess;
                result.Sleep = tamagotchi.Sleep;
                result.Boredom = tamagotchi.Boredom;
                result.Cooldown = tamagotchi.Cooldown;
                result.Health = tamagotchi.Health;

                _context.Tamagotchies.Attach(result);
                var entry = _context.Entry(result);
                entry.State = EntityState.Modified;
            }

            _context.SaveChanges();

            return true;
        }

        public bool Create(Tamagotchi tamagotchi)
        {
            Model.Tamagotchi result = _context.Tamagotchies
            .Where(t => t.Name == tamagotchi.Name)
            .FirstOrDefault();

            if (result != null)
                return false;

            result = new Model.Tamagotchi();

            result.Name = tamagotchi.Name;
            result.IsAlive = tamagotchi.IsAlive;
            result.Health = tamagotchi.Health;
            result.Hunger = tamagotchi.Hunger;
            result.Sleep = tamagotchi.Sleep;
            result.Boredom = tamagotchi.Boredom;
            result.Cooldown = tamagotchi.Cooldown;
            result.ActionStarted = tamagotchi.LastAction;
            result.LastAccess = tamagotchi.LastAccess;

            _context.Tamagotchies.Add(result);
            _context.SaveChanges();

            return true;
            
        }
    }

}