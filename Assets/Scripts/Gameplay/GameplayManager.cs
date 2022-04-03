using System;
using Inventory;
using Resources;
using UnityEngine;
using Workspace;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private CharactersGenerator generator;
        [SerializeField] private int startLivesAmount;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private WorkspaceController workspaceController;


        private void Awake()
        {
            ResourcesController.SetLives(startLivesAmount);
            ResourcesController.AddLivesAmountListener(CheckLivesAmount);
        }
        
        public void StartGame()
        {
            generator.CreateNewCharacter();
        }

        private void CheckLivesAmount(int amount)
        {
            if (amount <= 0)
            {
                ResourcesController.SetLives(startLivesAmount);
                inventoryController.SetStartIngredients();
                workspaceController.FreeAllWorkspaceItems();
            }
        }
    }
}
