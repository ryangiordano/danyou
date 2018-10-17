using System.Collections.Generic;
using Tamagotchi.Assets.Utility;

namespace Tamagotchi.Assets._Prefabs.items.Bag
{
    public class BagController : CustomMonoBehaviour
    {
        // A bag should contain a reference to the player, the item repository, and the active character object in the scene.
        private ItemRepository _ItemRepository;
        public Dictionary<int, int> ItemsInBag;
        public GameManager _GameManager;

        private void Start()
        {
            ItemsInBag = new Dictionary<int, int>();
            // DontDestroyOnLoad(gameObject);
            _ItemRepository = FindComponentByObjectTag<ItemRepository>("ItemRepository");
            _GameManager = FindComponentByObjectTag<GameManager>("GameController");

            EventManager.StartListening("OpenBag", () =>
            {
                print("Bag opening");
            });

        }
        public void AddItem(int id)
        {
            if (ItemsInBag.ContainsKey(id))
            {
                ItemsInBag[id]++;
            }
            else
            {
                ItemsInBag[id] = 0;
            }
        }
        public void UseItem(int id)
        {
            print(ItemsInBag);
            print(id);
            if (ItemsInBag.ContainsKey(id) && ItemsInBag[id] > 0)
            {
                ItemsInBag[id]--;
                var item = _ItemRepository.ItemGameObjects.Find((i) => i.GetComponent<FruitController>().Id == id);
                _GameManager.FeedTamagotchi(item);
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