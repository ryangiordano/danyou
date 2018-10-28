using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets.Utility;
using UnityEngine;

public class InventoryController : CustomMonoBehaviour
{
    private ItemRepository _ItemRepository;
    public Dictionary<int, int> ItemsInBag;
    public GameManager _GameManager;
    private static InventoryController inventoryController;
    public static InventoryController instance
    {
        get
        {
            if (!inventoryController)
            {
                inventoryController = FindObjectOfType(typeof(InventoryController)) as InventoryController;

                if (!inventoryController)
                {
                    Debug.LogError("There needs to be one active InventoryController script on a GameObject in your scene.");
                }
            }

            return inventoryController;
        }
    }
    private void Start()
    {
        ItemsInBag = new Dictionary<int, int>();
        DontDestroyOnLoad(gameObject);
        _ItemRepository = FindComponentByObjectTag<ItemRepository>("ItemRepository");
        _GameManager = FindComponentByObjectTag<GameManager>("GameController");
    }
    public void AddItem(int id)
    {
        if (ItemsInBag.ContainsKey(id))
        {
            ItemsInBag[id]++;
        }
        else
        {
            ItemsInBag[id] = 1;
        }
        EventManager.TriggerEvent("BagUpdated");
        print(ItemsInBag[id]);

    }
    public void UseItem(int id)
    {
        //We can improve on this to make it more generic or specific (ie: feedTamagotchiItem)
        if (ItemsInBag.ContainsKey(id) && ItemsInBag[id] > 0)
        {
            ItemsInBag[id]--;
            var item = _ItemRepository.GetFruitById(id);
            _GameManager.FeedTamagotchi(item);
            if (ItemsInBag[id] == 0)
            {
                ItemsInBag.Remove(id);
            }
            EventManager.TriggerEvent("BagUpdated");
        }
    }
}
