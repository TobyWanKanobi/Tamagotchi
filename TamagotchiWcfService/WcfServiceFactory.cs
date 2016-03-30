using Microsoft.Practices.Unity;
using TamagotchiWcfService.BusinessLogic.GameRules;
using TamagotchiWcfService.Data;
using Unity.Wcf;
using WcfService.Data.Repository;

namespace TamagotchiWcfService
{
    public class WcfServiceFactory : UnityServiceHostFactory
    {
        protected override void ConfigureContainer(IUnityContainer container)
        {
            // register all your components with the container here
            container
                .RegisterType<ITamagotchiService, TamagotchiService>()
                .RegisterType<ITamagotchiRepository, TamagotchiRepository>()
                .RegisterType<IGameRule, TopAthlete>("TopAthlete")
                .RegisterType<IGameRule, Munchies>("Munchies")
                .RegisterType<IGameRule, Boredom>("Boredom")
                .RegisterType<IGameRule, Crazy>("Crazy")
                .RegisterType<IGameRule, Fatique>("Fatigue")
                .RegisterType<IGameRule, FoodShortage>("FoodShortage", new InjectionProperty("TopAthlete", container.Resolve<TopAthlete>()))
                .RegisterType<IGameRule, Hunger>("Hunger", new InjectionProperty("Munchies", container.Resolve<Munchies>()))
                .RegisterType<IGameRule, Isolation>("Isolation")
                .RegisterType<IGameRule, SleepDeprivation>("SleepDeprivation", new InjectionProperty("TopAthlete", container.Resolve<TopAthlete>()));


        }
    }    
}