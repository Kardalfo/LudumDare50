using System.Collections.Generic;
using Ingredients;
using Inventory;
using Resources;
using UnityEngine;


namespace Windows.Shop
{
    public class ShopWindow : BaseWindow
    {
        [SerializeField] private IngredientsManager ingredientsManager;
        [SerializeField] private InventoryController inventoryController;
        [SerializeField] private ShopItem shopItemPrefab;
        [SerializeField] private Transform parent;

        private readonly List<ShopItem> _shopItems = new List<ShopItem>();


        private void Awake()
        {
            var ingredients = ingredientsManager.Ingredients;
            foreach (var ingredient in ingredients)
            {
                var shopItem = Instantiate(shopItemPrefab, parent);
                shopItem.SetIngredient(ingredient);
                shopItem.SetClickCallback(BuyIngredient);
                
                _shopItems.Add(shopItem);
            }

            OnCoinsAmountChanged(ResourcesController.CoinsAmount);
            ResourcesController.AddCoinsAmountListener(OnCoinsAmountChanged);
        }

        private void BuyIngredient(Ingredient ingredient)
        {
            if (!inventoryController.HasPlaceForIngredient())
                return;
            
            var price = ingredient.Price;

            if (ResourcesController.TrySubtractCoins(price))
            {
                inventoryController.AddIngredient(ingredient);
            }
        }

        private void OnCoinsAmountChanged(int amount)
        {
            foreach (var shopItem in _shopItems)
            {
                shopItem.CheckCoins(amount);
            }
        }
    }
}
