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
        private Item[] Items;
        private string FileName = "items.json";
        private void Start()
        {
            LoadGameData();
        }
        private void LoadGameData()
        {
            // Path.Combine combines strings into a file path
            // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
            string filePath = Path.Combine(Application.streamingAssetsPath, FileName);
            if (File.Exists(filePath))
            {
                            // Read the json from the file into a string
            string dataAsJson = File.ReadAllText(filePath); 
            // Pass the json to JsonUtility, and tell it to create a GameData object from it
            string newData = JsonHelper.AppendItems(dataAsJson);
            var loadedData = JsonHelper.FromJson<Item>(newData);

            // Retrieve the allRoundData property of loadedData
            print(loadedData.Length);
            foreach (var item in loadedData)
            {
                print(item.name);
            }
                // TextAsset jsonText = Resources.Load(filePath) as  TextAsset;
                // var jsonObj = JsonHelper.FromJson<Item[]>(jsonText.text);
                // // JsonHelper.FromJson<Item[]>(jsonObj);
                // print(jsonObj);
            }
            else
            {
                Debug.LogError("Cannot load game data!");
            }
        }
    }
}