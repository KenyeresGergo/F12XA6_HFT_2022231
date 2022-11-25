using MovieDbApp.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Channels;
using F12XA6_HFT_2022231.Models;
using ConsoleTools;
using static F12XA6_HFT_2022231.Models.Developer;

namespace F12XA5_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;

        #region non CRUD methods

        static void EmployeeNamesByCompany()
        {
            var list1 = new List<DeveloperInfo>();
            list1 = rest.Get<DeveloperInfo>("DeveloperNonCRUD/EmployeeNamesByCompany");
            Console.WriteLine("FORMAT: DevName\n\tCompanyName");
            foreach (var VARIABLE in list1)
            {
                Console.WriteLine(VARIABLE.Developernames);
                Console.WriteLine(VARIABLE.CompanyName);
            }

            Console.ReadLine();
        }
        static void GamesCountByWorkplace()
        {
            var list1 = new List<DeveloperInfo>();
            list1 = rest.Get<DeveloperInfo>("DeveloperNonCRUD/GamesCountByWorkplace");
            Console.WriteLine("FORMAT: GameCount\n\tCompanyName");
            foreach (var VARIABLE in list1)
            {
                Console.WriteLine(VARIABLE.GameCount);
                Console.WriteLine(VARIABLE.CompanyName);
            }
            Console.ReadLine();
        }
        static void GamesOfASelectedStudio()
        {
            var list1 = new List<ICollection<Game>>();
            Console.WriteLine("Enter the name of the selected studio:");
            string name = Console.ReadLine();
            Console.WriteLine("Games:");
            if (name.Contains(" "))
            {
                var a = name.Split(" ");
                string final = "";
                foreach (var s in a)
                {
                    final = final + s + "%20";
                }

                final.Remove(final.Length - 3);
                try
                {
                    list1 = rest.Get<ICollection<Game>>("DevStudioNonCRUD/GamesOfASelectedStudio?studioname=" + final);
                    foreach (var VARIABLE in list1)
                    {
                        foreach (var var in VARIABLE)
                        {
                            Console.WriteLine(var.GameTitle);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                
                }

            }
            else
            {
                try
                {
                    list1 = rest.Get<ICollection<Game>>("DevStudioNonCRUD/GamesOfASelectedStudio?studioname=" + name);
                    foreach (var VARIABLE in list1)
                    {
                        foreach (var var in VARIABLE)
                        {
                            Console.WriteLine(var.GameTitle);
                        }
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                  
                }

            }

            Console.ReadLine();
        }


        static void GameCountByStudio()
        {
            var list1 = new List<Game.GameInfo>();
            list1 = rest.Get<Game.GameInfo>("GameNonCRUD/GameCountByStudio");
            Console.WriteLine("FORMAT: GameCount\n\tStudioName");
            foreach (var VARIABLE in list1)
            {
                Console.WriteLine(VARIABLE.GameCount);
                Console.WriteLine(VARIABLE.PublisherStudioName);
            }
            Console.ReadLine();
        }

        static void AvgRatingByStudio()
        {
            var list1 = new List<Game.GameInfo>();
            list1 = rest.Get<Game.GameInfo>("GameNonCRUD/AvgRatingByStudio");
            Console.WriteLine("FORMAT: AvgRating\n\tStudioName");
            foreach (var VARIABLE in list1)
            {
                Console.WriteLine(VARIABLE.AvgRating);
                Console.WriteLine(VARIABLE.PublisherStudioName);
            }
            Console.ReadLine();
        }

        #endregion


        #region CRUD methods
        static void Create(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game Name: ");
                string name = Console.ReadLine();
                rest.Post(new Game() { GameTitle = name }, "game");
            }
            else if (entity == "Developer")
            {
                Console.Write("Enter Developer Name: ");
                string name = Console.ReadLine();
                rest.Post(new Developer() { DevName = name }, "developer");
            }
            else if (entity == "DevStudio")
            {
                Console.Write("Enter DevStudio Name: ");
                string name = Console.ReadLine();
                rest.Post(new DevStudio() { StudioName = name }, "devstudio");
            }

        }
        static void List(string entity)
        {
            if (entity == "Game")
            {
                List<Game> Games = rest.Get<Game>("game");
                foreach (var item in Games)
                {
                    Console.WriteLine(item.Id + ": " + item.GameTitle);
                }
            }
            if (entity == "Developer")
            {
                List<Developer> devs = rest.Get<Developer>("developer");
                foreach (var item in devs)
                {
                    Console.WriteLine(item.Id + ": " + item.DevName);
                }
            }
            if (entity == "DevStudio")
            {
                List<DevStudio> studios = rest.Get<DevStudio>("devstudio");
                foreach (var item in studios)
                {
                    Console.WriteLine(item.Id + ": " + item.StudioName);
                }
            }
            Console.ReadLine();
        }
        static void Update(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Game one = rest.Get<Game>(id, "game");
                Console.Write($"New name [old: {one.GameTitle}]: ");
                string name = Console.ReadLine();
                one.GameTitle = name;
                rest.Put(one, "game");
            }
            if (entity == "Developer")
            {
                Console.Write("Enter Developer's id to update: ");
                int id = int.Parse(Console.ReadLine());
                Developer one = rest.Get<Developer>(id, "developer");
                Console.Write($"New name [old: {one.DevName}]: ");
                string name = Console.ReadLine();
                one.DevName = name;
                rest.Put(one, "developer");
            }
            if (entity == "Game")
            {
                Console.Write("Enter DevStudio's id to update: ");
                int id = int.Parse(Console.ReadLine());
                DevStudio one = rest.Get<DevStudio>(id, "game");
                Console.Write($"New name [old: {one.StudioName}]: ");
                string name = Console.ReadLine();
                one.StudioName = name;
                rest.Put(one, "devstudio");
            }
        }
        static void Delete(string entity)
        {
            if (entity == "Game")
            {
                Console.Write("Enter Game's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "game");
            }
            if (entity == "Developer")
            {
                Console.Write("Enter Developer's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "developer");
            }
            if (entity == "DevStudio")
            {
                Console.Write("Enter DevStudio's id to delete: ");
                int id = int.Parse(Console.ReadLine());
                rest.Delete(id, "devstudio");
            }
        }


        #endregion

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:47550/", "game");

            var GameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("GameCountByStudio", () => GameCountByStudio())
                .Add("AvgRatingByStudio", () => AvgRatingByStudio())
                .Add("Exit", ConsoleMenu.Close);

            var DeveloperSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Developer"))
                .Add("Create", () => Create("Developer"))
                .Add("Delete", () => Delete("Developer"))
                .Add("Update", () => Update("Developer"))
                .Add("GamesCountByWorkplace", () => GamesCountByWorkplace())
                .Add("EmployeeNamesByCompany", () => EmployeeNamesByCompany())
                .Add("Exit", ConsoleMenu.Close);

            var DevStudioSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("DevStudio"))
                .Add("Create", () => Create("DevStudio"))
                .Add("Delete", () => Delete("DevStudio"))
                .Add("Update", () => Update("DevStudio"))
                .Add("Update", () => Update("DevStudio"))
                .Add("GamesOfASelectedStudio", () => GamesOfASelectedStudio())
                .Add("Exit", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => GameSubMenu.Show())
                .Add("Developers", () => DeveloperSubMenu.Show())
                .Add("DevStudios", () => DevStudioSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();
        }
    }
}
