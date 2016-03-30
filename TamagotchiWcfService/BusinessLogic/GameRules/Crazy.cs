using System;
namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class Crazy : IGameRule
    {
        Random random = new Random();

        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Health == 100 && random.Next(0,2) == 1)
                tamagotchi.IsAlive = false;

            return tamagotchi;
        }
    }
}