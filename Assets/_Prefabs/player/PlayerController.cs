using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets._Prefabs;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public int Currency { get; set; }
    // public ICollection<Item> Items { get; set; }
    // public ICollection<TamagotchiCharacter> Tamagotchis { get; set; }
    // Use this for initialization
    void Start()
    {
        print("Player has entered the game");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
