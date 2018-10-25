using System;

namespace Tamagotchi.Assets._Prefabs.items
{
    [Serializable]
    public class Item
    {
        public int id;
        public string name;
        public string description;
        public int potency;
        public string sprite;

    }
    [Serializable]
    public class Fruit: Item {
        public int untilRipe;
        public Flavor flavor;
        public FruitType fruitType;
    }
}