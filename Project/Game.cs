using System;
using System.Collections.Generic;
using CastleGrimtol.Project;

namespace CastleGrimtol.Project
{
    public class Game : IGame
    {
        public Room CurrentRoom { get; set; }
        public Player CurrentPlayer { get; set; }

        private List<Item> Items { get; set; }
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

            Item sword = new Item("Sword", "Keep it sharp, keep it true!");
            Item key = new Item("Key", "Used to unlock.....something!");
            Item rope = new Item("Rope", "Used to tie, or swing, or......");
            Item dagger = new Item("Dagger", "Used to stab, cut, or open MREs.");

            Items = new List<Item>();
            Items.Add(sword);
            Items.Add(key);
            Items.Add(rope);
            Items.Add(dagger);

            
            

            //create and add room(s)

            Room mapRoom = new Room("Map Room", "This is a room full of various maps; You see a length of Rope in the corner; There is an Exit to the East.", null, null);
            Room library = new Room("Library", "The Room Where the Scrolls are kept; On the wall is mounted a small Dagger; There is an Exit to the East and and Exit to the West.", null, null);
            Room dungeon = new Room("Dungeon", "Prisoners are kept here; A Strange creature is chained to the North wall; There is an exit to the West.", null, null);
            Room armory = new Room("Armory", "Weapons storage and maintenance room; There is a brass Key on the floor; There is an Exit to the East, and an Exit to the West.", null, null);
            
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

            mapRoom.Items.Add("rope", rope);
            armory.Items.Add("key", key);
            library.Items.Add("dagger", dagger);

            _currentRoom = mapRoom;

            playing = true;

            Console.Clear();
            Console.WriteLine("Welcome to the Game!");
            Console.Write("What is your name?: ");
            var name = Console.ReadLine();
            _currentPlayer = new Player(name, null);
            _currentPlayer.Inventory.Add(sword);
            Console.Clear();
            Console.WriteLine($"Welcome {name}!");
            Look();




        }

        public void GetUserInput()
        {

            Console.WriteLine("What do you want to do?");
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
                case "inventory":
                    Inventory();
                    break;
                case "use":
                    UseItem(userInput[1]);
                    break;
                case "help":
                    Help();
                    break;
                case "look":
                    Look();
                    break;
                case "restart":
                    Reset();
                    break;
                case "quit":
                    Quit();
                    break;

                default:
                    Console.WriteLine("Please choose \"Go\" and a direction, \"Take\" and the item name, or \"Quit\" to exit the game(Typing \"Help\" will also display other options, as well).");
                    break;
            }

        }
        // public void GetDescription()
        // {
        //     Console.WriteLine($"You are now in the {_currentRoom.Name}.");
        //     Console.WriteLine(_currentRoom.Description);
        // }

        public void Go(string direction)
        {
            if (_currentRoom.Exits.ContainsKey(direction))
            {
                _currentRoom = _currentRoom.Exits[direction];
                Console.Clear();
                Look();
                if(_currentRoom.Name == "Dungeon"){
                    Console.Write("Do you wish to talk to the prisoner? (Y/N)");
                    string answer = Console.ReadLine().ToLower();
                    if(answer == "y"){
                        Console.Clear();
                        Console.WriteLine("The creature turns and rips off your face!!!......so sorry....you lose.");
                        playing = false;
                    }
                }
            }

        }

        public void Help()
        {
            Console.Clear();
            Console.WriteLine(@"Options:

    Go + direction: Takes you to the room in that direction (if any)

    Inventory: displays the items you are currently carrying

    Take + item name: Allows you to add the item to your Inventory

    Use + item name: Allows you to use the item when the option is presented

    Look: gives you the room description, including any exits and important items/features

    Restart Game: Restarts the game(duh....)

    Quit: Terminates the game, displays the Command Prompt    
    ");

        }

        public void Inventory()
        {
            foreach (var Item in _currentPlayer.Inventory)
            {
            //I know this doesn't display the Inventory Items correctly - hung up on the Item's name/description
            Console.WriteLine($"Inventory List: {_currentPlayer.Inventory}");
                
            }

        }

        public void Look()
        {
            Console.WriteLine($"You are now in the {_currentRoom.Name}.");
            Console.WriteLine(_currentRoom.Description);
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
            Console.Write("Are you sure you want to Restart the Game? (Y/N)");
            string answer  = Console.ReadLine().ToLower();
            if(answer == "y"){
            playing = false;
            StartGame();
            }
        }



        public void TakeItem(string itemName)
        {
            if(_currentRoom.Items.ContainsKey(itemName)){
            Item takeItem = _currentRoom.Items[itemName];
            _currentPlayer.Inventory.Add(takeItem);
            Console.WriteLine(_currentPlayer.Inventory);
            Console.WriteLine($"The {itemName} has been added to your inventory.");
            }
        }

        public void UseItem(string itemName)
        {

        }
    }
}