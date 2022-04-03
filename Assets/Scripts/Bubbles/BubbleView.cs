using System.Collections;
using System.Collections.Generic;
using Diseases;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BubbleView : MonoBehaviour
{
    [SerializeField] private List<Image> icons;
    [SerializeField] private List<TMP_Text> names;

    public void SetIcons(List<Disease> diseases)
    {
        var i = 0;
        foreach (var icon in icons)
        {
            icon.sprite = diseases[i].Sprite;
            names[i].text = diseases[i].Type.ToString();
            i++;
        }
    }
}
