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
        public Sprite[] Sprites;
        private string PathToItems = "_Prefabs/items/Food/";
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
            LoadGameData();
            string filePath = Path.Combine(Application.dataPath, PathToItems + "fruitbody");
            Sprites = Resources.LoadAll<Sprite>("fruitbody");

        }
        public Item GetItemById(int id)
        {
            return Items.Find((i) => i.id == id);
        }
        public Sprite GetSpriteByName(string name)
        {
            return Array.Find(Sprites, (sprite) =>sprite.name == name);
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
                Items = JsonHelper.FromJson<Item>(newData);

            }
            else
            {
                Debug.LogError("Cannot load game data!");
            }
        }
    }
}