using ConsoleApplication.TamagotchiService;
using System;
using System.Linq;

namespace ConsoleApplication
{
    class Program
    {
        public static string[] Actions = { "Eat", "Sleep", "Play", "Workout", "Hug" };
       public static TamagotchiServiceClient service = new TamagotchiServiceClient();

        static void PrintInstructions()
        {

            Console.WriteLine("/list \t\t\t List all Tamagotchies");
            Console.WriteLine("/select \t\t Select Tamagotchi");
            Console.WriteLine("Actions \n\tEat\n\tSleep\n\tPlay\n\tWorkout\n\tHug ");

        }

        static void Main(string[] args) {

            Console.WriteLine("#####################################################################");
            Console.WriteLine("# Tamagotchi console app by Tobias Maipauw studentnr 2088873");
            Console.WriteLine("#####################################################################");

            PrintInstructions();

            TamagotchiContract selectedTamagotchi = null;
            
            while(true){

                if (selectedTamagotchi != null)
                    Console.WriteLine(String.Format("Execute actions on {0}", selectedTamagotchi.Name));

                Console.Write(">");
                string command = Console.ReadLine();

                if (command.Equals("/list"))
                {
                    TamagotchiContract[] list = service.GetTamagotchies();

                    foreach (TamagotchiContract t in list)
                    {
                        Console.WriteLine(String.Format("Naam: {0}", t.Name));
                    }
                }
                else if (command.Equals("/select"))
                {
                    Console.Write("Type tamagotchi name: ");
                    string name = Console.ReadLine();
                    selectedTamagotchi = service.GetTamagotchiByName(name);
                }
                else if (Actions.Contains(command) && selectedTamagotchi != null)
                {
                    service.ExecuteAction(
                        new ActionContract() {
                            Name = selectedTamagotchi.Name,
                            Action = command
                        });
                }
                else
                {
                    PrintInstructions();
                }

            }
        }

    }
}
