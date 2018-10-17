using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Tamagotchi.Assets.Utility
{
    public class Timer : MonoBehaviour
    {
        public DateTime CurrentTime { get; set; }
        public DateTime TimeSinceLastTick { get; set; }
        public int TimeUntilNextTick { get; set; }
        public UnityEvent Tick;
        public int TimeBetweenTicks = 2; // Each tick is 30 minutes { get; set; }
        private List<ITimeable> Timeables = new List<ITimeable>();
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
            Tick.Invoke();
            yield return CheckForTick();
        }
    }
}


