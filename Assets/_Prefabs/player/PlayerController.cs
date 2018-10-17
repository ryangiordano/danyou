using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets._Prefabs;
using UnityEngine;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets._Prefabs.items.Bag;

public class PlayerController : CustomMonoBehaviour
{
    public int Currency { get; set; }
    private BagController _PlayerBag;
    private GameManager _GameManager;
    // public ICollection<Item> Items { get; set; }
    // public ICollection<TamagotchiCharacter> Tamagotchis { get; set; }
    // Use this for initialization
    void Start()
    {
        _GameManager = FindComponentByObjectTag<GameManager>("GameController");
        _PlayerBag = FindComponentByObjectTag<BagController>("BagController");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
