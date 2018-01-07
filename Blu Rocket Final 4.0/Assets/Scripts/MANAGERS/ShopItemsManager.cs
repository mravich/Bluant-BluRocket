using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemsManager : MonoBehaviour {


	public Text selectedItemPriceText;
	public int curSelectedItemPrice;
	public int selectedItemPrice;
	public string selectedItemName;
	public bool selectedItemAvaliability;
	public Image lockAviability;
	public Button setCurrentShip;

	public GameObject ship0body;
	public GameObject ship1body;
	public GameObject ship2body;

	int currnetItemNum = 1;

	Material[] set0= new Material[2];
	Material[] set1 = new Material[2];
	Material[] set2 = new Material[2];
	public static Object[] materials1;
	public static Object[] materials2;
	public static Object[] materials3;
	public static Object[] materials4;
	public static Object[] materials5;
	public static Object[] materials6;
	public static Object[] materials7;
	public static Object[] materials8;
	public static Object[] materials9;
	public static Object[] materials10;

	private static ShopItemsManager _instance;


	// SWIPE 
	private float fingerStartTime  = 0.0f;
	private Vector2 fingerStartPos = Vector2.zero;

	private bool isSwipe = false;
	private float minSwipeDist  = 50.0f;
	private float maxSwipeTime = 0.5f;
	private string myString = " no move";
	public Text gestureText;
	public float gestureTime;


	//TOODOO: check if Instance is needed or not for this script
	public static ShopItemsManager Instance
	{

		get
		{
			// IF there is currently no instance create instance
			if (_instance == null)
			{
				GameObject ShopItemsManager = new GameObject("ShopItemsManager");
				ShopItemsManager.AddComponent<ShopItemsManager>();
			}
			return _instance;
		}

	}

	// Use this for initialization
	void Start () {
		currnetItemNum = PlayerPrefsManager.getCurrentShip();
		//getting materials from Resoursec Folder
		setMatererialsFromResources();

		//set first sets of Materials
		checkSwipe(); 

	}

	// Update is called once per frame
	void Update()
	{

		// CHECK FOR SWIPE

		checkForUserSwipe ();


		if (set0[0] != null && set1[1] != null && set2 != null)
		{
			//setting sets to manakens 
			ship0body.GetComponent<Renderer>().materials = set0;
			ship1body.GetComponent<Renderer>().materials = set1;
			ship2body.GetComponent<Renderer>().materials = set2;

			//checking for a lock image
			if (selectedItemAvaliability)
			{

				lockAviability.enabled = false;

				setCurrentShip.gameObject.SetActive(true);

			}
			else
			{
				lockAviability.enabled = true;

				setCurrentShip.gameObject.SetActive(false);



			}
		}



	}

	public void checkForUserSwipe(){
	
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
								gestureText.text = "RIGHT";
								swipeRight ();

							}else{
								myString = "ROTATE LEFT";
								gestureText.text = "Left";
								swipeLeft ();


							}
						}



					}

					break;
				}
			}
		}
	}

	public void checkSwipe()
	{


		switch (currnetItemNum)
		{

		case 0:


			break;

		case 1:
			//settings Material sets for 3 manakens to show
			set0 = SetTexture("rocket10");
			set1 = SetTexture("rocket1");

			//saving current " MIDDLE " item price 
			selectedItemPrice = curSelectedItemPrice ;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket1";

			//

			set2 = SetTexture("rocket2");

			//checking do u have it unlocked or not
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket1");
			Debug.Log("evo" + selectedItemAvaliability);


			//  currnetItemNum++;

			break;

		case 2:
			set0 = SetTexture("rocket1");
			set1 = SetTexture("rocket2");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket2";

			set2 = SetTexture("rocket3");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket2");
			Debug.Log("evo" + selectedItemAvaliability);

			//   currnetItemNum++;

			break;
		case 3:
			set0 = SetTexture("rocket2");
			set1 = SetTexture("rocket3");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket3";

			set2 = SetTexture("rocket4");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket3");
			Debug.Log("evo" + selectedItemAvaliability);

			//    currnetItemNum++;

			break;
		case 4:
			set0 = SetTexture("rocket3");
			set1 = SetTexture("rocket4");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket4";

			set2 = SetTexture("rocket5");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket4");
			Debug.Log("evo" + selectedItemAvaliability);

			//     currnetItemNum++;

			break;
		case 5:
			set0 = SetTexture("rocket4");
			set1 = SetTexture("rocket5");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket5";

			set2 = SetTexture("rocket6");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket5");
			Debug.Log("evo" + selectedItemAvaliability);

			//       currnetItemNum++;

			break;
		case 6:

			set0 = SetTexture("rocket5");
			set1 = SetTexture("rocket6");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket6";

			set2 = SetTexture("rocket7");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket6");
			Debug.Log("evo" + selectedItemAvaliability);

			//     currnetItemNum++;

			break;
		case 7:
			set0 = SetTexture("rocket6");
			set1 = SetTexture("rocket7");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket7";

			set2 = SetTexture("rocket8");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket7");
			Debug.Log("evo" + selectedItemAvaliability);

			//   currnetItemNum++;

			break;
		case 8:
			set0 = SetTexture("rocket7");
			set1 = SetTexture("rocket8");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket8";

			set2 = SetTexture("rocket9");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket8");
			Debug.Log("evo" + selectedItemAvaliability);

			//     currnetItemNum++;

			break;
		case 9:
			set0 = SetTexture("rocket8");
			set1 = SetTexture("rocket9");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket9";

			set2 = SetTexture("rocket10");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket9");
			Debug.Log("evo" + selectedItemAvaliability);

			//       currnetItemNum++;
			break;
		case 10:
			set0 = SetTexture("rocket9");
			set1 = SetTexture("rocket10");

			selectedItemPrice = curSelectedItemPrice;
			selectedItemPriceText.text = selectedItemPrice.ToString();
			selectedItemName = "rocket10";

			set2 = SetTexture("rocket1");
			selectedItemAvaliability = PlayerPrefsManager.getUnlockedItem("rocket10");
			Debug.Log("evo" + selectedItemAvaliability);

			//      currnetItemNum = 1;

			break;




		}
		//  selectedItemPriceText.text = selectedItemPrice.ToString();
	}


	public Material[] SetTexture(string name)
	{

		//selectedItemName = name;
		Material[] currentSet = new Material[2];
		switch (name)
		{
		case "rocket1":
			currentSet[0] = (Material) materials1[0];
			currentSet[1] = (Material)materials1[1];
			curSelectedItemPrice = 1;


			return currentSet;
			break;

		case "rocket2":
			currentSet[0] = (Material)materials2[0];
			currentSet[1] = (Material)materials2[1];
			curSelectedItemPrice = 22;
			return currentSet;
			break;

		case "rocket3":
			currentSet[0] = (Material)materials3[0];
			currentSet[1] = (Material)materials3[1];
			curSelectedItemPrice = 33;
			return currentSet;
			break;

		case "rocket4":
			currentSet[0] = (Material)materials4[0];
			currentSet[1] = (Material)materials4[1];
			curSelectedItemPrice = 14;
			return currentSet;
			break;

		case "rocket5":
			currentSet[0] = (Material)materials5[0];
			currentSet[1] = (Material)materials5[1];
			curSelectedItemPrice = 15;
			return currentSet;
			break;

		case "rocket6":
			currentSet[0] = (Material)materials6[0];
			currentSet[1] = (Material)materials6[1];
			curSelectedItemPrice = 26;
			return currentSet;
			break;

		case "rocket7":
			currentSet[0] = (Material)materials7[0];
			currentSet[1] = (Material)materials7[1];
			curSelectedItemPrice = 17;
			return currentSet;
			break;

		case "rocket8":
			currentSet[0] = (Material)materials8[0];
			currentSet[1] = (Material)materials8[1];
			curSelectedItemPrice = 18;
			return currentSet;
			break;

		case "rocket9":
			currentSet[0] = (Material)materials9[0];
			currentSet[1] = (Material)materials9[1];
			curSelectedItemPrice = 19;
			return currentSet;
			break;

		case "rocket10":
			currentSet[0] = (Material)materials10[0];
			currentSet[1] = (Material)materials10[1];
			curSelectedItemPrice = 1000;
			return currentSet;
			break;




		}
		return currentSet;
	}

	public void setMatererialsFromResources()
	{
		materials1 = Resources.LoadAll("Material/Rocket_1", typeof(Material));
		materials2 = Resources.LoadAll("Material/Rocket_2", typeof(Material));
		materials3 = Resources.LoadAll("Material/Rocket_3", typeof(Material));
		materials4 = Resources.LoadAll("Material/Rocket_4", typeof(Material));
		materials5 = Resources.LoadAll("Material/Rocket_5", typeof(Material));
		materials6 = Resources.LoadAll("Material/Rocket_6", typeof(Material));
		materials7 = Resources.LoadAll("Material/Rocket_7", typeof(Material));
		materials8 = Resources.LoadAll("Material/Rocket_8", typeof(Material));
		materials9 = Resources.LoadAll("Material/Rocket_9", typeof(Material));
		materials10 = Resources.LoadAll("Material/Rocket_10", typeof(Material));



	}
	public void selectCurrentShip()
	{


		PlayerPrefsManager.setCurrentShip(currnetItemNum);

	}

	public void swipeRight()
	{
		Debug.Log("prije: " + currnetItemNum);
		if(currnetItemNum == 10) {
			currnetItemNum = 1;
			checkSwipe();

		}else
		{
			currnetItemNum++;
			checkSwipe();
		}
		Debug.Log("poslje: " + currnetItemNum);
	}
	public void swipeLeft()
	{
		Debug.Log("prije: " + currnetItemNum);
		if (currnetItemNum == 1)
		{
			currnetItemNum = 10;
			checkSwipe();
		}
		else
		{

			currnetItemNum--;
			checkSwipe();
		}
		Debug.Log("poslje: " + currnetItemNum);
	}


}
