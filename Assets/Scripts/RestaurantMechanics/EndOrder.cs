using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EndOrder : MonoBehaviour
{
    public GameObject restaurnatGreenZone;

    public AudioClip endOrderSound;


    private AudioSource source;
    private bool usable = false;
    private OrderPlace orderPlace;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private void Update()
    {
        if(usable && TakeOrder.takedOrder && Input.GetKeyDown(KeyCode.E))
        {
            source.PlayOneShot(endOrderSound);
            restaurnatGreenZone.SetActive(true);

            orderPlace.EndOrder();
            TakeOrder.takedOrder = false;
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
