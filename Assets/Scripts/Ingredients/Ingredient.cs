using System.Collections.Generic;
using Diseases;
using UnityEngine;

namespace Ingredients
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private List<DiseaseType> positive;
        [SerializeField] private List<DiseaseType> negative;
        [SerializeField] private Sprite sprite;
        [SerializeField] private int price;
        [SerializeField] private float effect;
        
        public List<DiseaseType> Positive => positive;
        public List<DiseaseType> Negative => negative;
        public Sprite Sprite => sprite;
        public int Price => price;
        public float Effect => effect;
    }
}
