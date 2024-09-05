using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FineSystem : MonoBehaviour
{
    public TMP_Text fineClueText;
    public AudioClip fineSound;

    [Header("Fine Price/Speed")]
    public float smallFineSpeed;
    public float mediumFineSpeed;
    public float largeFineSpeed;
    [Space]
    public int smallFinePrice;
    public int mediumFinePrice;
    public int largeFinePrice;

    private MoneyManager moneyManager;
    private Rigidbody rb;
    private AudioSource source;
    private bool canGetFine = true;

    private void Start()
    {
        moneyManager = FindAnyObjectByType<MoneyManager>();
        rb = GetComponent<Rigidbody>();
        source = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("FineObj") && canGetFine && moneyManager.money >= smallFinePrice)
        {
            ApplyFineAsync();
        }
    }

    private async void ApplyFineAsync()
    {
        float speed = rb.velocity.magnitude;

        if (speed >= largeFineSpeed)
        {
            fineClueText.text = "Вы заплатили " + largeFinePrice.ToString() + "$ за столкновение!";
            fineClueText.gameObject.SetActive(true);
            source.PlayOneShot(fineSound);
            moneyManager.GetFine(largeFinePrice);
        }
        else if (speed >= mediumFineSpeed)
        {
            fineClueText.text = "Вы заплатили " + mediumFinePrice.ToString() + "$ за столкновение!";
            fineClueText.gameObject.SetActive(true);
            source.PlayOneShot(fineSound);
            moneyManager.GetFine(mediumFinePrice);
        }
        else if (speed >= smallFineSpeed)
        {
            fineClueText.text = "Вы заплатили " + smallFinePrice.ToString() + "$ за столкновение!";
            fineClueText.gameObject.SetActive(true);
            source.PlayOneShot(fineSound);
            moneyManager.GetFine(smallFinePrice);
        }
        canGetFine = false;

        await new WaitForSeconds(2);

        fineClueText.gameObject.SetActive(false);
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("FineObj"))
        {
            canGetFine = true;
        }
    }
}

