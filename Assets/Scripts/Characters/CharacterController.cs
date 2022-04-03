using System;
using System.Collections.Generic;
using Diseases;
using Gameplay;
using Resources;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using Random = UnityEngine.Random;

namespace Characters
{
    public class CharacterController : MonoBehaviour
    {
        private const string ComeKey = "Come";
        private const string GoKey = "Go";

        [SerializeField] private DiseaseManager diseaseManager;
        [SerializeField] private CharacterDiseasesController characterDiseasesController;
        [SerializeField] private List<CharacterView> characters;
        [SerializeField] private int minPrize;
        [SerializeField] private int prizeMultiplier;
        [SerializeField] private Animation animation;

        private CharacterView active_character;
        
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
            var diseases = new List<Disease>();
            foreach (var diseasesType in setting.diseasesTypes)
            {
                var disease = diseaseManager.GetDiseaseByType(diseasesType);
                diseases.Add(disease);
            }
            characterDiseasesController.SetTries(setting.triesAmount);
            characterDiseasesController.SetDiseases(diseases);
            
            active_character.SetDiseases(diseases);
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
            active_character.SetDiseases(newDiseases);
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

        public void SetRandomCharacter()
        {
            if (active_character != null)
                active_character.gameObject.SetActive(false);
            
            var random = Random.Range(0, characters.Count);
            active_character = characters[random];
            active_character.gameObject.SetActive(true);
        }
    }
}
