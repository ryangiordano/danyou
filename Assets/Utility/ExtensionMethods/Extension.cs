using UnityEngine;

namespace Tamagotchi.Assets.Utility.ExtensionMethods
{
    public static class Extension
    {
        public static GameManager FindGameManager(this MonoBehaviour ob)
        {
            GameObject gameManagerObject = GameObject.FindWithTag("GameController");
            if (gameManagerObject != null)
            {
                var gameManager = gameManagerObject.GetComponent<GameManager>();
                if (gameManager == null)
                {
                    Debug.Log("Game manager not found.");
                    return null;
                }
                return gameManager;

            }
            return null;

        }
    }
}