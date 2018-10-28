using System;
using UnityEngine;

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
    public class Fruit : Item
    {
        public int untilRipe;
        public Flavor flavor;
        public FruitType fruitType;
        public static GameObject Create(int id, GameObject fruit)
        {
            var fruitData = ItemRepository.instance.GetFruitById(id);
            var fruitSprite = ItemRepository.instance.GetSpriteByName(fruitData.sprite);
            var fruitController = fruit.GetComponent<FruitController>();
            fruitController.Id = fruitData.id;
            var sprite= fruit.transform.GetComponentInChildren<SpriteRenderer>();
            sprite.sprite = fruitSprite;
            return fruit;
        }
    }
}