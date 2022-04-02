using System;
using System.Collections.Generic;
using Diseases;
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
        [SerializeField] private List<TrySettings> trySettings;
        [SerializeField] private int minPrize;
        [SerializeField] private int prizeMultiplier;
        [SerializeField] private Animation animation;

        private Dictionary<int, TrySettings> _trySettingsById = new Dictionary<int, TrySettings>();

        private Action _hiddenCallback;
        

        private void Awake()
        {
            foreach (var trySetting in trySettings)
                _trySettingsById[trySetting.DiseaseAmount] = trySetting;
                
            characterDiseasesController.SetHealedCallback(OnHealed);
            characterDiseasesController.SetGoHomeCallback(OnGoHome);
        }

        public void SetCharacterHiddenCallback(Action callback)
        {
            _hiddenCallback = callback;
        }

        public void ShowNextDiseased(List<Disease> diseases)
        {
            var setting = _trySettingsById[diseases.Count];
            var triesAmount = setting.GetRandomTriesAmount();
            
            characterDiseasesController.SetTries(triesAmount);
            characterDiseasesController.SetDiseases(diseases);
            
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
            var prize = minPrize + triesCount * prizeMultiplier;
            ResourcesController.AddCoins(prize);
            
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
    }
}
