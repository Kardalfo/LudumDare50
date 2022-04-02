using System.Collections;
using System.Collections.Generic;
using Ingredients;
using Inventory;
using UnityEngine;

public class WorkspaceController : MonoBehaviour
{
    [SerializeField] private List<WorkspaceItem> workspaceItems;
    [SerializeField] private InventoryController inventoryController;
    
    
    public bool TryAddIngredient(Ingredient ingredient)
    {
        foreach (var item in workspaceItems)
        {
            if (item.IsEmpty())
            {
                item.SetIngredient(ingredient);

                foreach (var workspaceItem in workspaceItems)
                {
                    if (workspaceItem.IsEmpty())
                    {
                        inventoryController.SetInteractable(true);
                        break;
                    }
                    
                    inventoryController.SetInteractable(false);
                }

                return true;
            }
        }
        return false;
    }

    public bool HasPlaceForIngredient()
    {
        foreach (var item in workspaceItems)
        {
            if (item.IsEmpty())
                return true;
        }
        return false;
    }
}
