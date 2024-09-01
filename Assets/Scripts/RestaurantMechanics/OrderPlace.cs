using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderPlace : MonoBehaviour
{
    public GameObject marks;
    public TMP_Text endOrderText;

    public int minMoneyForOrder;
    public int maxMoneyForOrder;

    private int moneyForOrder;

    public bool takedOrder = false;
    private MoneyManager moneyManager;

    private void Start()
    {
        moneyManager = FindAnyObjectByType<MoneyManager>();
    }

    public void TakeOrder()
    {
        takedOrder = true;
        marks.SetActive(true);
    }
    public void EndOrder()
    {
        if(takedOrder)
        {
            moneyForOrder = Random.Range(minMoneyForOrder, maxMoneyForOrder);
            endOrderText.text = "+" + moneyForOrder.ToString() + "$";
            endOrderText.gameObject.SetActive(true);
            takedOrder = false;
            marks.SetActive(false);
            moneyManager.MoneyPlus(moneyForOrder);
        }
    }    
}
