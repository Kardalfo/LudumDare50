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
    }
}