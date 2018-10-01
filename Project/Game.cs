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
            while (playing)
            {
                GetUserInput();

            }

        }
        public void Setup()
        {

            //create and add item(s)

            Item key = new Item("Key", "Used to unlock.....something!");
            Item rope = new Item("Rope", "Used to tie, or swing, or......");
            Item dagger = new Item("Dagger", "Used to stab, cut, or open MREs.");

            //create and add room(s)

            Room mapRoom = new Room("Map Room", "This is a room full of various maps; there is an Exit to the East.", null, null);
            Room library = new Room("Library", "The Room Where the Scrolls are kept; There is an Exit to the East and and Exit to the West.", null, null);
            Room dungeon = new Room("Dungeon", "Prisoners are kept here; the is an exit to the West.", null, null);
            Room armory = new Room("Armory", "Weapons storage and maintenance room; there is an Exit to the East, and an Exit to the West.", null, null);



            Rooms = new List<Room>();
            Rooms.Add(mapRoom);
            Rooms.Add(library);
            Rooms.Add(dungeon);
            Rooms.Add(armory);


            mapRoom.Exits.Add("east", armory);
            armory.Exits.Add("west", mapRoom);
            armory.Exits.Add("east", library);
            library.Exits.Add("west", armory);
            library.Exits.Add("east", dungeon);
            dungeon.Exits.Add("west", library);

            mapRoom.Items.Add(rope);
            armory.Items.Add(key);
            library.Items.Add(dagger);

            _currentRoom = mapRoom;

            playing = true;

            Console.Clear();
            Console.WriteLine("Welcome to the Game!");
            Console.Write("What is your name?: ");
            var name = Console.ReadLine();
            _currentPlayer = new Player(name, null);
            Console.Clear();
            Console.WriteLine($"Welcome {name}!");
            GetDescription();
           



        }

        public void GetUserInput()
        {
            
            Console.WriteLine("Which direction will you Go?");
            string input = Console.ReadLine().ToLower();
            string[] userInput;
            userInput = input.Split(' ');
            switch (userInput[0])
            {
                case "go":
                    Go(userInput[1]);
                    break;
                case "take":
                    TakeItem(userInput[1]);
                    break;    
                case "quit":
                    Quit();
                    break;
                default:
                    Console.WriteLine("Please choose a direction, or type \"quit\" to exit the game.");
                    break;
            }

        }
        public void GetDescription()
        {
            Console.WriteLine($"You are now in the {_currentRoom.Name}.");
            Console.WriteLine(_currentRoom.Description);
        }

        public void Go(string direction)
        {
            if (_currentRoom.Exits.ContainsKey(direction))
            {
                _currentRoom = _currentRoom.Exits[direction];
                Console.Clear();
                GetDescription();
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
            Console.Clear();
            Console.WriteLine("See you next time!");
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