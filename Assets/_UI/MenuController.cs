using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._UI;
using UnityEngine;
using UnityEngine.SceneManagement;
using Tamagotchi.Assets.Utility.ExtensionMethods;


public class MenuController : MonoBehaviour
{
    public List<GameObject> Menus;
    public List<GameObject> Buttons;

    // Use this for initialization
    public void ToggleMenu(int menuId)
    {
        Buttons.ForEach(b =>
        {
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
        Menus.ForEach(m => m.SetActive(m.activeSelf ? !m.activeSelf : m.GetComponent<ToggleMenu>().MenuId == menuId));
    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
}
