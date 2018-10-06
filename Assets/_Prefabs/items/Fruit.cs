namespace Tamagotchi.Assets._Prefabs.items
{
    public enum FruitType
    {
        Apple = 0,
        Orange = 1,
        Banana = 2

    }
    public class Fruit : Item
    {
        public FruitType Type { get; set; }
        public Fruit()
        {
            
        }
    }
}