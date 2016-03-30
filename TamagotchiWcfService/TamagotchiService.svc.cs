using System;
using System.Collections.Generic;
using System.Linq;
using TamagotchiWcfService.Contract;
using TamagotchiWcfService.BusinessLogic.GameRules;
using TamagotchiWcfService.Data.Repository;

namespace TamagotchiWcfService
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "Service1" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select Service1.svc or Service1.svc.cs at the Solution Explorer and start debugging.
    public class TamagotchiService : ITamagotchiService
    { 
        public IGameRule[] Rules { get; set; }
        private ITamagotchiRepository TamagotchiRepository { get; set; }

        public TamagotchiService(IGameRule[] rules, ITamagotchiRepository tamagotchiRepository)
        {
            Rules = rules;
            TamagotchiRepository = tamagotchiRepository;
        }

        public void CreateTamagotchi(string name)
        {
            throw new NotImplementedException();
        }

        public TamagotchiContract GetTamagotchiByName(string Name)
        {
            if (String.IsNullOrEmpty(Name))
                return null;

            BusinessLogic.Tamagotchi tamagotchi = TamagotchiRepository.GetByName(Name);
            ExecuteRules(tamagotchi);

            return new TamagotchiContract() {
                Name = tamagotchi.Name,
                Status = tamagotchi.Status,
                Health = tamagotchi.Health,
                Sleep = tamagotchi.Sleep,
                Boredom = tamagotchi.Boredom,
                Hunger = tamagotchi.Hunger,
                IsAlive = tamagotchi.IsAlive,
                Cooldown = tamagotchi.Cooldown,
                LastAccess = tamagotchi.LastAccess,
                LastAction = tamagotchi.LastAction
            };
        }

        public List<TamagotchiContract> GetTamagotchies()
        {
            List<BusinessLogic.Tamagotchi> tamagotchies = TamagotchiRepository.GetAll();

            return tamagotchies.Select(t => new TamagotchiContract() {
                    Name = t.Name,
                    Status = t.Status,
                    Health = t.Health,
                    Sleep = t.Sleep,
                    Boredom = t.Boredom,
                    Hunger = t.Hunger,
                    IsAlive = t.IsAlive,
                    Cooldown = t.Cooldown,
                    LastAccess = t.LastAccess,
                    LastAction = t.LastAction
            }).ToList();
        }

        public TamagotchiContract ExecuteAction(ActionContract contract)
        {
            BusinessLogic.Tamagotchi tamagotchi = TamagotchiRepository.GetByName(contract.Name);

            if (tamagotchi == null)
                return null;

            IGameRule crazyRule = Rules.Where(r => r.GetType().Name.Equals("Crazy")).First();
            crazyRule.ExecuteGameRule(tamagotchi);

            if (!tamagotchi.IsAlive)
            {
                return null;
            }

            tamagotchi.StartAction(contract.Action);
            TamagotchiRepository.Save(tamagotchi);

            return new TamagotchiContract() {
                Name = tamagotchi.Name,
                Status = tamagotchi.Status,
                Health = tamagotchi.Health,
                Sleep = tamagotchi.Sleep,
                Boredom = tamagotchi.Boredom,
                Hunger = tamagotchi.Hunger,
                IsAlive = tamagotchi.IsAlive,
                Cooldown = tamagotchi.Cooldown,
                LastAccess = tamagotchi.LastAccess,
                LastAction = tamagotchi.LastAction
            };

        }

        private void ExecuteRules(BusinessLogic.Tamagotchi tamagotchi)
        {

            var rulestoexecute = Rules.Where(r => 
            r.GetType().Name.Equals("Fatique") ||
            r.GetType().Name.Equals("Hunger") ||
            r.GetType().Name.Equals("Boredom") ||
            r.GetType().Name.Equals("Isolation") ||
            r.GetType().Name.Equals("SleepDeprivation") ||
            r.GetType().Name.Equals("FoodShortage")
            ).ToArray();

            int loops = DateTime.Now.Subtract(tamagotchi.LastAccess).Hours;

            for(int i = 0; i < loops; i++)
            {
                foreach(IGameRule rule in rulestoexecute)
                {
                    rule.ExecuteGameRule(tamagotchi);
                }
            }

            TamagotchiRepository.Save(tamagotchi);
        }
    }
}
