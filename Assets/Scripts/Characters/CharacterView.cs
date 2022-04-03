using System.Collections.Generic;
using Diseases;
using UnityEngine;

namespace Characters
{
    public class CharacterView : MonoBehaviour
    {
        [SerializeField] private List<SoreView> soreViews;
        private Dictionary<DiseaseType, SoreView> _soreViewsByType = new Dictionary<DiseaseType, SoreView>();

        private void Awake()
        {
            foreach (var soreView in soreViews)
                _soreViewsByType[soreView.DiseaseType] = soreView;
        }

        public void SetDiseases(List<Disease> diseases)
        {
            foreach (var soreView in _soreViewsByType)
            {
                foreach (var turnOnObject in soreView.Value.TurnOnObjects)
                    turnOnObject.gameObject.SetActive(false);
                
                foreach (var turnOffObject in soreView.Value.TurnOffObjects)
                    turnOffObject.gameObject.SetActive(true);
            }
            

            foreach(var soreView in _soreViewsByType)
            {
                foreach (var disease in diseases)
                {
                    if (soreView.Key == disease.Type)
                    {
                        foreach (var turnOnObject in soreView.Value.TurnOnObjects)
                            turnOnObject.gameObject.SetActive(true);
                
                        foreach (var turnOffObject in soreView.Value.TurnOffObjects)
                            turnOffObject.gameObject.SetActive(false);
                    }
                }
            }
        }
    }
}