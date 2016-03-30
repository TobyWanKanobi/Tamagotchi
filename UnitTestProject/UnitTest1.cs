using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TamagotchiWcfService;
using Microsoft.Practices.Unity;
using TamagotchiWcfService.BusinessLogic.GameRules;
using TamagotchiWcfService.BusinessLogic;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {

        public UnityContainer container = new UnityContainer();

        public UnitTest1()
        {
            container.RegisterType<ITamagotchiService, TamagotchiService>()
                .RegisterType<IGameRule, TopAthlete>("TopAthlete")
                .RegisterType<IGameRule, Munchies>("Munchies")
                .RegisterType<IGameRule, Boredom>("Boredom")
                .RegisterType<IGameRule, Crazy>("Crazy")
                .RegisterType<IGameRule, Fatique>("Fatigue")
                .RegisterType<IGameRule, FoodShortage>("FoodShortage")
                .RegisterType<IGameRule, Hunger>("Hunger", new InjectionProperty("Munchies", container.Resolve<Munchies>()))
                .RegisterType<IGameRule, Isolation>("Isolation")           
                .RegisterType<IGameRule, SleepDeprivation>("SleepDeprivation", new InjectionProperty("TopAthlete", container.Resolve<TopAthlete>()));
        }

        [TestMethod]
        [TestCategory("GameRules")]
        public void HealthShouldIncreaseCorrect()
        {
            Tamagotchi t = new Tamagotchi()
            {
                Name = "Henk",
                Boredom = 0,
                Health = 0,
                Hunger = 0,
                Sleep = 0,
                Cooldown = 0,
                IsAlive = true,
                LastAccess = DateTime.Now.Subtract(TimeSpan.FromHours(5))
            };

            IGameRule isolation = container.Resolve<IGameRule>("Isolation");
           // isolation.ExecuteGameRule(t);

            Assert.AreEqual(25, t.Health, "Health should be 25 after 5 hours");
        }

        [TestMethod]
        [TestCategory("GameRules")]
        public void FatiqueShouldIncreaseCorrect()
        {
            Tamagotchi t = new Tamagotchi()
            {
                Name = "Henk",
                Boredom = 0,
                Health = 0,
                Hunger = 0,
                Sleep = 0,
                Cooldown = 0,
                IsAlive = true,
                LastAccess = DateTime.Now.Subtract(TimeSpan.FromHours(5))
            };

            IGameRule fatique = container.Resolve<IGameRule>("Fatigue");
          //  fatique.ExecuteGameRule(t);

            Assert.AreEqual(25, t.Sleep, "Sleep should be 25 after 5 hours");
        }


        [TestMethod]
        [TestCategory("GameRules")]
        public void BoredomShouldIncreaseCorrect()
        {
            Tamagotchi t = new Tamagotchi() {
                Name = "Henk",
                Boredom = 0,
                Health = 0,
                Hunger = 0,
                Sleep = 0,
                Cooldown = 0,
                IsAlive = true,
                LastAccess = DateTime.Now.Subtract(TimeSpan.FromHours(3))
            };

            IGameRule boredomRule = container.Resolve<IGameRule>("Boredom");
         //   boredomRule.ExecuteGameRule(t);
            Assert.AreEqual(45, t.Boredom, "Boredom should be 45 after 3 hours");
        }

        [TestMethod]
        [TestCategory("GameRules")]
        public void HungerShouldIncreaseCorrect()
        {
            Tamagotchi t = new Tamagotchi()
            {
                Name = "Henk",
                Boredom = 0,
                Health = 0,
                Hunger = 0,
                Sleep = 0,
                Cooldown = 0,
                IsAlive = true,
                LastAccess = DateTime.Now.Subtract(TimeSpan.FromHours(3))
            };
            IGameRule munchiesRule = container.Resolve<IGameRule>("Munchies");
            IGameRule hungerRule = container.Resolve<IGameRule>("Hunger");

           // hungerRule.ExecuteGameRule(t);

            Assert.AreEqual(15, t.Hunger, "Hunger should be 15");

            t.Boredom = 81;
           // hungerRule.ExecuteGameRule(t);

            Assert.AreEqual(45, t.Hunger, "Hunger should be 45 because of Munchies");
        }

        [TestMethod]
        [TestCategory("GameRules")]
        public void SleepDepritatanShouldKill()
        {
            Tamagotchi t = new Tamagotchi()
            {
                Name = "Henk",
                Boredom = 0,
                Health = 0,
                Hunger = 0,
                Sleep = 100,
                Cooldown = 0,
                IsAlive = true,
                LastAccess = DateTime.Now.Subtract(TimeSpan.FromHours(3))
            };

            IGameRule sd = container.Resolve<IGameRule>("SleepDeprivation");
           // sd.ExecuteGameRule(t);

            Assert.IsTrue(t.IsAlive, "Should be alive because of Top Athlete Rule");

            t.Health = 21;

           // sd.ExecuteGameRule(t);
            Assert.IsFalse(t.IsAlive, "Tamagotchi should be dead because of Sleep Deprivation");
        }
    }
}
