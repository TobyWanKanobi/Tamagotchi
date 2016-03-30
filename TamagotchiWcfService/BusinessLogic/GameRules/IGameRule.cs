namespace TamagotchiWcfService.BusinessLogic.GameRules
{
    public interface IGameRule
    {
        Tamagotchi ExecuteGameRule(Tamagotchi tamagotchi);
    }
}
