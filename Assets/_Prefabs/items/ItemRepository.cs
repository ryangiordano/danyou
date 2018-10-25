using System;
using System.Collections.Generic;
using System.IO;
using Tamagotchi.Assets.Utility;
using UnityEngine;

namespace Tamagotchi.Assets._Prefabs.items
{
    public class ItemRepository : CustomMonoBehaviour
    {
        public List<GameObject> ItemGameObjects;
        public List<Item> Items;
        public List<Fruit> Fruits;
        public Sprite[] Sprites;
        private static ItemRepository itemRepository;
        public static ItemRepository instance
        {
            get
            {
                if (!itemRepository)
                {
                    itemRepository = FindObjectOfType(typeof(ItemRepository)) as ItemRepository;

                    if (!itemRepository)
                    {
                        Debug.LogError("There needs to be one active ItemRepository script on a GameObject in your scene.");
                    }
                }

                return itemRepository;
            }
        }
        private string PathToItems = "_Prefabs/items/Food/";
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            LoadGameData();
            Sprites = Resources.LoadAll<Sprite>("fruitbody");
        }
        public Item GetItemById(int id)
        {
            return Items.Find((i) => i.id == id);
        }
        public Fruit GetFruitById(int id)
        {
            return Fruits.Find((i) => i.id == id);

        }
        public Fruit GetFruitByTypeFlavor(FruitType type, Flavor flavor)
        {
            return Fruits.Find(i => i.flavor == flavor && i.fruitType == type);
        }
        public Sprite GetSpriteByName(string name)
        {
            return Array.Find(Sprites, (sprite) => sprite.name == name);
        }
        private void LoadGameData()
        {
            // Path.Combine combines strings into a file path
            // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
            string filePath = Path.Combine(Application.streamingAssetsPath, "items.json");
            if (File.Exists(filePath))
            {
                string dataAsJson = File.ReadAllText(filePath);
                string newData = JsonHelper.AppendItems(dataAsJson);
                Fruits = JsonHelper.FromJson<Fruit>(newData);
                print(Fruits.Count);

            }
            else
            {
                Debug.LogError("Cannot load game data!");
            }
        }
    }
}