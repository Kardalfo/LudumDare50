using System;
using Characters;
using Inventory;
using Resources;
using UnityEngine;
using UnityEngine.UI;
using Workspace;

namespace Gameplay
{
    public class GameplayManager : MonoBehaviour
    {
        [SerializeField] private CharactersGenerator generator;
        [SerializeField] private int startLivesAmount;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private WorkspaceController workspaceController;
        [SerializeField] private Button restartButton;
        [SerializeField] private CharacterDiseasesController characterDiseasesController;


        private void Awake()
        {
            ResourcesController.SetLives(startLivesAmount);
            ResourcesController.AddLivesAmountListener(CheckLivesAmount);
            restartButton.onClick.AddListener(RestartOnButton);
        }
        
        public void StartGame()
        {
            generator.CreateNewCharacter();
        }

        private void CheckLivesAmount(int amount)
        {
            if (amount <= 0)
                Restart();
        }

        private void Restart()
        {
            ResourcesController.SetLives(startLivesAmount);
            workspaceController.FreeAllWorkspaceItems();
            inventoryController.Restart();
        }
        
        private void RestartOnButton()
        {
            characterDiseasesController.InvokeGoHome();
            ResourcesController.SetLives(startLivesAmount);
            workspaceController.FreeAllWorkspaceItems();
            inventoryController.Restart();
        }
    }
}
