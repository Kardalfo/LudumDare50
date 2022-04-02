using System;
using System.Collections.Generic;
using UnityEngine;

namespace Inventory
{
    public class InventoryController : MonoBehaviour
    {
        [SerializeField] private int itemsCount;
        [SerializeField] private List<IngredientType> items;
        [SerializeField] private ShelfController inventoryShelf;
        [SerializeField] private Transform parentTransform;


        private void Awake()
        {
            var shelfCount = itemsCount % 2 == 0? itemsCount / 2: itemsCount / 2 + 1;
            for (var count = 0; count < shelfCount; count++)
            {
                var shelf = Instantiate(inventoryShelf, parentTransform);
            }
        }
    }
}
