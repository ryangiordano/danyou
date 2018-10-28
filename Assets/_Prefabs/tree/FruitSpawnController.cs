using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawnController : MonoBehaviour
{
    public bool Occupied;
    // Use this for initialization
    void Start()
    {

    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            Occupied = true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.tag == "Food")
        {
            Occupied = false;
        }
    }
    public void SpawnFruit(GameObject fruit)
    {
        if (transform.childCount > 0)
        {
            return;
        }
        var instantiated = Instantiate(fruit);

        instantiated.transform.parent = transform;
        instantiated.transform.localScale = new Vector3(.5f, .5f, 0);
        instantiated.transform.localPosition = new Vector3(0, 0, 0);
        var rb = instantiated.GetComponent<Rigidbody2D>();
        rb.isKinematic = true;
    }
    // Update is called once per frame
    void Update()
    {

    }
}
