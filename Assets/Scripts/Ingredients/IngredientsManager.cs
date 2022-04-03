using System.Collections.Generic;
using Inventory;
using UnityEngine;


namespace Ingredients
{
    public class IngredientsManager : MonoBehaviour
    {
        [SerializeField] private List<Ingredient> ingredients;


        public List<Ingredient> Ingredients => ingredients;

        public Ingredient GetIngredientByType(IngredientType ingredientType)
        {
            foreach (var ingredient in ingredients)
            {
                if (ingredient.IngredientType == ingredientType)
                    return ingredient;
            }
            
            return null;
        }
    }
}