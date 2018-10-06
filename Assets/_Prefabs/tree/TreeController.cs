using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.tree;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.Stage;
using UnityEngine;

public class TreeController : MonoBehaviour
{
    public GameObject Fruit;
    private TreeModel _Tree;
    public List<GameObject> SpawnNodes;
    private Timer _Timer;
    public int CurrentStage;
    public int NumStages;
    public int CurrentExp;
    public float ProgressionCurve;
    // Use this for initialization
    void Start()
    {
        _Tree = new TreeModel(CurrentStage, CurrentExp, NumStages);
        _Timer = new Timer(_Tree.LastTick);

    }

    // Update is called once per frame
    void Update()
    {
        _Timer.CheckForTick(() =>
        {
            Debug.Log(_Tree.CurrentStage);
            SpawnFruit();
            _Tree.ProcessMoment();
        });
    }
    public void SpawnFruit()
    {
        var VacantNodes = SpawnNodes.FindAll((s) =>
        {
            return !s.GetComponent<FruitSpawnController>().Occupied;
        });
        switch (CurrentStage)
        {
            case 3:
                FruitSpawnSmall(VacantNodes, 1);
                break;
            case 4:
                FruitSpawnSmall(VacantNodes, 2);
                break;
        }
    }
    private void FruitSpawnSmall(List<GameObject> vacantNodes, int toSpawn)
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
    public void WaterTree()
    {
        _Tree.IsWatered = true;
    }
}
