namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class SleepDeprivation : IGameRule
    {

        public IGameRule TopAthlete { get; set; }

        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if(tamagotchi.Sleep == 100)
            {
                tamagotchi.IsAlive = false;
                TopAthlete.ExecuteGameRule(tamagotchi);
            }

            return tamagotchi;
        }
    }
}