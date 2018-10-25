using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<GameObject> Menus;


    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ToggleMenu(int menuId)
    {
        Menus.ForEach(m => m.SetActive(m.GetComponent<ToggleMenu>().MenuId == menuId));
    }
}
