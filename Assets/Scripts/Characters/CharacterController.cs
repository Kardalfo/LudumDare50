using System;
using System.Collections.Generic;
using Diseases;
using Gameplay;
using Resources;
using UnityEngine;

namespace Characters
{
    public class CharacterController : MonoBehaviour
    {
        private const string ComeKey = "Come";
        private const string GoKey = "Go";
        
        [SerializeField] private CharacterDiseasesController characterDiseasesController;
        [SerializeField] private CharacterView view;
        [SerializeField] private int minPrize;
        [SerializeField] private int prizeMultiplier;
        [SerializeField] private Animation animation;

        private int _tutorialPrize;
        
        private Action _hiddenCallback;
        

        private void Awake()
        {
                
            characterDiseasesController.SetHealedCallback(OnHealed);
            characterDiseasesController.SetGoHomeCallback(OnGoHome);
        }

        public void SetCharacterHiddenCallback(Action callback)
        {
            _hiddenCallback = callback;
        }

        public void ShowNextDiseased(CharacterSettings setting)
        {
            _tutorialPrize = setting.tutorialPrize;
            
            characterDiseasesController.SetTries(setting.triesAmount);
            characterDiseasesController.SetDiseases(setting.diseases);
            
            //view.SetDiseases(diseases);
            ShowCharacter();
        }

        private void ShowCharacter()
        {
            animation.Play(ComeKey);
        }

        private void HideCharacter()
        {
            animation.Play(GoKey);
        }

        public void GiveMedicine(List<Disease> heals, List<Disease> diseases)
        {
            var newDiseases = characterDiseasesController.GiveMedicine(heals, diseases);
            //view.SetDiseases(newDiseases);
        }

        private void OnHealed(int triesCount)
        {
            ResourcesController.AddCoins(_tutorialPrize == -1 
                ? minPrize + triesCount * prizeMultiplier
                : _tutorialPrize);
            
            HideCharacter();
        }

        private void OnGoHome()
        {
            HideCharacter();
        }

        public void OnCharacterHidden()
        {
            _hiddenCallback?.Invoke();
        }

        public void SetRandomSkin()
        {
            //view.SetRandomSkin();
        }
    }
}
