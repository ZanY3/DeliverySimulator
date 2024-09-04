using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TakeOrder : MonoBehaviour
{
    public GameObject[] orderPlaces;
    public TMP_Text clueText;
    public AudioClip orderTakedSound;
    public GameObject restaurnatGreenZone;

    public bool takedOrder = false;

    private AudioSource source;
    private bool usable = false;

    private void Start()
    {
        source = GetComponent<AudioSource>();
    }

    private async void Update()
    {
        if (usable && !takedOrder && Input.GetKeyDown(KeyCode.E))
        {
            restaurnatGreenZone.SetActive(false);
            takedOrder = true;
            usable = false;
            source.PlayOneShot(orderTakedSound);

            int randPlace = Random.Range(0, orderPlaces.Length);
            orderPlaces[randPlace].GetComponent<OrderPlace>().TakeOrder();

            clueText.gameObject.SetActive(true);
            await new WaitForSeconds(2);
            clueText.gameObject.SetActive(false);
        }
    }

    private void OnTriggerStay(Collider collision)
    {
        if (collision.gameObject.CompareTag("OrderTakeZone"))
        {
            usable = true;
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("OrderTakeZone"))
        {
            usable = false;
        }
    }
}
