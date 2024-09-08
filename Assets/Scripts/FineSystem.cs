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
    [Space]
    public int zoneFinePrice;
    public int carFinePrice;

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
        if (collision.gameObject.CompareTag("FineObj") && canGetFine)
        {
            if (collision.gameObject.name.Contains("car") && moneyManager.money >= carFinePrice)
            {
                ApplyCarFine();
            }
            else if(!collision.gameObject.name.Contains("car"))
            {
                ApplyDestroyFine();
            }
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.CompareTag("FineObj") && moneyManager.money >= zoneFinePrice)
        {
            ApplyZoneFine();

        }    
    }

    private async void ApplyDestroyFine()
    {
        float speed = rb.velocity.magnitude;

        if (speed >= largeFineSpeed && moneyManager.money >= largeFinePrice)
        {
            fineClueText.text = "�� ��������� " + largeFinePrice.ToString() + "$ �� ������������!";
            fineClueText.gameObject.SetActive(true);
            source.PlayOneShot(fineSound);
            moneyManager.GetFine(largeFinePrice);
        }
        else if (speed >= mediumFineSpeed && moneyManager.money >= mediumFinePrice)
        {
            fineClueText.text = "�� ��������� " + mediumFinePrice.ToString() + "$ �� ������������!";
            fineClueText.gameObject.SetActive(true);
            source.PlayOneShot(fineSound);
            moneyManager.GetFine(mediumFinePrice);
        }
        else if (speed >= smallFineSpeed && moneyManager.money >= smallFinePrice)
        {
            fineClueText.text = "�� ��������� " + smallFinePrice.ToString() + "$ �� ������������!";
            fineClueText.gameObject.SetActive(true);
            source.PlayOneShot(fineSound);
            moneyManager.GetFine(smallFinePrice);
        }
        canGetFine = false;

        await new WaitForSeconds(2);

        fineClueText.gameObject.SetActive(false);
    }

    private async void ApplyZoneFine()
    {

        fineClueText.text = "�� ��������� " + zoneFinePrice.ToString() + "$ �� ������ �� ����������� ����!";
        fineClueText.gameObject.SetActive(true);
        source.PlayOneShot(fineSound);
        moneyManager.GetFine(zoneFinePrice);

        canGetFine = false;

        await new WaitForSeconds(2);

        fineClueText.gameObject.SetActive(false);
    }

    private async void ApplyCarFine()
    {
        fineClueText.text = "�� ��������� " + carFinePrice.ToString() + "$ �� ����������� ����� ������";
        fineClueText.gameObject.SetActive(true);
        source.PlayOneShot(fineSound);
        moneyManager.GetFine(carFinePrice);

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

