using UnityEngine;

namespace Tamagotchi.Assets.Utility.ExtensionMethods
{
    public static class Extension
    {
        public static T FindComponentByObjectTag<T>(this MonoBehaviour ob, string tagname)
        {
            var gameObject = GameObject.FindWithTag(tagname);
            if (gameObject != null)
            {
                var component = gameObject.GetComponent<T>();
                if (component == null)
                {
                    throw new UnityException("Component not found.");
                }
                return component;

            }
            throw new UnityException("Game Object not found.");
        }
    }
}