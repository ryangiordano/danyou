using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.tree;
using Tamagotchi.Assets.Utility;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject Fruit;
    private TreeModel _Tree;
    public List<GameObject> SpawnNodes;
    private Timer _Timer;
    public int Stage;
    // Use this for initialization
    void Start()
    {
        _Tree = new TreeModel()
        {
            Stage = Stage
        };
        _Timer = new Timer(_Tree.LastTick);

    }

    // Update is called once per frame
    void Update()
    {
        _Timer.CheckForTick(() =>
        {
            if (Stage >= 2)
            {
                SpawnFruit();

            }
        });
    }
    public void SpawnFruit()
    {
        switch (Stage)
        {
            case 2:
                var randomNode = SpawnNodes[Random.Range(0, SpawnNodes.Count)];

                Instantiate(Fruit, randomNode.transform.position, randomNode.transform.rotation);
                break;
            case 3:
                var randomNode1 = SpawnNodes[Random.Range(0, SpawnNodes.Count)];
                var randomNode2 = SpawnNodes[Random.Range(0, SpawnNodes.Count)];

                Instantiate(Fruit, randomNode1.transform.position, randomNode1.transform.rotation);
                Instantiate(Fruit, randomNode2.transform.position, randomNode2.transform.rotation);
                break;
        }
    }
}
