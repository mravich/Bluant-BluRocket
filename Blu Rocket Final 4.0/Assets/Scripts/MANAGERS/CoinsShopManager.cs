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

    public void BuyItem()
    {
        int currPrice = 0;
        string currName = "";
        currPrice = GameObject.Find("CoinsShopManager").GetComponent<ShopItemsManager>().selectedItemPrice;
        currName = GameObject.Find("CoinsShopManager").GetComponent<ShopItemsManager>().selectedItemName;
        Debug.Log("Buy Item name: " + currName + " , item price: " + currPrice);
        if (coins >= currPrice && currName != "")
        {
            PlayerPrefsManager.setUnlockedItem(currName);
            coins -= currPrice;
            GameObject.Find("CoinsShopManager").GetComponent<ShopItemsManager>().selectedItemAvaliability = true;




        }
        else
        {
            Debug.Log("U have no enought money! Your balance is : " + coins);
        }
    }

    
}
