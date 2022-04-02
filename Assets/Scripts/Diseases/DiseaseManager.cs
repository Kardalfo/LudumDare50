using System;
using System.Collections.Generic;
using UnityEngine;

namespace Diseases
{
    public class DiseaseManager : MonoBehaviour
    {
        [SerializeField] private List<Disease> diseases;

        private readonly Dictionary<DiseaseType, Disease> _diseasesByType = new Dictionary<DiseaseType, Disease>();


        private void Awake()
        {
            foreach (var disease in diseases)
                _diseasesByType[disease.Type] = disease;
        }

        public Disease GetDiseaseByType(DiseaseType diseaseType)
        {
            var disease = _diseasesByType[diseaseType];
            return disease;
        }
    }
}
