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

        }
        private void LoadGameData()
        {
            // Path.Combine combines strings into a file path
            // Application.StreamingAssets points to Assets/StreamingAssets in the Editor, and the StreamingAssets folder in a build
            string filePath = Path.Combine(Application.streamingAssetsPath, FileName);
            if (File.Exists(filePath))
            {


            }
            else
            {
                Debug.LogError("Cannot load game data!");
            }
        }
    }
}