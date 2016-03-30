using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TamagotchiWcfService.BusinessLogic
{
    public class Tamagotchi
    {
        public string Name { get; set; }

        private int _health;
        public int Health
        {

            get
            {
                return _health;
            }

            set
            {
                if (value < 0 || value > 100)
                {
                    _health = 100;
                    return;
                }

                _health = value;
            }
        }

        private int _hunger;

        public int Hunger
        {
            get { return _hunger; }

            set
            {
                if (value < 0 || value > 100)
                {
                    _hunger = 100;
                    return;
                }

                _hunger = value;
            }
        }

        private int _sleep;

        public int Sleep
        {
            get { return _sleep; }
            set
            {
                if (value < 0 || value > 100)
                {
                    _sleep = 100;
                    return;
                }

                _sleep = value;
            }
        }

        private int _boredom;

        public int Boredom
        {
            get { return _boredom; }
            set
            {
                if (value < 0 || value > 100)
                {
                    _boredom = 100;
                    return;
                }

                _boredom = value;
            }
        }

        public string Status {
            protected set { }
            get
            {
                string status = "HEALTH";
                if (_hunger > _health)
                    status = "HUNGER";
                if (_sleep > _hunger)
                    status = "SLEEP";
                if (_boredom > _sleep)
                    status = "BOREDOM";

                return status;
                
            }
        }

        public int Cooldown { get; set; }

        public bool IsAlive { get; set; }

        public DateTime LastAccess { get; set; }

        public DateTime LastAction { get; set; }

        public void StartAction(string actionName)
        {
            switch (actionName)
            {
                case "Eat":
                    Hunger = 0;
                    Cooldown = 30;
                    break;
                case "Sleep":
                    Sleep = 0;
                    Cooldown = 7200;
                    break;
                case "Play":
                    Boredom = (Boredom - 10 >= 0) ? Boredom -= 10 : 0;
                    Cooldown = 30;
                    break;
                case "Workout":
                    Health = (Health - 5 >= 0) ? Health -= 5 : 0;
                    Cooldown = 60;
                    break;
                case "Hug":
                    Health = (Health - 10 >= 0) ? Health -= 10 : 0;
                    Cooldown = 60;
                    break;
            }

            LastAction = DateTime.Now;
        }
    }
}