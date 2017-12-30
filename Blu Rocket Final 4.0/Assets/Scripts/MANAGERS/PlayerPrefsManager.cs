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
    
}
