using System.Data.Entity;
using TamagotchiWcfService.Data.Model;

namespace TamagotchiWcfService.Data
{
    public class TamagotchiContext : DbContext
    {
        public TamagotchiContext() : base("TamagotchiContext")
        {
            Database.SetInitializer(new Seeder());
        }
       public  DbSet<Tamagotchi> Tamagotchies { get; set; }
    }
}
