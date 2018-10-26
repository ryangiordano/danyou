using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs;
using UnityEngine;
using UnityEngine.UI;

public class StatusMenuController : MonoBehaviour
{
    public TamagotchiController _TamagotchiController;
    public Text SatisfactionText;
    public Text HungerText;
    public Text HappinessText;
    // Use this for initialization
    void Start()
    {
        _TamagotchiController = _TamagotchiController.GetComponent<TamagotchiController>();
    }

    // Update is called once per frame
    void Update()
    {

	}
    public void UpdateValues()
    {
        HappinessText.text = _TamagotchiController._Tamagotchi.CurrentHappiness.ToString();
        HungerText.text = _TamagotchiController._Tamagotchi.CurrentHunger.ToString();
        SatisfactionText.text = _TamagotchiController._Tamagotchi.Satisfaction.ToString();

    }
}
