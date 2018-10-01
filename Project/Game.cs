using System;
using System.Collections.Generic;
using CastleGrimtol.Project;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        private List<Room> Rooms { get; set; }

        bool playing = false;

        Room _currentRoom;
        Player _currentPlayer;

        public void StartGame()
        {
            Setup();

        }
        public void Setup()
        {

            //create and add item(s)

            Item key = new Item("Key", "Used to unlock.....something!");
            Item rope = new Item("Rope", "Used to tie, or swing, or......");
            Item dagger = new Item("Dagger", "Used to stab, cut, or open MREs.");

            //create and add room(s)

            Room mapRoom = new Room("Map Room", "A room full of various maps", null, null);
            Room library = new Room("Library", "Where the Scrolls are kept.", null, null);
            Room dungeon = new Room("Dungeon", "Prisoners are kept here", null, null);
            Room armory = new Room("Armory", "Weapons storage and maintenance", null, null);

            _currentRoom = mapRoom;


            Rooms = new List<Room>();
            Rooms.Add(mapRoom);
            Rooms.Add(library);
            Rooms.Add(dungeon);
            Rooms.Add(armory);


            mapRoom.Exits.Add("East", armory);
            armory.Exits.Add("West", mapRoom);
            armory.Exits.Add("East", library);
            library.Exits.Add("West", armory);
            armory.Exits.Add("East", dungeon);
            dungeon.Exits.Add("West", armory);

            playing = true;

            Console.Clear();
            Console.WriteLine("Welcome to the Game!");
            Console.Write("What is your name?: ");
            var name = Console.ReadLine();
            _currentPlayer = new Player(name, null);



        }

        public void GetUserInput()
        {
            _currentRoom.GetDescription();
            Console.WriteLine("Which direction will yo Go?");
            string input = Console.ReadLine();
            input = input.ToLower();
            switch (input)
            {
                case "east":
                    Go(input);
                    break;
                case "west":
                    Go(input);
                    break;
                case "quit":
                    Quit();
                    break;
                default:
                    Console.WriteLine("Please choose a direction, or type \"quit\" to exit the game.");
                    break;
            }

        }

        public void Go(string direction)
        {
            if(direction == "east") {

            }
        }

        public void Help()
        {

        }

        public void Inventory()
        {

        }

        public void Look()
        {


        }

        public void Quit()
        {
            playing = false;
            return;
        }

        public void Reset()
        {
            StartGame();
        }



        public void TakeItem(string itemName)
        {

        }

        public void UseItem(string itemName)
        {

        }
    }
}