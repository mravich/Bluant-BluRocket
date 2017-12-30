using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollingObject : MonoBehaviour 
{
	
	public float speed;

	public Renderer rend;

	// Use this for initialization
	void Start () 
	{
		rend = GetComponent<Renderer> ();
	}

	void Update(){
	
		float offset = Time.time * speed;	
		rend.material.SetTextureOffset ("_MainTex", new Vector2 (0,offset ));
	}


}