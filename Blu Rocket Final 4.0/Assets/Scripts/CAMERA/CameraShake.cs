using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour {

	public Transform camTransform;

	public float shakeDuration;

	public float shakeAmount = 0.7f;
	public float decreaseFactor = 1.0f;

	Vector3 originalPos;


	void Awake(){
	
		if (camTransform == null) {
		
			camTransform = GetComponent (typeof(Transform)) as Transform;
		}
	}

	void OnEnable(){
	
		originalPos = camTransform.localPosition;
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

		if (shakeDuration > 0) {
		
			camTransform.localPosition = originalPos + Random.insideUnitSphere * shakeAmount;
			shakeDuration -= Time.deltaTime * decreaseFactor;
		} else {
		
			shakeDuration = 0f;
			camTransform.localPosition = originalPos;
		}
		
	}
}
