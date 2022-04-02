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
            
            ResourcesController.AddCoinsAmountListener(OnCoinsAmountChanged);
        }

        private void BuyIngredient(Ingredient ingredient)
        {
            var price = ingredient.Price;
            //if (inventoryController.HaveFreeSpace)
            if (ResourcesController.TrySubtract(price))
            {
                //inventoryController.AddIngredient();
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
