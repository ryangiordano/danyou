using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.ExtensionMethods;
using UnityEngine;

public class FruitController : MonoBehaviour
{

    public Transform _Transform;
    public Rigidbody2D _Rigidbody;
    private Animator _Animator;
    public GameObject Body;
    public GameObject Face;
    public GameManager _GameManager;

    private FlushBehavior _FlushBehavior;
    public bool Hanging = false;
    public bool Collected;
    public int UntilRipe = 10;
    public int Ripeness = 0;
    public float Potency;
    public Flavor Flavor;
    public FruitType FruitType;

    private DateTime LastTick = DateTime.Now;
    public int Id;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Animator.Play("popin");
        _FlushBehavior = _Animator.GetBehaviour<FlushBehavior>();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Transform = GetComponent<Transform>();
        _Rigidbody.bodyType = RigidbodyType2D.Static;

        _GameManager = GameManager.Instance.GetComponent<GameManager>();
        EventManager.StartListening("Tick", () =>
         {
             Ripeness++;
            //  if (Ripeness == UntilRipe / 2)
            //  {
            //      _Transform.localScale = new Vector3(1.5f, 1.5f, 1);
            //  }
            //  if (Ripeness >= UntilRipe)
            //  {
            //      _Transform.localScale = new Vector3(1.5f, 1.5f, 1);
            //      //  _Rigidbody.bodyType = RigidbodyType2D.Dynamic;

            //  }
         });
    }
    public void CollectFruit()
    {
        Collected = true;
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        _GameManager.AddToBag(Id);
        _Animator.SetTrigger("PoppedOut");
    }
    void Update()
    {
        if (_FlushBehavior.Finished && !Collected)
        {
            CollectFruit();
        }
    }
}
