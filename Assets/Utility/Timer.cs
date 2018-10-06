using System;
using System.Collections.Generic;
using UnityEngine;

namespace Tamagotchi.Assets.Utility
{
    public class Timer
    {
        public DateTime CurrentTime { get; set; }
        public DateTime TimeSinceLastTick { get; set; }
        public int TimeUntilNextTick { get; set; }
        private int TimeBetweenTicks = 2; // Each tick is 30 minutes { get; set; }
        private List<ITimeable> Timeables = new List<ITimeable>();
        public Timer(DateTime timeSinceLastTick)
        {
            TimeSinceLastTick = timeSinceLastTick;
        }
        public void Tick(Action callback)
        {
            callback();
        }
        public void CheckForTick(Action callback)
        {
            var now = DateTime.Now;
            var minutesSinceLastTick = (now - TimeSinceLastTick).Seconds;
            if (minutesSinceLastTick >= TimeBetweenTicks)
            {
                Tick(callback);
                TimeSinceLastTick = now;
            }


        }
    }
}