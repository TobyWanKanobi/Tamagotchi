namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class Isolation : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            tamagotchi.Health += 5;

            return tamagotchi;
        }
    }
}