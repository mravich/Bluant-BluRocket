using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TurnOffSound : MonoBehaviour {

     private Sprite spriteComponent;
     public GameObject splashAudio;
    public Sprite volumeOn, volumeOff;

    
    void Start() {
        //TO DO GET OPTION FROM PLAYER PREFS
        // GET SPRITE COMPONENT FROM CURRENT GAMEOBJECT
         spriteComponent = GetComponent<Image>().sprite;
        // SET SPRITE VALUE
        spriteComponent = volumeOn;
        // SET SPRITE COMPONENT
        GetComponent<Image>().sprite = spriteComponent;
    }

    public void touchButton() {
        print("ugasi zvuk");
        //splashAudio = GameObject.Find("PersistentMusicManager");
        // print("nasao sam PMM" + splashAudio.name);
        //MusicManager newMusicManager = splashAudio.GetComponent<MusicManager>();
        //newMusicManager.StopMusic();

        // GET SPRITE COMPONENT FROM CURRENT GAMEOBJECT
        Sprite currentSprite = GetComponent<Image>().sprite;
        print(currentSprite);
        if (currentSprite == volumeOn)
        {
            // SET SPRITE VALUE
            currentSprite = volumeOff;
        }
        else {
            // SET SPRITE VALUE
            currentSprite = volumeOn;
        }
        // SET SPRITE COMPONENT
        GetComponent<Image>().sprite = currentSprite;

   

    }

    
}
