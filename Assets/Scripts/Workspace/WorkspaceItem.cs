using System.Collections;
using System.Collections.Generic;
using Ingredients;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WorkspaceItem : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private Button itemButton;
    private Ingredient _ingredient;


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
        image.sprite = newIngredient.Sprite;
        gameObject.SetActive(true);
    }

    private void OnClick()
    {
        Debug.Log("ITEM CLICKED");
    }
}
