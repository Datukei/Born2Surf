using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;

public class CoinCounter : MonoBehaviour
{
   public static CoinCounter Instance;

    public TMP_Text coinText;
    public int currentCoins = 0;

     void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        coinText.text = "Seashells: " + currentCoins.ToString();   
    }

    public void IncreaseCoins(int v)
    {
        currentCoins += v;

        coinText.text = "Seashells: " + currentCoins.ToString();
    
    }





}
