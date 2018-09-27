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

        public void StartGame()
        {
            Setup();
            Console.WriteLine("Welcome to the Game!");
            Console.Write("What is your name?: ");
            string playerName = Console.ReadLine();

        }
        public void Setup()
        {
            Rooms = new List<Room>();
            Room startingRoom = new Room("");
            Rooms.Add(startingRoom);
            startingRoom.Exits.Add("west", breakRoom)
        }

        public void GetUserInput()
        {
            
        }

        public void Go(string direction)
        {

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

        }

        public void Reset()
        {

        }



        public void TakeItem(string itemName)
        {

        }

        public void UseItem(string itemName)
        {

        }
    }
}