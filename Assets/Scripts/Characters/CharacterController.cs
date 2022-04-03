using System;
using System.Collections.Generic;
using Diseases;
using Gameplay;
using Ingredients;
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
        private const string PoofKey = "Poof";

        [SerializeField] private DiseaseManager diseaseManager;
        [SerializeField] private CharacterDiseasesController characterDiseasesController;
        [SerializeField] private List<CharacterView> characters;
        [SerializeField] private int minPrize;
        [SerializeField] private int prizeMultiplier;
        [SerializeField] private Animation animation;

        private CharacterView activeCharacter;
        
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

        public void ShowNextCharacter(CharacterSettings setting)
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
            
            activeCharacter.SetDiseases(diseases);
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
        
        private void PlayPoof()
        {
            animation.Play(PoofKey);
        }

        public void GiveMedicine(List<IngredientData> heals, List<IngredientData> diseases)
        {
            var newDiseases = characterDiseasesController.GiveMedicine(heals, diseases);
            activeCharacter.SetDiseases(newDiseases);

            PlayPoof();
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
            ResourcesController.SubtractLives(1);
        }

        public void OnCharacterHidden()
        {
            _hiddenCallback?.Invoke();
        }

        public void SetRandomCharacter()
        {
            if (activeCharacter != null)
                activeCharacter.gameObject.SetActive(false);
            
            var random = Random.Range(0, characters.Count);
            activeCharacter = characters[random];
            activeCharacter.gameObject.SetActive(true);
        }
    }
}
