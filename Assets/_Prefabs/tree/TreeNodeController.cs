using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.tree;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.Stage;
using UnityEngine;

public class TreeNodeController : CustomMonoBehaviour
{
    public List<GameObject> Trees;
    private TreeModel _Tree;
    public int CurrentExp;

    public int CurrentStage;
    public int NumStages;
    public GameObject Fruit;
    public float ProgressionCurve;
    public DateTime LastTick { get; set; }
    public int Experience { get; set; }
    public bool IsWatered { get; set; }
    public GameManager _GameManager;
    public List<Point> History { get; set; }
    private ProgressManager _ProgressManager { get; set; }

    // Use this for initialization
    void Start()
    {
        LastTick = DateTime.Now;
        _GameManager = FindComponentByObjectTag<GameManager>("GameController");

        _ProgressManager = new ProgressManager(NumStages, 10);
        if (CurrentStage > 1)
        {
            CurrentExp = _ProgressManager.GetNodeAtStage(CurrentStage - 1).ExpToNext;
        }
        EventManager.StartListening("Tick", () =>
        {
            ProcessMoment();
            SetActiveStage();
            SpawnFruit();
        });

        SetActiveStage();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetActiveStage()
    {
        Trees.ForEach((tree) =>
        {
            var controller = tree.GetComponent<TreeController>();
            if (controller.Stage == CurrentStage)
            {
                tree.SetActive(true);
            }
            else
            {
                tree.SetActive(false);
            }

        });

    }
    public void SpawnFruit()
    {

        switch (CurrentStage)
        {
            case 3:
                var VacantNodes3 = Trees.Find((tree) => tree.GetComponent<TreeController>().Stage == 3)
                    .GetComponent<TreeController>()
                    .SpawnNodes
                    .FindAll((s) => !s.GetComponent<FruitSpawnController>().Occupied);

                FruitSpawnSmall(VacantNodes3, 1);
                break;
            case 4:
                var VacantNodes4 = Trees.Find((tree) => tree.GetComponent<TreeController>().Stage == 4)
                    .GetComponent<TreeController>()
                    .SpawnNodes
                    .FindAll((s) => !s.GetComponent<FruitSpawnController>().Occupied);

                FruitSpawnSmall(VacantNodes4, 2);
                break;
        }
    }
    private void FruitSpawnSmall(List<GameObject> vacantNodes, int toSpawn)
    {
        for (int i = 0; i < toSpawn; i++)
        {
            if (vacantNodes.Count >= 1)
            {
                var randIdx = UnityEngine.Random.Range(0, vacantNodes.Count);
                var randomNode = vacantNodes[randIdx];
                var instantiated = Instantiate(Fruit, randomNode.transform.position, randomNode.transform.rotation);
                instantiated.transform.localScale = new Vector3(.5f, .5f, 0);
                var rb = instantiated.GetComponent<Rigidbody2D>();
                rb.isKinematic = true;
                vacantNodes.RemoveAt(randIdx);
            }
        }


    }
    public void ProcessMoment()
    {
        var toAdd = IsWatered ? 2 : 1;
        CurrentExp += toAdd;
        if (CurrentStage != NumStages)
        {
            var currentStage = _ProgressManager.GetNodeAtStage(CurrentStage);
            if (CurrentExp >= currentStage.ExpToNext)
            {
                LevelUp();
            }
        }

        IsWatered = false;
    }
    public void RecordHistory()
    {
        var point = new Point
        {
            IsWatered = IsWatered,
        };
        if (History.Count >= 10)
        {
            History.RemoveAt(0);
        }
        History.Add(point);
    }

    public void LevelUp()
    {
        CurrentExp = _ProgressManager.GetNodeAtStage(CurrentStage).ExpToNext;
        CurrentStage = CurrentStage + 1 > NumStages ? CurrentStage : CurrentStage + 1;
    }

    public void WaterTree()
    {
        IsWatered = true;
    }
}

public class Point
{
    public bool IsWatered { get; set; }
    public Point()
    {

    }
}
