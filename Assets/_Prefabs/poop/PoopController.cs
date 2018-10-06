using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoopController : MonoBehaviour
{

    private Animator _Animator;
    private Walkable _Walkable;
	private FlushBehavior _FlushBehavior;
	public bool Flushed;
    // Use this for initialization
    void Start()
    {
        _Walkable = GetComponent<Walkable>();
        _Animator = GetComponent<Animator>();
        _FlushBehavior = _Animator.GetBehaviour<FlushBehavior>();
		
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
		if(_FlushBehavior.Finished && !Flushed){
			FlushPoop();
		}
    }
}
