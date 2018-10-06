using System.IO;
using Tamagotchi.Assets._Models;
using UnityEngine;

namespace Tamagotchi.Assets._Scripts
{
    public class DataManager : MonoBehaviour
    {
        private string _GameDataFilename = "save.json";
        public PlayerProgress PlayerProgress { get; set; }
        private void Start()
        {
            DontDestroyOnLoad(gameObject);
        }
        private void LoadSaveData()
        {
            string filepath = Path.Combine(Application.streamingAssetsPath, _GameDataFilename);
            if (File.Exists(filepath))
            {
                string fileJson = File.ReadAllText(filepath);
                PlayerProgress loadedData = JsonUtility.FromJson<PlayerProgress>(fileJson);
                PlayerProgress = loadedData;
            }
            else
            {
                Debug.Log("Error: Cannot load data");
            }

        }

    }
}