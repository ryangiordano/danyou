using System;
using System.Collections.Generic;
using Tamagotchi.Assets._Prefabs.items;
using Tamagotchi.Assets.Utility;
using UnityEngine;

namespace Tamagotchi.Assets._Prefabs
{
    public class TamagotchiModel : ITimeable
    {
        public TamagotchiModel(String name)
        {
            this.Name = name;
            ToNextLevel = CurrentLevel * 10;
            CreatedDate = DateTime.Now;

            this.Memory = new List<Moment>();
        }
        public String Name;
        public DateTime CreatedDate = DateTime.Now;
        public DateTime HatchDate;
        public bool IsSick = false;
        public int CurrentHappiness = 1;
        public int MaxHappiness = 100;
        public int CurrentHunger = 1;
        public int MaxHunger = 100;
        /* Designates whether the Tamagotchi can be made happier, and by what degree.  Handles diminishing returns */
        public float Satisfaction = 1f;
        public float MaxSatisfaction = 100;
        public FruitType FavoriteFood;
        public int GrowthXp = 0;
        public int ToNextLevel;
        public int CurrentLevel = 1;
        public bool HasBeenFed;
        public List<Moment> Memory;
        public DateTime LastTick { get; set; }
        public static TamagotchiModel LoadTamagotchi()
        {
            return new TamagotchiModel("Test");
        }
        public void RecordMemory()
        {
            var moment = new Moment
            {
                HappinessLevel = CurrentHappiness,
                HungerLevel = CurrentHunger,
                IsSick = IsSick,
                HasBeenFed = HasBeenFed
            };
            if (Memory.Count >= 10)
            {
                Memory.RemoveAt(0);
            }
            Memory.Add(moment);
        }
        public void ChangeHappinessBy(int changeBy)
        {
            CurrentHappiness = Mathf.Clamp(CurrentHappiness + changeBy, 0, MaxHappiness);
        }
        public void ChangeHungerBy(int changeBy)
        {
            CurrentHunger = Mathf.Clamp(CurrentHunger + changeBy, 0, MaxHunger);
        }
        public void ChangeSatisfactionBy(int changeBy)
        {
            Satisfaction = Mathf.Clamp(Satisfaction + changeBy, 0, MaxSatisfaction);
        }
        public void ProcessMoment()
        {
            //Take into consideration happiness levels, health, environment, satisfaction levels and hunger.
            if (CurrentHunger < 50)
            {
                this.ChangeHappinessBy(5);
            }
            if (CurrentHunger >= 50 && CurrentHunger <= 74)
            {
                this.ChangeHappinessBy(-10);
            }
            if (CurrentHunger > 74 && CurrentHunger < 100)
            {
                this.ChangeHappinessBy(-20);
            }
            if (CurrentHunger == 100)
            {
                this.ChangeHappinessBy(-30);
            }

            ChangeHungerBy(5);
            ChangeSatisfactionBy(-30);
            RecordMemory();
            HasBeenFed = false;
        }

    }

    public class Moment
    {
        public int HappinessLevel { get; set; }
        public int HungerLevel { get; set; }
        public bool IsSick { get; set; }
        public bool HasBeenFed { get; set; }
        public Moment()
        {

        }
    }
}