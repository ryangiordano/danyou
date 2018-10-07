using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.tree;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.Stage;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject Fruit;
    public List<GameObject> SpawnNodes;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    public void FruitSpawnSmall(List<GameObject> vacantNodes, int toSpawn)
    {
        for (int i = 0; i < toSpawn; i++)
        {
            if (vacantNodes.Count >= 1)
            {
                var randIdx = Random.Range(0, vacantNodes.Count);
                var randomNode = vacantNodes[randIdx];
                var instantiated = Instantiate(Fruit, randomNode.transform.position, randomNode.transform.rotation);
                instantiated.transform.localScale = new Vector3(.5f, .5f, 0);
                var rb = instantiated.GetComponent<Rigidbody2D>();
                rb.isKinematic = true;
                vacantNodes.RemoveAt(randIdx);
            }
        }


    }

}
