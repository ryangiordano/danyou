using System;
using Tamagotchi.Assets.Utility;
using Tamagotchi.Assets._Prefabs.items;
using UnityEngine;
using System.Collections;

namespace Tamagotchi.Assets._Prefabs
{
    public class TamagotchiController : MonoBehaviour
    {
        public GameManager _GameManager;
        public TamagotchiModel _Tamagotchi;
        public GameObject Poop;
        private Timer _Timer;
        private Animator _Animator;

        public void Start()
        {
            // var savedData = this.GetSavedData();

            _Tamagotchi = TamagotchiModel.LoadTamagotchi();

            _Tamagotchi.LastTick = DateTime.Now;
            _Timer = new Timer(_Tamagotchi.LastTick);

            _Animator = GetComponent<Animator>();
        
            StartCoroutine(_Timer.CheckForTick(ProcessTick));


        }
        public void Update()
        {
            UpdateTamagotchiMood();
        }
        public void Feed()
        {
            if (_Tamagotchi.CurrentHunger == 0)
            {
                return;
            }
            _Tamagotchi.ChangeHungerBy(-20);
            _Tamagotchi.HasBeenFed = true;
            //placeholder value
            if (_Tamagotchi.Satisfaction == _Tamagotchi.MaxSatisfaction)
            {
                return;
            }

            _Tamagotchi.ChangeSatisfactionBy(4);
            int changeBy = Mathf.RoundToInt(2 - ((_Tamagotchi.Satisfaction / _Tamagotchi.MaxSatisfaction) * 3));
            _Tamagotchi.ChangeHappinessBy(changeBy);

        }

        public void Pet()
        {
            _Animator.Play("wiggle");
            if (_Tamagotchi.Satisfaction == _Tamagotchi.MaxSatisfaction)
            {
                return;
            }
            //From 1 satisfaction to 100 satisfaction, you can get your Tamagotchi to around 50% happiness with these presets
            int changeBy = Mathf.RoundToInt(5 - ((_Tamagotchi.Satisfaction / _Tamagotchi.MaxSatisfaction) * 3));
            _Tamagotchi.ChangeHappinessBy(changeBy);
            _Tamagotchi.ChangeSatisfactionBy(10);
        }
        private void OnMouseDown()
        {
            _GameManager.PetTamagotchi();
        }
        private void ProcessTick()
        {
            if (_Tamagotchi.Memory.Count == 10 && _Tamagotchi.Memory[0].HasBeenFed)
            {
                Instantiate(Poop, transform.position, transform.rotation);
            }
            _Tamagotchi.ProcessMoment();
            _GameManager.UpdateValues();
        }

        private void UpdateTamagotchiMood()
        {
            _Animator.SetBool("happy", _Tamagotchi.CurrentHappiness >= 50
                && !_Tamagotchi.IsSick);
            _Animator.SetBool("neutral", _Tamagotchi.CurrentHappiness >= 25
                && _Tamagotchi.CurrentHappiness < 50 && !_Tamagotchi.IsSick);
            _Animator.SetBool("sad", _Tamagotchi.CurrentHappiness < 25);
        }



    }
}