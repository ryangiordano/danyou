using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.tree;
using Tamagotchi.Assets.Utility;
using UnityEngine;

public class TreeNodeController : MonoBehaviour
{
    public GameObject Tree_1;
    public GameObject Tree_2;
    public GameObject Tree_3;
    public GameObject Tree_4;
    private TreeModel _Tree;
    public int CurrentExp;

    public int CurrentStage;
    public int NumStages;
    private Timer _Timer;
    public GameObject Fruit;
    public float ProgressionCurve;

    // Use this for initialization
    void Start()
    {

        _Tree = new TreeModel(CurrentStage, CurrentExp, NumStages);
        _Timer = new Timer(_Tree.LastTick);
		SetActiveStage();
    }

    // Update is called once per frame
    void Update()
    {
        _Timer.CheckForTick(() =>
        {
            Debug.Log(_Tree.CurrentStage);
            CurrentStage = _Tree.CurrentStage;
            SetActiveStage();
            SpawnFruit();
            _Tree.ProcessMoment();

        });
    }
    public void SetActiveStage()
    {
		// Todo improve this process.
        switch (CurrentStage)
        {
            case 1:
                Tree_1.SetActive(true);
                Tree_2.SetActive(false);
                Tree_3.SetActive(false);
                Tree_4.SetActive(false);
                break;
            case 2:
                Tree_1.SetActive(false);
                Tree_2.SetActive(true);
                Tree_3.SetActive(false);
                Tree_4.SetActive(false);
                break;
            case 3:
                Tree_1.SetActive(false);
                Tree_2.SetActive(false);
                Tree_3.SetActive(true);
                Tree_4.SetActive(false);
                break;
            case 4:
                Tree_1.SetActive(false);
                Tree_2.SetActive(false);
                Tree_3.SetActive(false);
                Tree_4.SetActive(true);
                break;
        }
    }
    public void SpawnFruit()
    {

        switch (CurrentStage)
        {
            case 3:
                var VacantNodes3 = Tree_3.GetComponent<TreeController>()
                    .SpawnNodes
                    .FindAll((s) => !s.GetComponent<FruitSpawnController>().Occupied);

                FruitSpawnSmall(VacantNodes3, 1);
                break;
            case 4:
                var VacantNodes4 = Tree_4.GetComponent<TreeController>()
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
