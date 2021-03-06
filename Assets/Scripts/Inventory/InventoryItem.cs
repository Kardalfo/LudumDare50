using System;
using InfoBubble;
using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem : IngredientItem
    {
        [SerializeField] private Image image;
        [SerializeField] private Button itemButton;
        
        private Action<Ingredient> _clickCallback;
        private bool _interactable;


        public void SetClickCallback(Action<Ingredient> clickCallback)
        {
            _clickCallback = clickCallback;
        }

        private void Awake()
        {
            itemButton.onClick.AddListener(OnClick);
        }
        
        public bool IsEmpty()
        {
            return Ingredient == null;
        }
        
        public void Free()
        {
            Ingredient = null;
            
            image.sprite = null;
            _interactable = true;
            gameObject.SetActive(false);
        }

        public void SetIngredient(Ingredient newIngredient)
        {
            Ingredient = newIngredient;
            image.sprite = newIngredient.Sprite;
            gameObject.SetActive(true);
        }

        public void SetInteractable(bool value)
        {
            _interactable = value;
        }

        private void OnClick()
        {
            if (!_interactable)
            {
                return;
            }
            
            _clickCallback?.Invoke(Ingredient);
            
            Ingredient = null;
            gameObject.SetActive(false);
        }
    }
}