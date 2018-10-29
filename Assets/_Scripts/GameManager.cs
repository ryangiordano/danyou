using System;
using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets._Prefabs.items.Bag;
using Tamagotchi.Assets._Scripts;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.ExtensionMethods;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : PersistentGameObjectSingleton<GameManager>
{
    public TamagotchiController _TamagotchiController;
    public Timer _Timer;
    public InventoryController _InventoryController;
    public EventManager _EventManager;
    // Use this for initialization
    void Start()
    {
        SceneManager.sceneLoaded += OnSceneLoad;
        _Timer = GetComponent<Timer>();
        _EventManager = GetComponent<EventManager>();
        _InventoryController = this.FindComponentByObjectTag<InventoryController>("Inventory");
        _TamagotchiController = this.FindComponentByObjectTag<TamagotchiController>("Danyou");
        Physics2D.IgnoreLayerCollision(8, 9);

    }
    void OnSceneLoad(Scene scene, LoadSceneMode sceneMode)
    {
        if(scene.name == "Main"){
        _TamagotchiController = this.FindComponentByObjectTag<TamagotchiController>("Danyou");

        }
    }
    protected override void OnAwake()
    {

    }
    public void LoadScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }
    public void FeedTamagotchi(Item item)
    {
        _TamagotchiController.Feed(item);
    }
    public void AddToBag(int id)
    {
        _InventoryController.AddItem(id);
    }

}
