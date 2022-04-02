using System;
using UnityEngine;

namespace Diseases
{
    [Serializable]
    public class Disease
    {
        [SerializeField] private DiseaseType type;
        [SerializeField] private Sprite sprite;
    }
}