namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public class Hunger : IGameRule
    {
        public IGameRule Munchies { get; set; }

        public Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi)
        {

            if (tamagotchi.Boredom > 80)
                Munchies.ExecuteGameRule(tamagotchi);
            else           
                tamagotchi.Hunger += 5;

            return tamagotchi;
        }
    }
}