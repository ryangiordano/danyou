namespace Tamagotchi.Assets._Prefabs.items
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public void ChangeQuantityBy(int change)
        {
            if (change > 0 || (this.Quantity - change >= 0))
            {
                this.Quantity += change;
            }
        }
        public void IncreaseQuantity()
        {

        }
    }
}