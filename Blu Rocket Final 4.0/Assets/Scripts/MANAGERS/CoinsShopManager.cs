using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsShopManager : MonoBehaviour {

    public Text coinsText;
    int coins;
    void Awake() {
        coins = PlayerPrefsManager.GetCoins();

    }

	// Use this for initialization
	void Start () {

        if (coins >= 0)
        {
            coinsText.text = coins.ToString();
        }else
        {
            Debug.LogError("coins is les then 0");
        }
	}
	
	// Update is called once per frame
	void Update () {

        coinsText.text = coins.ToString();
    }
    
}
