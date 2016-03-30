namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class Boredom : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            tamagotchi.Boredom += 15;

            return tamagotchi;
        }
    }
}