using MovieDbApp.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Threading.Channels;
using F12XA6_HFT_2022231.Models;

namespace F12XA5_HFT_2022231.Client
{
    public class Program
    {
        static RestService rest;
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
                DevStudio one = rest.Get<DevStudio>(id, "Game");
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
        static void Main(string[] args)
        {
            
        }
    }
}
