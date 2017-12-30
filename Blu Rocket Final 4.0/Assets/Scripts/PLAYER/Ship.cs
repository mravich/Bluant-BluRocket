using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ship : MonoBehaviour {


	//private Movement movement;
	//private ForceManager forceManager;
	public Rigidbody rb;
	public Transform shipTransform;
	public float shipSpeed = 5f;
	private bool isMoving;
	public bool isMovingLeft, isMovingRight,canTeleport,canRotate;
	public float tilt;
	public Vector3 vektor;
	public Vector3 startRotation,currentRotation;
	public Vector3 rayDirection;
	public float angleClamp;
	public Text scoreText;
	public int currentScore, highScore;
	public GameObject button,button2;
	public GameObject camMain;
	public AudioClip hit,scoreSound;
	public ParticleSystem explosion;

	public GameObject ScoreText;


    public int coins;
    public int coinsPerGame;

	// Use this for initialization

	void OnEnable(){
	
		scoreText.text = 0.ToString ();
		currentScore = 0;
	}
	void Awake(){

		// UCITAVANJE MOVEMENT SKRIPTE
		//movement = this.GetComponent<Movement> ();


		// UCITAVANJE RIGIDBODIJA OBJEKTA U OVOM SLUCAJU PLANE-A
		rb = this.GetComponent<Rigidbody>();


		// UCITAVANJE FORCE MANAGERA 
		//forceManager = this.GetComponent<ForceManager> ();

		// UCITAVANJE TRANSFORMA OBJEKTA
		shipTransform = this.transform;


	}

	void Start () {

		canTeleport = true;
		canRotate = true;
		scoreText.text = 0.ToString ();
        highScore = PlayerPrefsManager.GetHighScore();
        coins = PlayerPrefsManager.GetCoins();
		startRotation = shipTransform.eulerAngles;
	    currentRotation = shipTransform.eulerAngles;

        coinsPerGame = 0;

	}




	// Update is called once per frame
	void Update () {
		restrictShipPosition ();
		restrictShipVelocity ();
		teleportShip ();



	}



	void LateUpdate(){
	
		if (isMovingLeft) {

			currentRotation.y = Mathf.Clamp (currentRotation.y + 5f, startRotation.y - angleClamp, startRotation.y + angleClamp);
			shipTransform.localRotation = Quaternion.Euler (currentRotation);
		} else if (isMovingRight) {

			currentRotation.y = Mathf.Clamp (currentRotation.y - 5f, startRotation.y - angleClamp, startRotation.y + angleClamp);
			shipTransform.localRotation = Quaternion.Euler (currentRotation);
		} else {
		
			currentRotation.y = Mathf.Lerp (currentRotation.y, 0f, 0.2f);
			shipTransform.localRotation = Quaternion.Euler (currentRotation);
		
		}
	
	}








	void FixedUpdate(){
		
		Vector3 currentRotation = shipTransform.localRotation.eulerAngles;
		float angle;
		if (isMovingLeft) {

			rb.AddForce (new Vector3 (-0.01f*shipSpeed, 0f, 0f), ForceMode.Impulse);


			/* RADI ALI NE DOBRO
			angle = Mathf.LerpAngle(0, 40, Time.deltaTime);
			shipTransform.Rotate(Vector3.up, angle);
			*/


		} else if (isMovingRight) {
			
	
			rb.AddForce (new Vector3 (0.01f*shipSpeed, 0f, 0f), ForceMode.Impulse);

			/*RADI ALI NE DOBRO 
			angle = Mathf.LerpAngle(0, -40, Time.deltaTime);
			shipTransform.Rotate(Vector3.up, angle);
			*/

		} else {
		
			rb.velocity = Vector3.Lerp (rb.velocity, Vector3.zero, 6f * Time.deltaTime);
			//currentRotation.y = Mathf.Lerp (currentRotation.y, 0f, 0.2f);
			//shipTransform.localRotation = Quaternion.Euler (currentRotation);



		
		}



		


	}






















	public void MoveShip(bool left, bool right){

		if (left) {


			isMovingLeft = left;
			isMovingRight = right;
		} else if (right) {


			isMovingLeft = left;
			isMovingRight = right;
		}

	}
	public void StopShip(){
		isMovingLeft = false;
		isMovingRight = false;

	
	}

	public void restrictShipPosition(){
		Transform transform = getTransformOfObject ();
		Vector3 currentPosition = new Vector3(Mathf.Clamp(transform.position.x,-36.5f,36.5f),transform.position.y,transform.position.z);
		transform.position = currentPosition;

	}
	public void restrictShipVelocity(){

		//RESTRICT ROTATION


		//srb.velocity = new Vector2 (Mathf.Clamp (rb.velocity.x, -25f, 25f), 0f); 
	}

	public Transform getTransformOfObject(){
		Transform transform = this.GetComponent<Transform> ();
		return transform;

	}

	public void teleportShip(){

		Vector3 currentPosition = transform.position;
		float currentx = currentPosition.x;
		if (currentx >= -36f && currentx <=36f) {
			canTeleport = true;
		}
		if (currentx <= -36.1f || currentx >= 36.1f) {
		
			if (canTeleport) {
				Vector3 newPosition = new Vector3 (currentx*-1f, currentPosition.y, currentPosition.z);
				shipTransform.position = newPosition;
				canTeleport = false;
			}


		}
	
	}


	void OnTriggerEnter(Collider coll){
		
		if (coll.tag == "Cube") {
           
            //make new script for this Void

            

			Instantiate (explosion, transform.position, Quaternion.identity);

			button.SetActive (true);
			button2.SetActive (true);
			//Handheld.Vibrate();
			camMain.GetComponent<CameraShake> ().shakeDuration = 0.15f;
			AudioSource.PlayClipAtPoint (hit,camMain.transform.position);

			GameObject scoreSprite = Instantiate (ScoreText, transform.position, Quaternion.identity);
			AudioSource.PlayClipAtPoint (scoreSound,camMain.transform.position);
			gameObject.SetActive (false);
		} else if (coll.tag == "Row") {
			
			currentScore++;
			if (currentScore > highScore) {
			
				highScore = currentScore;
                
                PlayerPrefsManager.SetHighScore(highScore);
                
			}

            //Set Coins

            coinsPerGame++;
            PlayerPrefsManager.SetCoins(coinsPerGame);

            ///////////////

            scoreText.text = currentScore.ToString ();

		} 


	

	}
}
