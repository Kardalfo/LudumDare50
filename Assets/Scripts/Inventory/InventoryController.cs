using System;
using System.Collections.Generic;
using Ingredients;
using Resources;
using UnityEngine;
using Workspace;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private int shelvesCount;
        [SerializeField] private List<IngredientType> ingredientTypes;
        [SerializeField] private int startCoinsValue;
        [SerializeField] private IngredientsManager ingredientsManager;
        [SerializeField] private ShelfController inventoryShelf;
        [SerializeField] private Transform parentTransform;
        [SerializeField] private WorkspaceController workspaceController;

        private readonly List<ShelfController> _shelves = new List<ShelfController>();
        private bool _interactable;
        

        private void Awake()
        {
            _interactable = true;
            
            for (var count = 0; count < shelvesCount; count++)
            {
                var shelf = Instantiate(inventoryShelf, parentTransform);
                shelf.SetClickCallback(OnItemClick);
                _shelves.Add(shelf);
            }

            var currentShelfIndex = 0;
            foreach (var ingredientType in ingredientTypes)
            {
                var ingredient = ingredientsManager.GetIngredientByType(ingredientType);
                
                if (ingredient == null)
                    continue;
                
                var ingredientAdded = _shelves[currentShelfIndex].TryAddIngredient(ingredient);

                if (!ingredientAdded)
                {
                    currentShelfIndex++;
                    _shelves[currentShelfIndex].TryAddIngredient(ingredient);
                }
            }
            ResourcesController.AddCoins(startCoinsValue);
            
            SetInteractable(_interactable);
        }

        private void OnItemClick(Ingredient ingredient)
        {
            workspaceController.TryAddIngredient(ingredient);
        }

        public void SetInteractable(bool value)
        {
            _interactable = value;
            
            foreach (var shelf in _shelves)
                shelf.SetInteractable(value);
        }

        public bool HasPlaceForIngredient()
        {
            foreach (var shelf in _shelves)
            {
                var hasPlaceForIngredient = shelf.HasPlaceForIngredient();
                if (hasPlaceForIngredient)
                    return true;
            }

            return false;
        }

        public void AddIngredient(Ingredient ingredient)
        {
            foreach (var shelf in _shelves)
            {
                shelf.SetInteractable(_interactable);
                
                var ingredientAdded = shelf.TryAddIngredient(ingredient);

                if (ingredientAdded)
                    return;
            }
        }
    }
}
