using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGame : MonoBehaviour {

	public GameObject levelManager;



	void OnMouseDown(){
	
		levelManager.GetComponent<LevelManager> ().LoadNextLevel ();
	}
}
