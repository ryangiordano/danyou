using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tamagotchi.Assets.Utility
{
    public class Timer
    {
        public DateTime CurrentTime { get; set; }
        public DateTime TimeSinceLastTick { get; set; }
        public int TimeUntilNextTick { get; set; }
        public int TimeBetweenTicks = 2; // Each tick is 30 minutes { get; set; }
        private List<ITimeable> Timeables = new List<ITimeable>();
        public Timer(DateTime timeSinceLastTick)
        {
            TimeSinceLastTick = timeSinceLastTick;
        }
        public IEnumerator CheckForTick(Action callback)
        {
            yield return new WaitForSeconds(TimeBetweenTicks);
            callback();
            yield return CheckForTick(callback);
        }
    }
}