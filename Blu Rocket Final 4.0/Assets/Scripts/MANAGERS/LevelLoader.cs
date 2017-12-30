using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class LevelLoader : MonoBehaviour {

	public Slider slider;

	public void LoadLevel(int sceneIndex){

		StartCoroutine(LoadAsynchronously(sceneIndex));
	}

	IEnumerator LoadAsynchronously(int sceneIndex){

		AsyncOperation loadingOperation = SceneManager.LoadSceneAsync (sceneIndex);

		while (!loadingOperation.isDone) {
		
			float progress = Mathf.Clamp01 (loadingOperation.progress/0.9f);
			slider.value = progress;
			yield return null;
		}
	}
}
