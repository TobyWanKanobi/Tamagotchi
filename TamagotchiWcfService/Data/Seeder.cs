using System;
using System.Data.Entity;
using TamagotchiWcfService.Data.Model;

namespace TamagotchiWcfService.Data
{
    public class Seeder : DropCreateDatabaseAlways<TamagotchiContext>
    {
        protected override void Seed(TamagotchiContext context)
        {
            Tamagotchi tamagotchi = new Tamagotchi()
            {
                Name = "Henk",
                Boredom = 0,
                Health = 0,
                Hunger = 0,
                Sleep = 0,
                IsAlive = true,
                LastAccess = DateTime.Now.Subtract(TimeSpan.FromHours(3)),
                ActionStarted = DateTime.Now
            };
            context.Tamagotchies.Add(tamagotchi);
            context.SaveChanges();
            
            base.Seed(context);
        }
    }
}