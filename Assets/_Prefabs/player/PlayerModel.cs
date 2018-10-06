using System.Collections.Generic;

namespace Tamagotchi.Assets._Prefabs.player
{
    public class PlayerModel
    {
        public string Name { get; set; }
        public int PlayerId { get; set; }
        public ICollection<int> TamagotchiIds { get; set; }
    }
}