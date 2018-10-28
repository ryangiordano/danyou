using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.tree;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.Stage;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public List<GameObject> SpawnNodes;
    public int Stage;
    public void TriggerSpawn(GameObject FruitObject, int toSpawn)
    {
        var spawnCount = 0;
        foreach (var s in SpawnNodes)
        {
            if (spawnCount >= toSpawn)
            {
                return;
            }
            //The spawn point does not have a piece of fruit
            if (s.transform.childCount == 0)
            {
                s.GetComponent<FruitSpawnController>().SpawnFruit(FruitObject);
                spawnCount++;
            }
        }
    }
}
