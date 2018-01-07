using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;
using System;

public class FacebookManager : MonoBehaviour {

	// CREATE INSTANCE TO THE SCRIPT
	private static FacebookManager _instance;

	public static FacebookManager Instance{

		get{ 
			// IF there is currently no instance create instance
			if (_instance == null) {			
				GameObject facebookManager = new GameObject ("FBManager");
				facebookManager.AddComponent<FacebookManager> ();
			}
			return _instance;
		}

	}

	public bool IsLoggedIn{ get; set;}
	public string ProfileName{ get; set;}
	public Sprite ProfilePic{ get; set;}
	public string AppLinkURL{ get; set;}


	void Awake(){
		DontDestroyOnLoad (this.gameObject);
		_instance = this;
		IsLoggedIn = true;
	}

	// INITALIZATION OF FACEBOOK
	public void InitFB(){

		// IF NOT INITIALIZED CALL CALLBACK
		if (!FB.IsInitialized) {
			FB.Init (SetInit, OnHideUnity);

		} else {
			IsLoggedIn = FB.IsLoggedIn;
		}
	}

	void SetInit(){

		//IF FACEBOOK IS LOGGED IN 
		if (FB.IsLoggedIn) {
			Debug.Log ("FB IS LOGGED IN");
			GetProfile ();
		} else {
			Debug.Log ("FB IS NOT LOGGED IN");
		}
		IsLoggedIn = FB.IsLoggedIn;
	}

	void OnHideUnity(bool isGameShown){

		//IF GAME ISN't SHOWN
		if (!isGameShown) {

			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;

		}
	}

	public void GetProfile(){
		// GET USERNAME OF USER
		FB.API ("/me?fields=first_name", HttpMethod.GET, DisplayUsername);
		// GET PROFILE PICTURE OF USER
		FB.API("/me/picture?type=square&height=128&width=128",HttpMethod.GET,DisplayProfilePic);
		FB.GetAppLink (DealWithAppLink);
	}

	void DisplayUsername(IResult result){	
		if (result.Error == null) {
			ProfileName = "" + result.ResultDictionary ["first_name"];
		} else {
			Debug.Log (result.Error);
		}
	}

	void DisplayProfilePic(IGraphResult result){
		if (result.Texture != null) {
			ProfilePic = Sprite.Create (result.Texture, new Rect (0, 0, 128, 128), new Vector2 ());
		} 
	}

	void DealWithAppLink(IAppLinkResult result){
	
		if (!string.IsNullOrEmpty (result.Url)) {
			AppLinkURL = "" + result.Url + "";
			Debug.Log (AppLinkURL);
		} else {
		
			AppLinkURL = "Http://google.com";
		}
	}

	public void Share(){
		FB.FeedShare(
		
			string.Empty,
			new Uri(AppLinkURL),
			"Hello this is the title",
			"This is the caption",
			"Check out this game",
			new Uri("https://fsmedia.imgix.net/2c/f5/26/db/9e29/4942/8346/56ab9d4ef426/the-soyuz-tma-19m-rocket-with-expedition-46-soyuz-commander-yuri-malenchenko-of-the-russian-federal.jpeg"),
			string.Empty, 
			ShareCallback
		);
	}
		

	void ShareCallback(IResult result){
		if (result.Cancelled) {
			Debug.Log ("Share canceled");		
		} else if (!string.IsNullOrEmpty (result.Error)) {		
			Debug.Log ("Error on share!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("success on share");
		}
	}

	public void Invite(){
	
		FB.Mobile.AppInvite (
		
			new Uri(AppLinkURL),
			new Uri("https://fsmedia.imgix.net/2c/f5/26/db/9e29/4942/8346/56ab9d4ef426/the-soyuz-tma-19m-rocket-with-expedition-46-soyuz-commander-yuri-malenchenko-of-the-russian-federal.jpeg"),
			InviteCallback

		);
	}

	void InviteCallback(IResult result){

		if (result.Cancelled) {
			Debug.Log ("Invite canceled");		
		} else if (!string.IsNullOrEmpty (result.Error)) {		
			Debug.Log ("Error on invite!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("Success on invite");
		}
	}

	public void ShareWithUsers(){

		FB.AppRequest (
			"Come and join me, I bet you can't beat my highscore",
			null,
			new List<object>(){"app_users"},
			null,
			null,
			null,
			null,
			ShareWithUsersCallback
		);
	}
			
	void ShareWithUsersCallback(IAppRequestResult result){
	
		if (result.Cancelled) {
			Debug.Log ("Challenge a friend - canceled");		
		} else if (!string.IsNullOrEmpty (result.Error)) {		
			Debug.Log ("Error on challenging a friend!");
		} else if (!string.IsNullOrEmpty (result.RawResult)) {
			Debug.Log ("Success on challenging a friend");
		}
	}
}
