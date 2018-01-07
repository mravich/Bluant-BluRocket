using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShop : MonoBehaviour {


	public float angleClamp;

	public Transform shipTransform;
	public Vector3 startRotation,currentRotation;

	void Start(){
		shipTransform = this.transform;
		startRotation = shipTransform.eulerAngles;
		currentRotation = shipTransform.eulerAngles;
	}


	void LateUpdate(){

		if (Input.GetKey(KeyCode.LeftArrow)) {

			currentRotation.y = Mathf.Clamp (currentRotation.y + 5f, startRotation.y - angleClamp, startRotation.y + angleClamp);
			shipTransform.localRotation = Quaternion.Euler (currentRotation);
		} else if (Input.GetKey(KeyCode.RightArrow)) {
			currentRotation.y = Mathf.Clamp (currentRotation.y - 5f, startRotation.y - angleClamp, startRotation.y + angleClamp);
			shipTransform.localRotation = Quaternion.Euler (currentRotation);
		} else {
			currentRotation.y = Mathf.Lerp (currentRotation.y, 0f, 0.001f);
			currentRotation.z = 0f;
			shipTransform.localRotation = Quaternion.Euler (currentRotation);

		}

	}


}
