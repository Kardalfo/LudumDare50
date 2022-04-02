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


        private void Awake()
        {
            Queue<ShelfController> shelves = new Queue<ShelfController>();
            for (var count = 0; count < shelvesCount; count++)
            {
                var shelf = Instantiate(inventoryShelf, parentTransform);
                shelves.Enqueue(shelf);
            }

            var currentShelf = shelves.Dequeue();
            foreach (var ingredientType in ingredientTypes)
            {
                var ingredient = ingredientsManager.GetIngredientByType(ingredientType);
                var ingredientAdded = currentShelf.TryAddIngredientToItem(ingredient);
                
                if (ingredientAdded){}
            }
        }

        private void HasPlaceForIngredient()
        {
            
        }
    }
}
