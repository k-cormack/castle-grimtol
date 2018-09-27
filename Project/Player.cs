using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
    public class Player : IPlayer
    {
        public string PlayerName { get; set; }
        public List<Item> Inventory { get; set; }

        public Player(string name, List<Item> inventory)
        {
            PlayerName = name;
            Inventory = inventory;

        }

        public void CreatePlayer()
        {
            
        }
    }
}