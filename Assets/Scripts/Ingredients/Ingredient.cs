using System;
using System.Collections.Generic;
using Diseases;
using Inventory;
using UnityEngine;

namespace Ingredients
{
    [Serializable]
    public class Ingredient
    {
        [SerializeField] private IngredientType ingredientType;
        [SerializeField] private List<DiseaseType> positive;
        [SerializeField] private List<DiseaseType> negative;
        [SerializeField] private Sprite sprite;
        [SerializeField] private int price;


        public IngredientType IngredientType => ingredientType;
        public List<DiseaseType> Positive => positive;
        public List<DiseaseType> Negative => negative;
        public Sprite Sprite => sprite;
        public int Price => price;
    }
}
