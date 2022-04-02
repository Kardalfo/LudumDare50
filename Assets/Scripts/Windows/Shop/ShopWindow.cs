using System;
using Ingredients;
using Inventory;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace Windows.Shop
{
    public class ShopWindow : BaseWindow
    {
        [SerializeField] private IngredientsManager ingredientsManager;
        [SerializeField] private ShopItem shopItemPrefab;
        [SerializeField] private Transform parent;
        

        private void Awake()
        {
            var ingredients = ingredientsManager.Ingredients;
            foreach (var ingredient in ingredients)
            {
                var shopItem = Instantiate(shopItemPrefab, parent);
                shopItem.SetIngredient(ingredient);
//                shopItem.SetClickCallback(); TODO: попытка покупки через ресурсный контроллер
            }
        }
    }

    public class ShopItem : MonoBehaviour, IPointerClickHandler
    {
        [SerializeField] private Image icon;
        [SerializeField] private TMP_Text price;

        private Ingredient _ingredient;
        private Action<Ingredient> _clickCallback;
        

        public void SetIngredient(Ingredient ingredient)
        {
            _ingredient = ingredient;

            icon.sprite = ingredient.Sprite;
            price.text = ingredient.Price.ToString();
        }

        public void SetClickCallback(Action<Ingredient> clickCallback)
        {
            _clickCallback = clickCallback;
        }

        public void OnPointerClick(PointerEventData e)
        {
            _clickCallback?.Invoke(_ingredient);
        }
    }
}
