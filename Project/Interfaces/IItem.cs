using System;
using System.Collections.Generic;
using CastleGrimtol.Project;


namespace CastleGrimtol.Project
{
  public interface IItem
  {
    string Name { get; set; }
    string Description { get; set; }

    // void CreateItem();
  }
}