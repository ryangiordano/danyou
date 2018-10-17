using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tamagotchi.Assets.Utility
{
    public static class JsonHelper
    {
        public static List<T> FromJson<T>(string json)
        {
            Wrapper<T> wrapper = JsonUtility.FromJson<Wrapper<T>>(json);
            return wrapper.Items;
        }

        public static string ToJson<T>(List<T> list)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = list;
            return JsonUtility.ToJson(wrapper);
        }

        public static string ToJson<T>(List<T> list, bool prettyPrint)
        {
            Wrapper<T> wrapper = new Wrapper<T>();
            wrapper.Items = list;
            return JsonUtility.ToJson(wrapper, prettyPrint);
        }
        public static string AppendItems(string value)
        {
            value = "{\"Items\":" + value + "}";
            return value;
        }

        [Serializable]
        private class Wrapper<T>
        {
            public List<T> Items;
        }
    }
}