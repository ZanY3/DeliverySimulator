using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class OrderPlace : MonoBehaviour
{
    public GameObject marks;

    //public int minMoneyForOrder;
    //public int maxMoneyForOrder; 

    private bool takedOrder = false;
    private Transform plTransform;

    private void Start()
    {
        plTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    public void TakeOrder()
    {
        takedOrder = true;
        marks.SetActive(true);
    }
    public void EndOrder()
    {

    }    
}
