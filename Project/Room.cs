using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public List<Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        

        
        public Room(string name, string description, List<Item> items, Dictionary<string, Room> exits)
        {
            Name = name;
            Description = description;
            Items = items;
            Exits = exits;
        }
    }
}