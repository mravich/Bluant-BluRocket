using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreHandler : MonoBehaviour {
	public int highScore;
	public Text score;
	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("HighScore");
		score.text = highScore.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
