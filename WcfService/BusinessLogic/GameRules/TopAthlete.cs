namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class TopAthlete : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            if (tamagotchi.Health < 20)
                tamagotchi.IsAlive = true;

            return tamagotchi;
        }
    }
}