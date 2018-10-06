using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitController : MonoBehaviour
{

    public GameManager _GameManager;
    public bool Hanging = false;
    // Use this for initialization
    void Start()
    {
        GameObject gameManagerObject = GameObject.FindWithTag("GameController");
        
        if (gameManagerObject != null)
        {
            _GameManager = gameManagerObject.GetComponent<GameManager>();
        }
        if (_GameManager == null)
        {
            Debug.Log("Game manager not found.");
        }
    }
    private void OnMouseDown()
    {
        // _GameMananger.AddToBag();
        _GameManager.FeedTamagotchi();
        Destroy(gameObject);

    }

    // Update is called once per frame
    void Update()
    {

    }
}
