using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets.Utility;
using UnityEngine;

public class FruitController : MonoBehaviour
{

    public GameManager _GameManager;
    private Animator _Animator;
    private FlushBehavior _FlushBehavior;
    public bool Hanging = false;
    public bool Collected;
    private Timer _Timer;
    private DateTime LastTick = DateTime.Now;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _Animator.Play("popin");
        _FlushBehavior = _Animator.GetBehaviour<FlushBehavior>();
        _Timer = new Timer(LastTick);
        // _Animator.Play("idle");
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        StartCoroutine(_Timer.CheckForTick(()=>{
            print("Fruit");
        }));

        if (gameManagerObject != null)
        {
            _GameManager = gameManagerObject.GetComponent<GameManager>();
        }
        if (_GameManager == null)
        {
            Debug.Log("Game manager not found.");
        }
    }
    public void CollectFruit()
    {
        Collected = true;
        Destroy(gameObject);
    }
    private void OnMouseDown()
    {
        // _GameMananger.AddToBag();
        _GameManager.FeedTamagotchi();
        _Animator.SetTrigger("PoppedOut");
    }

    // Update is called once per frame
    void Update()
    {
        if (_FlushBehavior.Finished && !Collected)
        {
            CollectFruit();
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
    }
}
