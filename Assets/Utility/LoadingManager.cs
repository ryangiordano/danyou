using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingManager : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {
        EventManager.StartListening("GameLoaded", () =>
        {
            SceneManager.LoadScene(1);

        });
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeScene()
    {

    }
}
