using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputController : MonoBehaviour {


	//DEFINIRAMO SHIP GAMEOBJEKT KAKO BI MOGLI KORISTITI NJEGOVU METHODU MOVE.SHIP()
	public GameObject ship;

	// VARIJABLA POTREBNA KAKO BI ODREDILI STRANU U KOJU MICEMO AVION U SLUCAJU OBJE TIPKE STISNUTE
	public float direction=1;

	// BOOLEOVI ZA PROVJERU INPUTA 
	public bool directionLeft,directionRight;

	// BOOL ZA PROVJERU KADA SU STISNUTE OBJE TIPKE
	public bool bothPressed;

	private float screenPositionX;
	private Touch firstTouch,secondTouch;

	private bool twoTouch;
	// AWAKE STANJE OBJEKTA
	private int fingerCount;


	private int currentActiveFingerZeroID,currentActiveFingerOneID;
	private string message,message1,message2,message3;

	private Touch lastTouch;
	private int LastFingerIndex;
	public GameObject player;
	void Awake(){


	}

	void Start(){

		screenPositionX = Screen.width * .5f;
	}



	// Update is called once per frame
	void Update () {


		//TouchMovement ();
		computerControls();

	




    }

	/*void OnGUI(){
	

		
			GUI.Label (new Rect (10, 60, 600, 20), message );
			GUI.Label (new Rect (10, 70, 600, 20), message1 );
			GUI.Label (new Rect (10, 80, 600, 20), message2 );
			GUI.Label (new Rect (10, 90, 600, 20), message3 );
		if (Input.touchCount > 0) {
			GUI.Label (new Rect (10, 50, 600, 20), "Prvi Touch je : " + currentActiveFingerZeroID + " njegov x je :  " + Input.GetTouch(0).position.x);
			GUI.Label (new Rect (10, 40, 600, 20), "Drugi Touch je : " + currentActiveFingerOneID + " njegov x je :  " + Input.GetTouch(1).position.x);
		
		}
			
			
			




	}*/

	void TouchMovement(){
		float ScreenMid = Screen.width / 2;
		for(int i = 0; i < Input.touchCount; i++){
			if(Input.touches[i].phase == TouchPhase.Began){
				LastFingerIndex = Input.touches[i].fingerId;
			}
			if(Input.touches[i].phase == TouchPhase.Ended){
				lastTouch = Input.touches[LastFingerIndex - 1];
			}else{
				lastTouch = Input.touches[LastFingerIndex];
			}
		}

		if(lastTouch.position.x < ScreenMid){
			ship.GetComponent<Ship> ().MoveShip (true, false);

		}else{
			ship.GetComponent<Ship> ().MoveShip (false, true);
		}

		if(Input.touchCount == 0){
			ship.GetComponent<Ship>().StopShip();
		}

	}







    

    void computerControls() {
        // SVAKI FREJM PROVJERAVAMO INPUT I SETTAMO VARIJABLE NA TRUE ILI FALSE
        directionLeft = Input.GetKey(KeyCode.LeftArrow);
        directionRight = Input.GetKey(KeyCode.RightArrow);



        // PROVJERAVAMO AKO JE JEDNA OD VARIJABLI SMJERA TRUE
        if (directionLeft || directionRight)
        {

            // PROVJERAVAMO AKO SU OBJE VARIJABLE SMJERA TRUE
            if (directionLeft && directionRight)
            {

                // SETTAMO BOTHPRESSED VARIJABLU KOJA NAM JE POTREBNA U SLJEDECOJ PROVJERI
                bothPressed = true;

                // PROVJERAVAMO AKO SU OBJE TIPKE STISNUTE I SMJER KOJI JE TRENUTNO UKLJUCEN JE DESNO
                if (bothPressed && (direction == 1f))
                {

                    // POZIVAMO METODU ZA POMICANJE SHIPA NA SHIP SKRIPTI TE SALJEMO VRIJEDNOSTI BOOLEOVA 
                    ship.GetComponent<Ship>().MoveShip(true, false);

                }

                // PROVJERAVAMO AKO SU OBJE TIPKE STISNUTE I SMJER KOJI JE TRENUTNO UKLJUCEN JE LIJEVO
                else if (bothPressed && (direction == -1f))
                {

                    // POZIVAMO METODU ZA POMICANJE SHIPA NA SHIP SKRIPTI TE SALJEMO VRIJEDNOSTI BOOLEOVA 
                    ship.GetComponent<Ship>().MoveShip(false, true);
                }

            }

            // PROVJERAVAMO KOJA JE OD SMJEROVA STISNUT
            else if (directionLeft)
            {
                // AKO JE STISNUTO LIJEVO

                bothPressed = false;
                direction = -1f;

                ship.GetComponent<Ship>().MoveShip(true, false);

            }
            else
            {
                // AKO JE STISNUTO DESNO

                bothPressed = false;
                direction = 1f;

                ship.GetComponent<Ship>().MoveShip(false, true);
            }



        }

        // AKO NEMA INPUTA 
        else
        {
            // ZAUSTAVI BROD

            ship.GetComponent<Ship>().StopShip();
            bothPressed = false;
        }

    }

}
