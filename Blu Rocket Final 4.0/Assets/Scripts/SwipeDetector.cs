using UnityEngine;
using System.Collections;

public class SwipeDetector : MonoBehaviour {


	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;
	private string myString = " no move";

	public float gestureTime;



	void OnGUI() {
		GUI.color = Color.black;
		GUI.Label(new Rect(10, 10, 100, 100), myString);

	}


	// Update is called once per frame
	void Update () {

		if (Input.touchCount > 0){

			foreach (Touch touch in Input.touches)
			{
				switch (touch.phase)
				{
				case TouchPhase.Began :
					/* this is a new touch */
					isSwipe = true;
					fingerStartTime = Time.time;
					fingerStartPos = touch.position;
					break;

				case TouchPhase.Canceled :
					/* The touch is being canceled */
					isSwipe = false;
					break;

				case TouchPhase.Ended :

					gestureTime = Time.time - fingerStartTime;
					float gestureDist = (touch.position - fingerStartPos).magnitude;

					if (isSwipe && gestureTime < maxSwipeTime && gestureDist > minSwipeDist){
						Vector2 direction = touch.position - fingerStartPos;
						Vector2 swipeType = Vector2.zero;

						if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y)){
							// the swipe is horizontal:
							swipeType = Vector2.right * Mathf.Sign(direction.x);
						}else{
							// the swipe is vertical:
							swipeType = Vector2.up * Mathf.Sign(direction.y);
						}

						if(swipeType.x != 0.0f){
							if(swipeType.x > 0.0f){
								myString = "ROTATE RIGHT";
								transform.RotateAround(transform.position, transform.up, Time.deltaTime * 90f);
								//rb.AddForce (Vector3.right*(force/gestureTime),ForceMode.Impulse);
							}else{
								myString = "ROTATE LEFT";
								//rb.AddForce (Vector3.left*(force/gestureTime),ForceMode.Impulse);
								transform.RotateAround(transform.position, transform.up, Time.deltaTime * -90f);

							}
						}

					

					}

					break;
				}
			}
		}

	}

}