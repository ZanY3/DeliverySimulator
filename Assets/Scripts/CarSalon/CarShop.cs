using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarShop : MonoBehaviour
{
    public bool[] purshashed;
    public int[] carPrices;
    public bool deleteSave = false;
    [Space]
    public TMP_Text clueText;
    public AudioClip buySound;
    public AudioClip errorSound;

    public MoneyManager moneyManager;
    private AudioSource source;


    private void Start()
    {
        source = GetComponent<AudioSource>();
        if(!deleteSave)
        {
            LoadPurchasedCars();
        }
    }

    public async void BuyCar(int index)
    {
        if (!purshashed[index] && moneyManager.money >= carPrices[index])
        {
            moneyManager.MoneyMinus(carPrices[index]);
            purshashed[index] = true;

            SavePurchasedCars();


            source.PlayOneShot(buySound);
            clueText.text = "Вы купили машину, теперь можете ее использовать!";
            clueText.gameObject.SetActive(true);
            await new WaitForSeconds(2);
            clueText.gameObject.SetActive(false);

        }
        else if (purshashed[index])
        {
            source.PlayOneShot(errorSound);

            clueText.text = "Машина уже куплена";
            clueText.gameObject.SetActive(true);
            await new WaitForSeconds(2);
            clueText.gameObject.SetActive(false);
        }    
        else if(moneyManager.money < carPrices[index])
        {
            source.PlayOneShot(errorSound);

            clueText.text = "У вас не хватает денег";
            clueText.gameObject.SetActive(true);
            await new WaitForSeconds(2);
            clueText.gameObject.SetActive(false);
        }
    }

    public async void SelectCar(int index)
    {
        if (purshashed[index])
        {
            SceneManager.LoadScene(index);
        }
        else
        {
            source.PlayOneShot(errorSound);

            clueText.text = "У вас не хватает денег";
            clueText.gameObject.SetActive(true);
            await new WaitForSeconds(2);
            clueText.gameObject.SetActive(false);
        }
    }
    public void SavePurchasedCars()
    {
        string purchasedString = "";

        for (int i = 0; i < purshashed.Length; i++)
        {
            purchasedString += purshashed[i] ? "1" : "0";
        }

        PlayerPrefs.SetString("PurchasedCars", purchasedString);
        PlayerPrefs.Save();
    }

    public void LoadPurchasedCars()
    {
        if (PlayerPrefs.HasKey("PurchasedCars"))
        {
            string purchasedString = PlayerPrefs.GetString("PurchasedCars");

            for (int i = 0; i < purchasedString.Length && i < purshashed.Length; i++)
            {
                purshashed[i] = purchasedString[i] == '1';
            }
        }
    }
}
