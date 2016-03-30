using System.Collections.Generic;
using TamagotchiWcfService.BusinessLogic;

namespace TamagotchiWcfService.Data.Repository
{
    public interface ITamagotchiRepository
    {
        Tamagotchi GetByName(string name);

        List<Tamagotchi> GetAll();

        bool Save(Tamagotchi tamagotchi);
    }
}
