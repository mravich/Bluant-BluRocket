﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButton : MonoBehaviour {


	void OnMouseDown(){

		SceneManager.LoadScene ("StartGame");
	}
}
