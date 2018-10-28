using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
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
    public GameObject FruitObject;
    public GameObject FruitClone;
    public float ProgressionCurve;
    public DateTime LastTick { get; set; }
    public int Experience { get; set; }
    public bool IsWatered { get; set; }
    public GameManager _GameManager;
    public int FruitId;
    public List<Point> History { get; set; }
    private ProgressManager _ProgressManager { get; set; }

    // Use this for initialization
    void Start()
    {
        //Set the type of fruit that this tree will bear
        var clone = Instantiate(FruitObject, ItemRepository.instance.gameObject.transform);
        FruitClone = Fruit.Create(FruitId, clone);


        LastTick = DateTime.Now;
        _GameManager = FindComponentByObjectTag<GameManager>("GameController");

        _ProgressManager = new ProgressManager(NumStages, ProgressionCurve);
        if (CurrentStage > 1)
        {
            CurrentExp = _ProgressManager.GetNodeAtStage(CurrentStage - 1).ExpToNext;
        }
        EventManager.StartListening("Tick", ProcessMoment);

        SetActiveStage();
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void SetActiveStage()
    {
        var currentStage = CurrentStage;
        var activeTree = Trees[currentStage - 1];
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }

        var tree = Instantiate(activeTree, transform, true);
        tree.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, 0, 0);

    }
    public void SpawnFruit()
    {
        transform.GetChild(0).GetComponent<TreeController>().TriggerSpawn(FruitClone, 2);
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
        SpawnFruit();
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
        SetActiveStage();
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
