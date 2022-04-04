using System.Collections.Generic;
using Resources;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisitorsCountView : MonoBehaviour
{
    [SerializeField] private TMP_Text amount;


    private void Awake()
    {
        SetAmount(0);
        ResourcesController.SetVisitorsCountListener(SetAmount);
    }

    private void SetAmount(int visitorsCount)
    {
        amount.text = visitorsCount.ToString();
    }
}
