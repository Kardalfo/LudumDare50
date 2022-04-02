using System;
using System.Collections.Generic;
using Diseases;
using UnityEngine;
using UnityEngine.UI;

namespace Characters
{
    public class CharacterDiseasesController : MonoBehaviour
    {
        [SerializeField] private List<Image> icons;

        private List<Disease> _diseases;

        private int _triesCount;

        private Action<int> _healedCallback;
        private Action _goHomeCallback;


        public void SetHealedCallback(Action<int> callback)
        {
            _healedCallback = callback;
        }

        public void SetGoHomeCallback(Action callback)
        {
            _goHomeCallback = callback;
        }

        public void SetTries(int tries)
        {
            _triesCount = tries;
        }
        
        public void SetDiseases(List<Disease> diseases)
        {
            _diseases = diseases;
            
            var diseasesCount = diseases.Count;
            var iconsCount = icons.Count;
            for (int i = 0; i < iconsCount; i++)
            {
                var icon = icons[i];
                if (i >= diseasesCount)
                {
                    icon.gameObject.SetActive(false);
                }
                else
                {
                    var disease = diseases[i];
                    icon.sprite = disease.Sprite;
                    icon.gameObject.SetActive(true);
                }
            }
        }

        public List<Disease> GiveMedicine(List<Disease> heals, List<Disease> diseases)
        {
            _diseases.AddRange(diseases);
            foreach (var heal in heals)
                _diseases.Remove(heal);

            SetDiseases(_diseases);
            CheckCharacterStatus();

            return _diseases;
        }

        private void CheckCharacterStatus()
        {
            if (_diseases.Count == 0)
            {
                _healedCallback?.Invoke(_triesCount);
                return;
            }

            if (_diseases.Count > icons.Count)
            {
                _goHomeCallback?.Invoke();
                return;
            }

            _triesCount -= 1;
            if (_triesCount <= 0)
            {
                _goHomeCallback?.Invoke();
            }
        }
    }
}
