using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs;
using Tamagotchi.Assets._Scripts;
using Tamagotchi.Assets.Utility;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TamagotchiController _TamagotchiController;
    public PlayerController Player;
    public Text SatisfactionText;
    public Text HungerText;
    public Text HappinessText;
    private DataManager _DataManager;
    // Use this for initialization
    void Start()
    {
        _DataManager = new DataManager();
        _TamagotchiController = _TamagotchiController.GetComponent<TamagotchiController>();
        Physics2D.IgnoreLayerCollision(8, 9);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void PetTamagotchi()
    {
        _TamagotchiController.Pet();
        UpdateValues();
    }
    public void UpdateValues()
    {
        HappinessText.text = _TamagotchiController._Tamagotchi.CurrentHappiness.ToString();
        HungerText.text = _TamagotchiController._Tamagotchi.CurrentHunger.ToString();
        SatisfactionText.text = _TamagotchiController._Tamagotchi.Satisfaction.ToString();

    }
    public void FeedTamagotchi()
    {
        _TamagotchiController.Feed();
        UpdateValues();
    }
}
