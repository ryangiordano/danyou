using UnityEngine;

namespace Tamagotchi.Assets._UI
{
    public class ToggleMenu : MonoBehaviour
    {
        public int MenuId;
        private void Start()
        {
            gameObject.SetActive(false);
        }
    }
}