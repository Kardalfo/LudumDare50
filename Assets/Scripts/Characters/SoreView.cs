using System;
using System.Collections.Generic;
using Diseases;
using UnityEngine;

namespace Characters
{
    [Serializable]
    public class SoreView
    {
        [SerializeField] private DiseaseType diseaseType;
        [SerializeField] private List<GameObject> turnOnObjects;
        [SerializeField] private List<GameObject> turnOffObjects;
        
        public DiseaseType DiseaseType => diseaseType;
        public List<GameObject> TurnOnObjects => turnOnObjects;
        public List<GameObject> TurnOffObjects => turnOffObjects;
    }
}