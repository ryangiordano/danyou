
using System;

namespace Tamagotchi.Assets.Utility.Stage
{
    public class ProgressNode
    {
        public int ExpToNext { get; set; }
        public int Stage { get; set; }
        public ProgressNode(int stage, float progressionCurve)
        {
            Stage = stage;
            ExpToNext = (int)(stage * progressionCurve);
        }
    }
}