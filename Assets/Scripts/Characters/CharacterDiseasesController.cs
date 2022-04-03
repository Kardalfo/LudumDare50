using System;
using System.Collections.Generic;
using Diseases;
using Resources;
using UnityEngine;


namespace Characters
{
    public class CharacterDiseasesController : MonoBehaviour
    {
        [SerializeField] private int maxDiseasesAmount = 4;
        [SerializeField] private List<BubbleView> bubbles;

        private List<Disease> _diseases;

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
            ResourcesController.SetTries(tries);
        }
        
        public void SetDiseases(List<Disease> diseases)
        {
            foreach (var bubble in bubbles)
                bubble.gameObject.SetActive(false);
            
            _diseases = diseases;
            
            var diseasesCount = diseases.Count;

            var currentBubble = bubbles[diseasesCount - 1];
            
            currentBubble.SetIcons(_diseases);
            currentBubble.gameObject.SetActive(true);
        }

        public List<Disease> GiveMedicine(List<Disease> heals, List<Disease> diseases)
        {
            _diseases.AddRange(diseases);
            foreach (var heal in heals)
                _diseases.Remove(heal);

            if (CheckCharacterStatus())
                SetDiseases(_diseases);

            return _diseases;
        }

        private bool CheckCharacterStatus()
        {
            var triesCount = ResourcesController.TriesAmount;
            if (_diseases.Count == 0)
            {
                foreach (var bubble in bubbles)
                    bubble.gameObject.SetActive(false);
                
                _healedCallback?.Invoke(triesCount);
                return false;
            }

            if (_diseases.Count > maxDiseasesAmount)
            {
                _goHomeCallback?.Invoke();
                return false;
            }

            ResourcesController.SubtractTries();
            if (ResourcesController.TriesAmount <= 0)
            {
                _goHomeCallback?.Invoke();
            }

            return true;
        }
    }
}
