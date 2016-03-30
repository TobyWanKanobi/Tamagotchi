namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class FoodShortage : IGameRule
    {

        public IGameRule TopAthlete { get; set; }

        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {

            if (tamagotchi.Hunger == 100)
            {
                tamagotchi.IsAlive = false;
                TopAthlete.ExecuteGameRule(tamagotchi);
            }

            return tamagotchi;
        }
    }
}