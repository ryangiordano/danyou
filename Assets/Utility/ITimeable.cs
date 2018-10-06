using System;

namespace Tamagotchi.Assets.Utility
{
    public interface ITimeable
    {
        void ProcessMoment();
        DateTime LastTick{get;set;}
    }
}