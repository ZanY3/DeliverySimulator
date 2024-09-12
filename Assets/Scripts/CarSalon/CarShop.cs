using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CarShop : MonoBehaviour
{
    public void SelectCar(int index)
    {
        SceneManager.LoadScene(index);
    }
}
