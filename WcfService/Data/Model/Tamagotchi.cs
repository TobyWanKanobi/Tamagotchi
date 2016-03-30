using System;
using System.ComponentModel.DataAnnotations;

namespace TamagotchiWcfService.Data.Model
{
    public class Tamagotchi
    {
        [Key]
        public string Name { get; set; }

        public int Cooldown { get; set; }

        public bool IsAlive { get; set; }

        public DateTime LastAccess { get; set; }
  
        public DateTime ActionStarted { get; set; }

        public int Hunger { get; set; }

        public int Sleep { get; set; }

        public int Boredom { get; set; }

        public int Health { get; set; }
    }
}
