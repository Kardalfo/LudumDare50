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
            ResourcesController.AddLives(startLivesAmount);
            ResourcesController.AddLivesAmountListener(CheckLivesAmount);
        }

        private void Start()
        {
            StartGame();
        }
        
        public void StartGame()
        {
            generator.CreateNewCharacter();
        }

        private void CheckLivesAmount(int amount)
        {
            if (amount <= 0)
            {
                inventoryController.SetStartIngredients();
                workspaceController.FreeAllWorkspaceItems();
            }
        }
    }
}
