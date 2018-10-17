using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets._Prefabs.items.Bag;
using Tamagotchi.Assets._Scripts;
using Tamagotchi.Assets.Utility;
using UnityEngine;
using UnityEngine.UI;


public class GameManager : CustomMonoBehaviour
{
    public TamagotchiController _TamagotchiController;
    public PlayerController Player;
    public Text SatisfactionText;
    public Text HungerText;
    public Text HappinessText;
    private DataManager _DataManager;
    public Timer _Timer;
    public BagController _BagController;
    public EventManager _EventManager;
    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        _Timer = GetComponent<Timer>();
        _EventManager = GetComponent<EventManager>();
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
    public void FeedTamagotchi(Item item)
    {
        _TamagotchiController.Feed(item);
        UpdateValues();
    }
    public void AddToBag(int id){
        _BagController.AddItem(id);
    }
    public void ToggleBag()
    {
        EventManager.TriggerEvent("ToggleBag");
    }
}
