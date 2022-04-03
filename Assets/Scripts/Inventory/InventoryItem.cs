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
        [SerializeField] private Image spriteRenderer;
        [SerializeField] private Button itemButton;
        [SerializeField] private TMP_Text name;
        
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

        public void SetIngredient(Ingredient newIngredient)
        {
            Ingredient = newIngredient;
            spriteRenderer.sprite = newIngredient.Sprite;
            name.text = newIngredient.IngredientType.ToString();
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