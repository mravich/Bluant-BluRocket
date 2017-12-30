using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManger : MonoBehaviour {

	public GameObject player;

	public GameObject rowManager;
	// Use this for initialization
	void Start () {
		
	}
	
	void Update () {


	}

	public void RestartGame(){

			player.SetActive (true);
			
		foreach (Transform obj in rowManager.transform) {
		
			obj.GetComponent<RowFinal> ().DestroySelf ();
		}
	}
}
