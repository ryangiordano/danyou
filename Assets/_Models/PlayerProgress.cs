using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs;
using Tamagotchi.Assets._Prefabs.player;

namespace Tamagotchi.Assets._Models
{
    public class PlayerProgress
    {
        public ICollection<TamagotchiModel> Tamagotchis;
        public PlayerModel Player;
    }
}