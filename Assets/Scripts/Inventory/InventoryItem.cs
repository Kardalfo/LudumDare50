using System;
using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private Image spriteRenderer;
        [SerializeField] private Button itemButton;
        
        private Ingredient _ingredient;
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
            return _ingredient == null;
        }

        public void SetIngredient(Ingredient newIngredient)
        {
            _ingredient = newIngredient;
            spriteRenderer.sprite = newIngredient.Sprite;
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
            
            _clickCallback?.Invoke(_ingredient);
            
            _ingredient = null;
            gameObject.SetActive(false);
        }
    }
}