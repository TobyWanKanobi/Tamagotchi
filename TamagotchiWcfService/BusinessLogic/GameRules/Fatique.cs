namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class Fatique : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            tamagotchi.Sleep += 5;

            return tamagotchi;
        }
    }
}