using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {


	public AudioClip[] levelMusicChangeArray;
	private AudioSource audioSource;

	void Awake(){
	
		DontDestroyOnLoad (gameObject);
		Debug.Log ("Don't destroy on load: " + gameObject);
	}
	// Use this for initialization
	void Start () {

		audioSource = GetComponent<AudioSource> ();
	}

    public void StopMusic()
    {
        print("Stop playing music");
        audioSource.Stop();
        print("prestala je muzika");
    }


	void OnLevelWasLoaded(int level){

		AudioClip currentLevelMusic = levelMusicChangeArray [level];
	
		Debug.Log ("Playing clip : " + currentLevelMusic);

		if (currentLevelMusic) { //IF there is some music 
		
			audioSource.clip = currentLevelMusic;
			audioSource.loop = true;
			audioSource.Play ();

		}
	}



}
