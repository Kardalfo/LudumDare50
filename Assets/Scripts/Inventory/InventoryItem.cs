using UnityEngine;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;

        private int _itemsAmount;
    }
}