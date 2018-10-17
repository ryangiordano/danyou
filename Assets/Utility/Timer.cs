using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tamagotchi.Assets.Utility
{
    public class Timer : CustomMonoBehaviour
    {
        public DateTime CurrentTime { get; set; }
        public DateTime TimeSinceLastTick { get; set; }
        public int TimeUntilNextTick { get; set; }
        public UnityEvent Tick;
        public int TimeBetweenTicks = 2; // Each tick is 30 minutes { get; set; }
        public void Start()
        {
            Tick = new UnityEvent();
            StartCoroutine(CheckForTick());

        }
        public void Subscribe(UnityAction listener)
        {
            Tick.AddListener(listener);
        }
        public IEnumerator CheckForTick()
        {
            yield return new WaitForSeconds(TimeBetweenTicks);
            EventManager.TriggerEvent("Tick");
            yield return CheckForTick();
        }
    }
}


