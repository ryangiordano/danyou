using System;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets.Utility;

namespace Tamagotchi.Assets._Prefabs.tree
{
    public class TreeModel : ITimeable
    {
        public DateTime LastTick { get; set; }
        public int Experience { get; set; }
        public bool IsWatered; 
        public int Stage;
        public FruitType FruitType;
        public TreeModel()
        {
            LastTick = DateTime.Now;
        }
        public void ProcessMoment()
        {

        }
    }
}