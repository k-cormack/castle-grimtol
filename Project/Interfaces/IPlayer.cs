using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
  public interface IPlayer
  {
    string PlayerName { get; set; }
    List<Item> Inventory { get; set; }

    // void CreatePlayer();
  }
}