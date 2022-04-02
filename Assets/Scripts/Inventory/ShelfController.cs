using System.Collections;
using System.Collections.Generic;
using Ingredients;
using Inventory;
using UnityEngine;

public class ShelfController : MonoBehaviour
{
    [SerializeField] private List<InventoryItem> inventoryItems;


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
