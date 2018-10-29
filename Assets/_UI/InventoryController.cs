using System.Collections;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.ExtensionMethods;
using UnityEngine;

public class InventoryController : PersistentGameObjectSingleton<InventoryController>
{
    private ItemRepository _ItemRepository;
    public Dictionary<int, int> ItemsInBag;
    public GameManager _GameManager;
    private void Start()
    {
        ItemsInBag = new Dictionary<int, int>();
        _ItemRepository = this.FindComponentByObjectTag<ItemRepository>("ItemRepository");
        _GameManager = GameManager.Instance.GetComponent<GameManager>();;
    }
    protected override void OnAwake(){
        
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
