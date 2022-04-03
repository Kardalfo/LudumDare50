using System;
using System.Collections.Generic;
using Diseases;
using Ingredients;
using Inventory;
using UnityEngine;
using UnityEngine.UI;
using CharacterController = Characters.CharacterController;

namespace Workspace
{
    public class WorkspaceController : MonoBehaviour
    {
        [SerializeField] private List<WorkspaceItem> workspaceItems;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private CharacterController characterController;
        [SerializeField] private DiseaseManager diseaseManager;
        [SerializeField] private Animation healAnimation;
        [SerializeField] private Button healButton;

        private readonly List<Ingredient> _ingredients = new List<Ingredient>();
        

        private void Awake()
        {
            healButton.onClick.AddListener(OnHealButton);
            
            foreach (var workspaceItem in workspaceItems)
                workspaceItem.SetClickCallback(OnItemClicked);

            SetWorkspaceAvailability(true);
        }

        public void TryAddIngredient(Ingredient ingredient)
        {
            foreach (var item in workspaceItems)
            {
                if (item.IsEmpty())
                {
                    _ingredients.Add(ingredient);
                    item.SetIngredient(ingredient);
                    
                    SetWorkspaceAvailability(HasPlaceForIngredient());
                    
                    return;
                }
            }
            
            SetWorkspaceAvailability(false);
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

        private bool IsWorkplaceEmpty()
        {
            var count = workspaceItems.Count;
            foreach (var item in workspaceItems)
            {
                if (item.IsEmpty())
                    count -= 1;
            }
            
            return count == 0;
        }

        private void OnItemClicked(WorkspaceItem item)
        {
            if (!inventoryController.HasPlaceForIngredient())
                return;

            var ingredient = item.Ingredient;
            inventoryController.AddIngredient(ingredient);
            _ingredients.Remove(ingredient);
            item.Free();
            
            SetWorkspaceAvailability(true);
        }

        private void SetWorkspaceAvailability(bool isInteractable)
        {
            inventoryController.SetInteractable(isInteractable);
            healButton.interactable = !IsWorkplaceEmpty();
        }

        private void OnHealButton()
        {
            healAnimation.Play();
        }

        public void HealAnimationFinished()
        {
            var heals = new List<Disease>();
            var diseases = new List<Disease>();
            foreach (var ingredient in _ingredients)
            {
                foreach (var diseaseType in ingredient.Positive)
                    heals.Add(diseaseManager.GetDiseaseByType(diseaseType));
                
                foreach (var diseaseType in ingredient.Negative)
                    diseases.Add(diseaseManager.GetDiseaseByType(diseaseType));
            }
            characterController.GiveMedicine(heals, diseases);
        }
    }
}
