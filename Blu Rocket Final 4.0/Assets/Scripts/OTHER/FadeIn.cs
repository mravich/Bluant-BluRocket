using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;



public class FadeIn : MonoBehaviour {


	public float FadeInTime, FadeOutTime;

	private Image fadePanel;

	private Color currentColor = Color.black;


	// Use this for initialization
	void Start () {

		fadePanel = GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (Time.timeSinceLevelLoad < FadeInTime) {
		
			//Fade in
			float alphaChange = Time.deltaTime / FadeInTime;
			currentColor.a -= alphaChange;
			fadePanel.color = currentColor;

		} else if(Time.timeSinceLevelLoad> FadeOutTime){
			if (FadeOutTime != 0) {
				//Fade out
				float alphaChange = Time.deltaTime / FadeInTime;
				currentColor.a += alphaChange;
				fadePanel.color = currentColor;

			}


		}
		
	}
}
