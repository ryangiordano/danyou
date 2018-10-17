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
        public int untilRipe;
        public string sprite;
        public string flavor;
    }
}