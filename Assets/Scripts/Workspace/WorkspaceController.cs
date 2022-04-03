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
        }

        public void TryAddIngredient(Ingredient ingredient)
        {
            foreach (var item in workspaceItems)
            {
                if (item.IsEmpty())
                {
                    _ingredients.Add(ingredient);
                    item.SetIngredient(ingredient);
                    
                    CheckWorkspace(HasPlaceForIngredient());
                    
                    return;
                }
            }
            
            CheckWorkspace(false);
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

            var ingredient = item.Ingredient;
            inventoryController.AddIngredient(ingredient);
            _ingredients.Remove(ingredient);
            item.Free();
            
            CheckWorkspace(true);
        }

        private void CheckWorkspace(bool isInteractable)
        {
            inventoryController.SetInteractable(true);
            healButton.interactable = isInteractable;
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
