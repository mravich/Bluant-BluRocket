using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RowFinal : MonoBehaviour {

 
    void OnTriggerEnter(Collider col) {

        print("Zid je sudaren");

    }


	void Update () {


}

	public void DestroySelf(){
	
		Destroy (gameObject);
	}
}
