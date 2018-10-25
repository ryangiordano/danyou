using System;
using System.Collections.Generic;
using Tamagotchi.Assets.Utility;
using UnityEngine;
using UnityEngine.UI;

namespace Tamagotchi.Assets._Prefabs.items.Bag
{
    public class BagController : CustomMonoBehaviour
    {
        // A bag should contain a reference to the player, the item repository, and the active character object in the scene.
        private ItemRepository _ItemRepository;
        public Dictionary<int, int> ItemsInBag;
        public GameManager _GameManager;
        public GameObject ItemChoice;
        public int MenuId;

        private void Start()
        {
            gameObject.SetActive(false);
            ItemsInBag = new Dictionary<int, int>();
            // DontDestroyOnLoad(gameObject);
            _ItemRepository = FindComponentByObjectTag<ItemRepository>("ItemRepository");
            _GameManager = FindComponentByObjectTag<GameManager>("GameController");

            EventManager.StartListening("ToggleBag", () =>
            {
                ToggleBag();
            });
            UpdateBagContents();

        }
        public void ToggleBag()
        {
            UpdateBagContents();
            gameObject.SetActive(!gameObject.activeSelf);
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
            foreach (var item in ItemsInBag)
            {
                var offset =(i * 35);
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
            if (ItemsInBag.ContainsKey(id) && ItemsInBag[id] > 0)
            {
                ItemsInBag[id]--;
                var item = _ItemRepository.GetFruitById(id);
                _GameManager.FeedTamagotchi(item);
                if(ItemsInBag[id] == 0){
                    ItemsInBag.Remove(id);
                }
                UpdateBagContents();
            }
        }
        private void Update()
        {

        }
        private void OnDestroy()
        {

        }
    }
}