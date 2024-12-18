using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CollectCoins : MonoBehaviour
{
    public TextMeshProUGUI CoinCount;
    public int CoinAmount;


    void Update()
    {
        CoinCount.text = CoinAmount.ToString("D2");
    }
}
