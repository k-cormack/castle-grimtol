using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
    public class Room : IRoom
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public Dictionary<string, Item> Items { get; set; }
        public Dictionary<string, Room> Exits { get; set; }

        public Room(string name, string description, Dictionary<string, Item> items, Dictionary<string, Room> exits)
        {
            Name = name;
            Description = description;
            Items = new Dictionary<string, Item>();
            Exits = new Dictionary<string, Room>();
        }

        
    }
}