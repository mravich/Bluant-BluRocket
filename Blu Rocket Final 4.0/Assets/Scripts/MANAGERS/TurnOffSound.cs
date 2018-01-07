using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnOffSound : MonoBehaviour {

     public GameObject splashAudio;

    public void touchButton() {
        print("ugasi zvuk");
        splashAudio = GameObject.Find("PersistentMusicManager");
        print("nasao sam PMM" + splashAudio.name);
        MusicManager newMusicManager = splashAudio.GetComponent<MusicManager>();
        newMusicManager.StopMusic();

        
    }
}
