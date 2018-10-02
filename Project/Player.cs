using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
    public class Player
    {
        public string PlayerName { get; set; }
        public List<Item> Inventory = new List<Item>();

        public Player(string name, Dictionary<string, Item> inventory)
        {
            PlayerName = name;
        }

        // public void CreatePlayer()
        // {
            
        // }
    }
}