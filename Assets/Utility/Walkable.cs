using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walkable : MonoBehaviour
{
    private int Direction;
    private Rigidbody2D _Rigidbody;
    private SpriteRenderer _SpriteRenderer;
	public int Pace;
	public int Height;
	public int Distance;
	public List<string> MovementType;

    // Use this for initialization
    void Start()
    {

        StartCoroutine("PaceRoutine");
        Direction = -1;
        _Rigidbody = GetComponent<Rigidbody2D>();
        _SpriteRenderer = GetComponent<SpriteRenderer>();

    }

    // Update is called once per frame
    void Update()
    {

    }
    private IEnumerator PaceRoutine()
    {
        yield return new WaitForSeconds(Pace);
        var random = Random.Range(0, 4);
        if (random == 0)
        {
            ChangeDirection();
        }
        _Rigidbody.AddForce(new Vector2(Distance * Direction, Height));
        yield return PaceRoutine();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {

        }
        if (collision.gameObject.tag == "Wall")
        {
            ChangeDirection();
            _Rigidbody.AddForce(new Vector2(Distance * Direction, 40));
        }

    }
    private void ChangeDirection()
    {
        Direction = -Direction;
        _SpriteRenderer.flipX = Direction > 0 ? true : false;
    }
}
