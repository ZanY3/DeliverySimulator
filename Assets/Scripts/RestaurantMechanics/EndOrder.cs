using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOrder : MonoBehaviour
{
    public GameObject restaurnatGreenZone;

    public AudioClip endOrderSound;


    private TakeOrder takeOrder;
    private AudioSource source;
    private bool usable = false;
    private OrderPlace orderPlace;

    private void Start()
    {
        takeOrder = FindAnyObjectByType<TakeOrder>();
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(usable && takeOrder.takedOrder && Input.GetKeyDown(KeyCode.E))
        {
            if(orderPlace.takedOrder)
                orderPlace.EndOrder();

            takeOrder.takedOrder = false;
            source.PlayOneShot(endOrderSound);
            restaurnatGreenZone.SetActive(true);

        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if(collision.gameObject.CompareTag("OrderEndZone"))
        {
            orderPlace = collision.transform.GetComponentInParent<OrderPlace>();
            usable = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("OrderEndZone"))
        {
            orderPlace = null;
            usable = false;
        }
    }
}
