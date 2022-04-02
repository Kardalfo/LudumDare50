using System;
using UnityEngine;

namespace Diseases
{
    [Serializable]
    public class Disease
    {
        [SerializeField] private DiseaseType type;
        [SerializeField] private Sprite sprite;
        
        public DiseaseType Type => type;
        public Sprite Sprite => sprite;
    }
}