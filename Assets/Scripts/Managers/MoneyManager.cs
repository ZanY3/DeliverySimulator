using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{
    public TMP_Text moneyText;

    public int money = 0;

    private void Start()
    {
        Load();
    }

    public void MoneyPlus(int count)
    {
        money += count;
        moneyText.text = money.ToString();
        Save();
    }    
    public void GetFine(int count)
    {
        money -= count;
        moneyText.text = money.ToString();
        Save();
    }

    public void Save()
    {
        PlayerPrefs.SetInt("MoneyCount", money);
    }

    public void Load()
    {
        money = PlayerPrefs.GetInt("MoneyCount", 0); // Присваиваем результат переменной money
        moneyText.text = money.ToString();
    }

}
