using System;
using InfoBubble;
using Ingredients;
using UnityEngine;
using UnityEngine.UI;

namespace Workspace
{
    public class WorkspaceItem : IngredientItem
    {
        [SerializeField] private Image image;
        [SerializeField] private Button itemButton;

        private Action<WorkspaceItem> _clickCallback;


        private void Awake()
        {
            itemButton.onClick.AddListener(OnClick);
            Free();
        }
        
        public bool IsEmpty()
        {
            return Ingredient == null;
        }

        public void SetIngredient(Ingredient ingredient)
        {
            Ingredient = ingredient;

            image.enabled = true;
            image.sprite = ingredient.Sprite;
            
            itemButton.interactable = true;
        }

        private void OnClick()
        {
            _clickCallback?.Invoke(this);
        }

        public void SetClickCallback(Action<WorkspaceItem> onItemClicked)
        {
            _clickCallback = onItemClicked;
        }

        public void Free()
        {
            Ingredient = null;
            
            image.enabled = false;
            image.sprite = null;
            
            itemButton.interactable = false;
        }
    }
}
