using UnityEngine;
using UnityEngine.Events;

namespace Inventory
{
    public class InventoryItem : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        public UnityEvent clickEvent;

        private int _itemsAmount;
    }
}