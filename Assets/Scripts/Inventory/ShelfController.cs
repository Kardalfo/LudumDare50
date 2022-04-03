using System;
using System.Collections.Generic;
using Ingredients;
using UnityEngine;

namespace Inventory
{
    public class ShelfController : MonoBehaviour
    {
        [SerializeField] private List<InventoryItem> inventoryItems;


        public void SetInteractable(bool value)
        {
            foreach (var item in inventoryItems)
                item.SetInteractable(value);
        }
        
        public void FreeAllItems()
        {
            foreach (var item in inventoryItems)
                item.Free();
        }
    
        public void SetClickCallback(Action<Ingredient> clickCallback)
        {
            foreach (var item in inventoryItems)
                item.SetClickCallback(clickCallback);
        }

        public bool TryAddIngredient(Ingredient ingredient)
        {
            foreach (var inventoryItem in inventoryItems)
            {
                if (inventoryItem.IsEmpty())
                {
                    inventoryItem.SetIngredient(ingredient);
                    return true;
                }
            }
            return false;
        }

        public bool HasPlaceForIngredient()
        {
            foreach (var inventoryItem in inventoryItems)
            {
                if (inventoryItem.IsEmpty())
                    return true;
            }
            return false;
        }
    }
}
