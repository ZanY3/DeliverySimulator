using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarSalonZone : MonoBehaviour
{
    public GameObject gameUI;
    public GameObject salonUI;
    public GameObject player;
    public GameObject plCamera;

    private bool usable = false;
    private bool inMenu = false;

    private void Update()
    {
        if(usable && player.GetComponent<TakeOrder>().takedOrder == false && Input.GetKeyDown(KeyCode.E))
        {
            plCamera.GetComponent<CameraFollow>().enabled = false;
            player.GetComponent<Rigidbody>().isKinematic = true;
            inMenu = true;
            usable = false;
            gameUI.SetActive(false);
            salonUI.SetActive(true);
        }
        else if(inMenu && Input.GetKeyDown(KeyCode.Escape))
        {
            plCamera.GetComponent<CameraFollow>().enabled = true;
            player.GetComponent<Rigidbody>().isKinematic = false;
            inMenu = false;
            salonUI.SetActive(false);
            gameUI.SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            usable = true;
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            usable = false;
        }
    }
}
