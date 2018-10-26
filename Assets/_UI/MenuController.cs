using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._UI;
using UnityEngine;

public class MenuController : MonoBehaviour
{
    public List<GameObject> Menus;
    public List<GameObject> Buttons;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ToggleMenu(int menuId)
    {
        Buttons.ForEach(b =>
        {
            print("Buttons");
            var toggleButton = b.GetComponent<ToggleButton>();
            if (toggleButton.Open)
            {
                toggleButton.CloseMenu();
            }
            else if (toggleButton.MenuId == menuId)
            {
                toggleButton.OpenMenu();
            }


        });
        Menus.ForEach(m => m.SetActive(m.active ? !m.active : m.GetComponent<ToggleMenu>().MenuId == menuId));
    }
}
