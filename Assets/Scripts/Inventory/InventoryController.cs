using System;
using System.Collections.Generic;
using Ingredients;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private int shelvesCount;
        [SerializeField] private List<IngredientType> ingredientTypes;
        [SerializeField] private IngredientsManager ingredientsManager;
        [SerializeField] private ShelfController inventoryShelf;
        [SerializeField] private Transform parentTransform;

        private List<ShelfController> shelves = new List<ShelfController>();
        

        private void Awake()
        {
            for (var count = 0; count < shelvesCount; count++)
            {
                var shelf = Instantiate(inventoryShelf, parentTransform);
                shelves.Add(shelf);
            }

            var currentShelfIndex = 0;
            foreach (var ingredientType in ingredientTypes)
            {
                var ingredient = ingredientsManager.GetIngredientByType(ingredientType);
                var ingredientAdded = shelves[currentShelfIndex].TryAddIngredient(ingredient);

                if (!ingredientAdded)
                {
                    currentShelfIndex++;
                    shelves[currentShelfIndex].TryAddIngredient(ingredient);
                }
            }
        }

        private bool HasPlaceForIngredient()
        {
            foreach (var shelf in shelves)
            {
                var hasPlaceForIngredient = shelf.HasPlaceForIngredient();
                if (hasPlaceForIngredient)
                    return true;
            }

            return false;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            foreach (var shelf in shelves)
            {
                var ingredientAdded = shelf.TryAddIngredient(ingredient);

                if (ingredientAdded)
                    return;
            }
        }
    }
}
