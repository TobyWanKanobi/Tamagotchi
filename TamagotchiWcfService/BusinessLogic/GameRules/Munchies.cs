namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class Munchies : IGameRule
    {
        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {
            tamagotchi.Hunger += 10;
           
            return tamagotchi;
        }
    }
}