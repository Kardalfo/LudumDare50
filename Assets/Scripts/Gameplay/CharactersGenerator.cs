using System;
using System.Collections.Generic;
using Characters;
using Diseases;
using UnityEngine;
using CharacterController = Characters.CharacterController;
using Random = UnityEngine.Random;

namespace Gameplay
{
    public class CharactersGenerator : MonoBehaviour
    {
        [SerializeField] private int maxRandomDiseaseAmount = 3;
        [SerializeField] private List<CharacterSettings> tutorialCharacterSettings;
        [SerializeField] private List<TrySettings> trySettings;
        [SerializeField] private CharacterController characterController;

        private readonly Dictionary<int, TrySettings> _trySettingsById = new Dictionary<int, TrySettings>();
        
        private int _diseaseTypeAmount;
        private int _tutorialIndex;


        private void Awake()
        {
            _diseaseTypeAmount = Enum.GetValues(typeof(DiseaseType)).Length - 1;
            
            characterController.SetCharacterHiddenCallback(CreateNewCharacter);
            
            foreach (var trySetting in trySettings)
                _trySettingsById[trySetting.DiseaseAmount] = trySetting;
        }

        public void CreateNewCharacter()
        {
            characterController.SetRandomCharacter();

            var settings = GetSettings();
            characterController.ShowNextCharacter(settings);
        }

        private CharacterSettings GetSettings()
        {
            if (_tutorialIndex < tutorialCharacterSettings.Count)
            {
                var settings = tutorialCharacterSettings[_tutorialIndex];
                _tutorialIndex += 1;
                
                return settings;
            }

            return GenerateSettings();
        }

        private CharacterSettings GenerateSettings()
        {
            var diseases = GetRandomDiseases();
            var setting = _trySettingsById[diseases.Count];
            var triesAmount = setting.GetRandomTriesAmount();
            
            var settings = new CharacterSettings
            {
                diseasesTypes = diseases,
                tutorialPrize = -1,
                triesAmount = triesAmount,
            };

            return settings;
        }

        private List<DiseaseType> GetRandomDiseases()
        {
            var diseasesAmount = Random.Range(1, maxRandomDiseaseAmount + 1);
            var diseases = new List<DiseaseType>();

            for (var i = 0; i < diseasesAmount; i++)
            {
                var diseaseType = (DiseaseType) Random.Range(1, _diseaseTypeAmount + 1);
                while (diseaseType == DiseaseType.EyesLost)
                    diseaseType = (DiseaseType) Random.Range(1, _diseaseTypeAmount + 1);
                
                diseases.Add(diseaseType);
            }

            return diseases;
        }
    }
}