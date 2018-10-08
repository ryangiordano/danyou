using System.Collections.Generic;
using UnityEngine;

namespace Tamagotchi.Assets.Utility.Stage
{
    public class ProgressManager
    {
        public List<ProgressNode> Progress { get; set; }
        public ProgressManager(int stages, float progressionCurve)
        {
            Progress = new List<ProgressNode>();
            for (int i = 1; i <= stages; i++)
            {
                var node = new ProgressNode(i, progressionCurve);
                Progress.Add(node);
            }
        }
        public ProgressNode GetNodeAtStage(int stage)
        {
            return Progress.Find((progressNode) => progressNode.Stage == stage);
        }
    }
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