using System;
using System.Collections.Generic;
using CastleGrimtol.Project;

namespace CastleGrimtol.Project
{
    public class Game
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
            Item key = new Item("Key", "There is a brass Key on the floor, used to unlock.....something!");
            Item rope = new Item("Rope", "You see a length of Rope in the corner, used to tie, or swing, or......");
            Item dagger = new Item("Dagger", "On the wall is mounted a small Dagger, used to stab, cut, or open MREs.");

            Items = new List<Item>();
            Items.Add(sword);
            Items.Add(key);
            Items.Add(rope);
            Items.Add(dagger);




            //create and add room(s)

            Room mapRoom = new Room("Map Room", "This is a room full of various maps; There is an Exit to the East.", null, null);
            Room armory = new Room("Armory", "Weapons storage and maintenance room; There is an Exit to the East, and an Exit to the West.", null, null);
            Room library = new Room("Library", "The Room Where the Scrolls are kept; There is an Exit to the East and and Exit to the West.", null, null);
            Room dungeon = new Room("Dungeon", "Prisoners are kept here; A strange, dangerous-looking creature is chained to the North wall; There is an exit to the West, and door with a padlock on your right side.", null, null);

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

            armory.Items.Add(rope);
            mapRoom.Items.Add(key);
            library.Items.Add(dagger);

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
                    Console.Clear();
                    Console.WriteLine("Please choose \"Go\" and a direction, \"Take\" and the item name, or \"Quit\" to exit the game(Typing \"Help\" will also display other options, as well).");
                    break;
            }

        }
        public void Go(string direction)
        {
            if (_currentRoom.Exits.ContainsKey(direction))
            {
                _currentRoom = _currentRoom.Exits[direction];
                Console.Clear();
                Look();
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
            Console.Clear();
            Console.WriteLine($"Inventory List:");

            foreach (var item in _currentPlayer.Inventory)
            {
                Console.WriteLine($"{item.Name}");
            }
        }

        public void Look()
        {
            Console.WriteLine($"You are now in the {_currentRoom.Name}.");
            Console.WriteLine(_currentRoom.Description);
            foreach (var item in _currentRoom.Items)
            {
                Console.WriteLine($"{item.Description}");
            }
            if (_currentRoom.Name == "Dungeon")
            {
                Console.Write("Do you wish to talk to the prisoner? (Y/N)");
                string answer = Console.ReadLine().ToLower();
                if (answer == "y")
                {
                    Console.Clear();
                    Console.WriteLine("The creature turns and rips off your face!!!......so sorry....you lose.");
                    playing = false;
                }
                else if (answer != "n")
                {
                    Console.WriteLine("Not a valid answer!");
                }
            }
        }

        public void Quit()
        {
            playing = false;
            Console.Clear();
            Console.WriteLine("See you next time!");
            return;
        }

        public void Reset()
        {   Console.Clear();
            Console.Write("Are you sure you want to Restart the Game? (Y/N)");
            string answer = Console.ReadLine().ToLower();
            if (answer == "y")
            {
                playing = false;
                Console.Clear();
                StartGame();
            }
            Console.Clear();
        }



        public void TakeItem(string itemName)
        {
            Item item = _currentRoom.Items.Find(i => i.Name.ToLower() == itemName);
            if (item != null)
            {
                Console.Clear();
                _currentPlayer.Inventory.Add(item);
                _currentRoom.Items.Remove(item);
                Console.WriteLine($"You have successfully added the {item.Name} to your Inventory!");
            }
            else
            {   Console.Clear();
                Console.WriteLine($"There is no {itemName} to take!");
            }
        }
        public void UseItem(string itemName)
        {
            Item item = _currentPlayer.Inventory.Find(i => i.Name.ToLower() == itemName);
            if (item != null)
            {
                var roomName = _currentRoom.Name;
                if ((roomName == "Dungeon") && (itemName == "key"))
                {
                    Console.Clear();
                    Console.WriteLine("You have successfully unlocked the door and escaped the dungeon! Great Job, Hero!");
                    Console.Write("Would you like to Play Again?(Y/N)");
                    var answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {
                        Console.Clear();
                        playing = false;
                        StartGame();
                    }
                    Quit();
                    return;
                }
                Console.Clear();
                Console.WriteLine($"You cannot use your {item.Name} in this room.");
            }
            else
            {
                Console.Clear();
                Console.WriteLine($"You don't have a {itemName} in your Inventory to use, knucklehead!");
            }
        }
    }
}