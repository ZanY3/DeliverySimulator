using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakeOrder : MonoBehaviour
{
    public GameObject[] orderPlaces;
    
    private bool takedOrder = false;
    private bool usable = false;


    private void Update()
    {
        if(usable && !takedOrder && Input.GetKeyDown(KeyCode.E))
        {
            takedOrder = true;
            var randPlace = Random.Range(0, orderPlaces.Length);
            orderPlaces[randPlace].GetComponent<OrderPlace>().TakeOrder();
            
            Debug.Log("Taked order!");
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("OrderTakeZone"))
        {
            usable = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if(collision.gameObject.CompareTag("OrderTakeZone"))
        {
            usable = false;
        }
    }
}
