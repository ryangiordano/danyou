using System;
using System.Collections.Generic;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.ExtensionMethods;
using UnityEngine;
using UnityEngine.UI;

namespace Tamagotchi.Assets._Prefabs.items.Bag
{
    public class BagController : MonoBehaviour
    {
        // A bag should contain a reference to the player, the item repository, and the active character object in the scene.
        private ItemRepository _ItemRepository;

        public GameObject ItemChoice;
        public InventoryController _InventoryController;

        private void Start()
        {
            _InventoryController = this.FindComponentByObjectTag<InventoryController>("Inventory");
            _ItemRepository = this.FindComponentByObjectTag<ItemRepository>("ItemRepository");
            EventManager.StartListening("BagUpdated", UpdateBagContents);
            UpdateBagContents();

        }
        private void UpdateBagContents()
        {
            var itemWrapper = transform.Find("ItemWrapper");
            foreach (Transform child in itemWrapper)
            {
                Destroy(child.gameObject);
            }
            int i = 0;
            foreach (var item in _InventoryController.ItemsInBag)
            {
                var offset = (i * -35);
                var itemChoice = Instantiate(ItemChoice, itemWrapper.transform);
                itemChoice.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, offset, 0);

                var repoItem = _ItemRepository.GetFruitById(item.Key);
                var itemController = itemChoice.GetComponent<ItemChoice>();
                itemController.Name = repoItem.name;
                itemController.Id = repoItem.id;
                itemController.Count = item.Value;
                //TODO: Make this more generic than accesing the fruit 
                var itemSprite = _ItemRepository.GetSpriteByName(repoItem.sprite);
                itemController.ItemImage.GetComponent<Image>().sprite = itemSprite;
                itemController.UpdateValues();
                i++;
            }
        }
        public void UseItem(int id)
        {
            _InventoryController.UseItem(id);
            UpdateBagContents();
        }
    }
}