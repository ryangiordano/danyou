using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.ExtensionMethods;
using UnityEngine;

public class PoopController : MonoBehaviour
{

    private Animator _Animator;
    private FlushBehavior _FlushBehavior;
    public GameManager _GameManager;
    public bool Flushed;
    // Use this for initialization
    void Start()
    {
        _Animator = GetComponent<Animator>();
        _FlushBehavior = _Animator.GetBehaviour<FlushBehavior>();
        _GameManager = GameManager.Instance.GetComponent<GameManager>();;
    }
    private void OnMouseDown()
    {
        _Animator.SetTrigger("Flushed");
    }
    public void FlushPoop()
    {
        Flushed = true;
        Destroy(gameObject);
    }
    // Update is called once per frame
    void Update()
    {
        if (_FlushBehavior.Finished && !Flushed)
        {
            FlushPoop();
        }
    }
}
