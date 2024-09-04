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
    private GameObject restaurantGreenZone;
    public bool takedOrder = false;
    private MoneyManager moneyManager;

    private void Start()
    {
        restaurantGreenZone = GameObject.FindGameObjectWithTag("OrderTakeZone");
        moneyManager = FindAnyObjectByType<MoneyManager>();
    }

    public void TakeOrder()
    {
        restaurantGreenZone.SetActive(false);
        takedOrder = true;
        marks.SetActive(true);
    }

    public void EndOrder()
    {
        takedOrder = false;
        moneyForOrder = Random.Range(minMoneyForOrder, maxMoneyForOrder);
        endOrderText.text = "+" + moneyForOrder.ToString() + "$";
        moneyManager.MoneyPlus(moneyForOrder);
        endOrderText.gameObject.SetActive(true);
        marks.SetActive(false);
    }
}
