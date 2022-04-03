using System.Collections;
using System.Collections.Generic;
using Resources;
using TMPro;
using UnityEngine;

public class LivesView : MonoBehaviour
{
    [SerializeField] private TMP_Text amount;


    private void Awake()
    {
        SetAmount(ResourcesController.LivesAmount);
        ResourcesController.AddLivesAmountListener(SetAmount);
    }

    private void SetAmount(int livesAmount)
    {
        amount.text = livesAmount.ToString();
    }
}
