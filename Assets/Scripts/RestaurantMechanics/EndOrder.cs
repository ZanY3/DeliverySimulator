using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOrder : MonoBehaviour
{
    public GameObject restaurnatGreenZone;
    public AudioClip endOrderSound;
    public GameObject clueText;

    private TakeOrder takeOrder;
    private AudioSource source;
    private bool usable = false;
    private OrderPlace orderPlace;

    private void Start()
    {
        takeOrder = FindAnyObjectByType<TakeOrder>();
        source = GetComponent<AudioSource>();
    }

    private async void Update()
    {
        if (usable && takeOrder.takedOrder && Input.GetKeyDown(KeyCode.E))
        {
            if (orderPlace != null && orderPlace.takedOrder)
            {
                orderPlace.EndOrder();
                takeOrder.takedOrder = false; // —брасываем состо€ние заказа
                source.PlayOneShot(endOrderSound);
                restaurnatGreenZone.SetActive(true);
                await new WaitForSeconds(2);
                clueText.gameObject.SetActive(false);

            }
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("OrderEndZone"))
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
