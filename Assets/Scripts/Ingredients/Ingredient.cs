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
        [SerializeField] private List<IngredientData> positive;
        [SerializeField] private List<IngredientData> negative;
        [SerializeField] private Sprite sprite;
        [SerializeField] private int price;

        public IngredientType IngredientType => ingredientType;
        public List<IngredientData> Positive => positive;
        public List<IngredientData> Negative => negative;
        public Sprite Sprite => sprite;
        public int Price => price;
    }

    [Serializable]
    public class IngredientData
    {
        public DiseaseType diseaseType;
        public bool known;
    }
}
