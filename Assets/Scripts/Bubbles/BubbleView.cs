using System.Collections.Generic;
using Diseases;
using UnityEngine;
using UnityEngine.UI;

namespace Bubbles
{
    public class BubbleView : MonoBehaviour
    {
        [SerializeField] private List<Image> icons;

        public void SetIcons(List<Disease> diseases)
        {
            var i = 0;
            foreach (var icon in icons)
            {
                icon.sprite = diseases[i].Sprite;
                i++;
            }
        }
    }
}
