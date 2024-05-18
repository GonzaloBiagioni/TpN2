using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MonedaContador : MonoBehaviour
{
    public static MonedaContador Instance;
    public Text coinText;
    public int currentCoin = 0;

    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        coinText.text = "Monedas: " + currentCoin.ToString();
    }

    public void IncreaseCoin(int v)
    {
        currentCoin += v;
        coinText.text = "Monedas: " + currentCoin.ToString();
    }

}
