using System;
using System.Collections.Generic;
using System.Numerics;
using ConsoleTools;
using davidgyongyosi_ADT_2022231.Models;

namespace davidgyongyosi_ADT_2022231.Client
{
    class Program
    {
        static RestService rest;

        static void Create(string entity)
        {
            switch (entity)
            {
                case "Game":
                    Console.WriteLine("Enter Game Name:");
                    string gamename = Console.ReadLine();
                    rest.Post(new Game() { GameName = gamename }, "Game");
                    break;
                case "Genre":
                    Console.WriteLine("Enter Genre Name:");
                    string genrename = Console.ReadLine();
                    rest.Post(new Genre() { GenreName = genrename }, "Genre");
                    break;
                case "Platform":
                    Console.WriteLine("Enter Platform Name:");
                    string platformname = Console.ReadLine();
                    rest.Post(new Platform() { PlatformName = platformname }, "Platform");
                    break;
            }
        }

        static void List(string entity)
        {
            switch (entity)
            {
                case "Game":
                    List<Game> games = rest.Get<Game>("Game");
                    foreach (var item in games)
                    {
                        Console.WriteLine(item.Id + ": " + "\t" + item.GameName);
                    }
                    break;
                case "Genre":
                    List<Genre> genres = rest.Get<Genre>("Genre");
                    foreach (var item in genres)
                    {
                        Console.WriteLine(item.Id + ": " + "\t" + item.GenreName);
                    }
                    break;
                case "Platform":
                    List<Platform> platforms = rest.Get<Platform>("Platform");
                    foreach (var item in platforms)
                    {
                        Console.WriteLine(item.Id + ": " + "\t" + item.PlatformName);
                    }
                    break;
            }
            Console.ReadLine();
        }

        static void Delete(string entity)
        {
            switch (entity)
            {
                case "Game":
                    Console.Write("Enter Game's id to delete: ");
                    int gameid = int.Parse(Console.ReadLine());
                    rest.Delete(gameid, "game");
                    break;
                case "Genre":
                    Console.Write("Enter Genre's id to delete: ");
                    int genreid = int.Parse(Console.ReadLine());
                    rest.Delete(genreid, "genre");
                    break;
                case "Platform":
                    Console.Write("Enter Platform's id to delete: ");
                    int platformid = int.Parse(Console.ReadLine());
                    rest.Delete(platformid, "platform");
                    break;
            }
        }

        static void Read(string entity)
        {
            switch (entity)
            {
                case "Game":
                    Console.Write("Enter Game's id to find: ");
                    int gameid = int.Parse(Console.ReadLine());
                    Game game = rest.Get<Game>(gameid, "game");
                    Console.Write($"Found it! [{game.GameName}]");
                    break;
                case "Genre":
                    Console.Write("Enter Genre's id to find: ");
                    int genreid = int.Parse(Console.ReadLine());
                    Genre genre = rest.Get<Genre>(genreid, "genre");
                    Console.Write($"Found it! [{genre.GenreName}]");
                    break;
                case "Platform":
                    Console.Write("Enter Platform's id to update: ");
                    int platformid = int.Parse(Console.ReadLine());
                    Platform platform = rest.Get<Platform>(platformid, "platform");
                    Console.Write($"Found it! [{platform.PlatformName}]");
                    break;
            }
        }

        static void Update(string entity)
        {
            switch (entity)
            {
                case "Game":
                    Console.Write("Enter Game's id to update: ");
                    int gameid = int.Parse(Console.ReadLine());
                    Game game = rest.Get<Game>(gameid, "game");
                    Console.Write($"New name [old: {game.GameName}]: ");
                    string gamename = Console.ReadLine();
                    game.GameName= gamename;
                    rest.Put(game, "game");
                    break;
                case "Genre":
                    Console.Write("Enter Genre's id to update: ");
                    int genreid = int.Parse(Console.ReadLine());
                    Genre genre = rest.Get<Genre>(genreid, "genre");
                    Console.Write($"New name [old: {genre.GenreName}]: ");
                    string genrename = Console.ReadLine();
                    genre.GenreName = genrename;
                    rest.Put(genre, "genre");
                    break;
                case "Platform":
                    Console.Write("Enter Platform's id to update: ");
                    int platformid = int.Parse(Console.ReadLine());
                    Platform platform = rest.Get<Platform>(platformid, "platform");
                    Console.Write($"New name [old: {platform.PlatformName}]: ");
                    string platformname = Console.ReadLine();
                    platform.PlatformName = platformname;
                    rest.Put(platform, "platform");
                    break;
            }
        }

        static void Main(string[] args)
        {
            rest = new RestService("http://localhost:5000/", "Game");

            var gameSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Game"))
                .Add("Find", () => Read("Game"))
                .Add("Create", () => Create("Game"))
                .Add("Delete", () => Delete("Game"))
                .Add("Update", () => Update("Game"))
                .Add("Back", ConsoleMenu.Close);

            var genreSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Genre"))
                .Add("Find", () => Read("Genre"))
                .Add("Create", () => Create("Genre"))
                .Add("Delete", () => Delete("Genre"))
                .Add("Update", () => Update("Genre"))
                .Add("Back", ConsoleMenu.Close);
            var platSubMenu = new ConsoleMenu(args, level: 1)
                .Add("List", () => List("Platform"))
                .Add("Find", () => Read("Platform"))
                .Add("Create", () => Create("Platform"))
                .Add("Delete", () => Delete("Platform"))
                .Add("Update", () => Update("Platform"))
                .Add("Back", ConsoleMenu.Close);


            var menu = new ConsoleMenu(args, level: 0)
                .Add("Games", () => gameSubMenu.Show())
                .Add("Genres", () => genreSubMenu.Show())
                .Add("Platforms", () => platSubMenu.Show())
                .Add("Exit", ConsoleMenu.Close);

            menu.Show();

        }
    }
}

