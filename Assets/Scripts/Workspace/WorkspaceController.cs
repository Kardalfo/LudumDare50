using System;
using System.Collections.Generic;
using Ingredients;
using Inventory;
using UnityEngine;

namespace Workspace
{
    public class WorkspaceController : MonoBehaviour
    {
        [SerializeField] private List<WorkspaceItem> workspaceItems;
        [SerializeField] private InventoryController inventoryController;


        private void Awake()
        {
            foreach (var workspaceItem in workspaceItems)
            {
                workspaceItem.SetClickCallback(OnItemClicked);
            }
        }

        public void TryAddIngredient(Ingredient ingredient)
        {
            foreach (var item in workspaceItems)
            {
                if (item.IsEmpty())
                {
                    item.SetIngredient(ingredient);
                    inventoryController.SetInteractable(HasPlaceForIngredient());
                    
                    return;
                }
            }
            
            inventoryController.SetInteractable(false);
        }

        private bool HasPlaceForIngredient()
        {
            foreach (var item in workspaceItems)
            {
                if (item.IsEmpty())
                    return true;
            }
            
            return false;
        }

        private void OnItemClicked(WorkspaceItem item)
        {
            if (!inventoryController.HasPlaceForIngredient())
                return;
            
            inventoryController.AddIngredient(item.Ingredient);
            item.Free();
            
            inventoryController.SetInteractable(true);
        }
    }
}
