using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Facebook.Unity;
using System.Collections.Generic;
using UnityEngine.UI;
using System;
using UnityEngine.SceneManagement;

public class FBscript : MonoBehaviour {


	public GameObject DialogLoggedIn;
	public GameObject DialogLoggedOut;
	public GameObject DialogUsername;
	public GameObject DialogProfilePic;
    public GameObject Login_Leaderboard;
    public Sprite leagerbordImage;
    public Sprite facebookImage;


  //  public Text DebugScores;
    private List<object> scoresList = null;


    
    int rand = 10;
    Image FuserAvatar;


    




    //Istance 
    private static FBscript _instance;

    public static FBscript Instance
    {

        get
        {
            // IF there is currently no instance create instance
            if (_instance == null)
            {
                GameObject FBscript = new GameObject("FBscript");
                FBscript.AddComponent<FBscript>();
            }
            return _instance;
        }

    }



    ////////

    void Awake()
    {
        Scene scene = SceneManager.GetActiveScene();
        if (scene.name == "StartGame")
        {

        FuserAvatar = Login_Leaderboard.GetComponent<Image>();
        
        
        DealWithFBMenus(FB.IsLoggedIn);
        }
        FacebookManager.Instance.InitFB();
    }




    public void FBlogin(){

        if (!FB.IsLoggedIn)
        {
            // LISTA PERMISSIONSA 
            List<string> permissions = new List<string>();
            //
            // TOODOO: CHECK PERMISIONS .. 
            //

            //permissions.Add ("public_profile");
            permissions.Add("publish_actions");
            FB.LogInWithReadPermissions(permissions, AuthCallBack);
        }else
        {
            SceneManager.LoadScene("Leaderboard");
        }
	}

	//THIS FIRES WHEN LOGIN IS CALLED
	void AuthCallBack(IResult result){

		//IF THERE IS AN ERROR
		if (result.Error != null) {
		
			Debug.Log (result.Error);
		} else {
			if (FB.IsLoggedIn) {
				FacebookManager.Instance.IsLoggedIn = true;
				FacebookManager.Instance.GetProfile ();
				Debug.Log ("FB IS LOGGED IN");
			} else {
				Debug.Log ("FB IS NOT LOGGED IN");
			}

			DealWithFBMenus (FB.IsLoggedIn);
		}
	}

	// DEAL WITH MENUS 
	void DealWithFBMenus(bool isLoggedIn){
        if (FB.IsLoggedIn)
        {
            FuserAvatar.sprite = leagerbordImage;


            DialogLoggedIn.SetActive(true);
            DialogLoggedOut.SetActive(false);
            // CHECK IF THE PROFILE NAME IS SET
            if (FacebookManager.Instance.ProfileName != null)
            {
                Text UserName = DialogUsername.GetComponent<Text>();
                UserName.text = "Hi, " + FacebookManager.Instance.ProfileName;
            }
            else
            {
                // IF THERE IS NO PROFILE NAME
                StartCoroutine("WaitForProfileName");
            }
            // CHECK IF THE PROFILE PIC IS SET
            if (FacebookManager.Instance.ProfilePic != null)
            {
                Image ProfilePic = DialogProfilePic.GetComponent<Image>();
                ProfilePic.sprite = FacebookManager.Instance.ProfilePic;
            }
            else
            {
                // IF THERE IS NO PROFILE NAME
                StartCoroutine("WaitForProfilePic");
            }
            }else
        {
            FuserAvatar.sprite = facebookImage;


            DialogLoggedIn.SetActive(false);
            DialogLoggedOut.SetActive(true);
        }

      
    }

	IEnumerator WaitForProfileName(){
		while (FacebookManager.Instance.ProfileName == null) {
			yield return null;
		}
		DealWithFBMenus (FacebookManager.Instance.IsLoggedIn);
	}

	IEnumerator WaitForProfilePic(){
		while (FacebookManager.Instance.ProfilePic == null) {
			yield return null;
		}
		DealWithFBMenus (FacebookManager.Instance.IsLoggedIn);
	}

	public void Share(){
		FacebookManager.Instance.Share ();
	}

	public void Invite(){
	
		FacebookManager.Instance.Invite ();
	}

	public void ShareWithUsers(){

		FacebookManager.Instance.ShareWithUsers ();
	}
    /// <summary>
    /// //////////////////////////////////////////////////////
    



        ///////////////////////// FOR LEADERBPARD   //////////////////////





    public void SetScore()
    {
        rand++;
        var scoreData = new Dictionary<string, string>() { { "score", rand.ToString() } };

        
        //scoreData["score"] = rand.ToString();
        Debug.Log("Score submitted : Rand" + rand);
        FB.API("/me/scores", HttpMethod.POST, delegate(IGraphResult result)
         {
             Debug.Log("Score submitted : Done!" + result.RawResult);
         },scoreData);
    }
}
