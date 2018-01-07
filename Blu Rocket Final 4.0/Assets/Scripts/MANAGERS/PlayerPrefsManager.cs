using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour
{

    const string HighScore_key = "HighScore";
    const string Coins_key = "Coins";

    
    public static void SetHighScore(int score)
    {
        if (score != -1)
        {
            PlayerPrefs.SetInt(HighScore_key, score);
            PlayerPrefs.Save();
            
        }
        else
        {
            Debug.LogError("SetHighScore Failed! with score " + score + " ");
        }
    }
    public static int GetHighScore()
    {
        return PlayerPrefs.GetInt(HighScore_key);
    }



    public static void SetCoins(int coinsPerGame)
    {
        print("CoinsPerGame " + coinsPerGame);
        if (coinsPerGame > 0)
        {
            int currentCoinsStatus = PlayerPrefs.GetInt(Coins_key);
            int newCoinStatus = currentCoinsStatus + coinsPerGame;

            PlayerPrefs.SetInt(Coins_key, newCoinStatus);
            PlayerPrefs.Save();
            print("New Coins " + newCoinStatus);
        }
        else
        {
            Debug.LogError("SetCoins Failed! with Coins " + coinsPerGame + " ");
        
        }
    }
    public static int GetCoins()
    {
        return PlayerPrefs.GetInt(Coins_key);
    }

    public static void setUnlockedItem(string shipName)
    {
        int success = 1;
        if (shipName != null) {
            Debug.Log("Setting "+ shipName+ " Aviability to True" );

            PlayerPrefs.SetInt(shipName, success);
            PlayerPrefs.Save();
        }else{
            Debug.Log("shipName is null");
    }
    }
    public static bool getUnlockedItem(string shipName)
    {
        int currShipAvailability = -1;
        currShipAvailability = PlayerPrefs.GetInt(shipName);
        Debug.Log("evo" + currShipAvailability+"for" + shipName);
        if (currShipAvailability != -1)
        {
            if(currShipAvailability == 1)
            {
                Debug.Log("currShipAvailability == 1 - True");
                return true;
            }else
            {
                Debug.Log("currShipAvailability false");
                return false;
            }

        }else{
            Debug.Log("Availability int is null");
                return false;
        }

        
    }



    public static void setCurrentShip(int currnetShip) {
        if (currnetShip != 0)
        {
            Debug.Log("Current ship setted to:  " + currnetShip );

            PlayerPrefs.SetInt("currentShip", currnetShip);
            PlayerPrefs.Save();
        }
        else
        {
            Debug.Log("currentShip is 0");
        }

    }


    public static int getCurrentShip()
    {
        int currShip = 0;
        currShip = PlayerPrefs.GetInt("currentShip");
        if (currShip != 0)
        {
            return currShip;  
        }
        else
        {

            Debug.Log("currentShip is 0");
            return 1;

        }
    }
    
}
