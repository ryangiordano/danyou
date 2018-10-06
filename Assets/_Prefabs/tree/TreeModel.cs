using System;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets.Utility.Stage;

namespace Tamagotchi.Assets._Prefabs.tree
{
    public class TreeModel : ITimeable
    {
        public DateTime LastTick { get; set; }
        public int Experience { get; set; }
        public bool IsWatered { get; set; }
        public int CurrentStage { get; set; }
        public int NumStages { get; set; }
        public int CurrentExp { get; set; }
        public List<Point> History { get; set; }
        private ProgressManager _ProgressManager { get; set; }

        public FruitType FruitType;
        public TreeModel(int currentStage, int currentExp, int numStages)
        {
            CurrentStage = currentStage;
            CurrentExp = currentExp;
            NumStages = numStages;
            LastTick = DateTime.Now;
            _ProgressManager = new ProgressManager(NumStages, 10);

        }
        public void ProcessMoment()
        {
            var toAdd = IsWatered ? 2 : 1;
            CurrentExp += toAdd;
            var currentStage = _ProgressManager.GetNodeAtStage(CurrentStage);
            if (CurrentExp >= currentStage.ExpToNext)
            {
                LevelUp();
            }
            IsWatered = false;
        }

        public void RecordHistory()
        {
            var point = new Point
            {
                IsWatered = IsWatered,
            };
            if (History.Count >= 10)
            {
                History.RemoveAt(0);
            }
            History.Add(point);
        }

        public void LevelUp()
        {
        }

    }
    public class Point
    {
        public bool IsWatered { get; set; }
        public Point()
        {

        }
    }
}