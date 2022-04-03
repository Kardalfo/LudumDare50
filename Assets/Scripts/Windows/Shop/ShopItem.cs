using System;
using InfoBubble;
using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Windows.Shop
{
    public class ShopItem : IngredientItem
    {
        [SerializeField] private Button button;
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text price;

        private Action<Ingredient> _clickCallback;


        private void Awake()
        {
            button.onClick.AddListener(OnPointerClick);
        }

        public void SetIngredient(Ingredient ingredient)
        {
            Ingredient = ingredient;

            icon.sprite = ingredient.Sprite;
            price.text = ingredient.Price.ToString();
        }

        public void SetClickCallback(Action<Ingredient> clickCallback)
        {
            _clickCallback = clickCallback;
        }

        private void OnPointerClick()
        {
            _clickCallback?.Invoke(Ingredient);
        }

        public void CheckCoins(int amount)
        {
            var isAvailable = Ingredient.Price <= amount;
            
            button.interactable = isAvailable;
            icon.color = isAvailable ? Color.white : Color.gray;
        }
    }
}