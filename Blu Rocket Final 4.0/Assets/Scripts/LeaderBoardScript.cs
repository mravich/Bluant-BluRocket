using Facebook.Unity;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LeaderBoardScript : MonoBehaviour {

    public GameObject ScoreEntryPanel;
    public GameObject ScrollScoreList;
    List<object> leaderBoardList = new List<object>();
    IResult results;
    List<object> leaderBoardObject = new List<object>();

    public GameObject ProfileText;
    public GameObject ProfileImage;
    public GameObject ProfileBest;
    public GameObject ProfileCoins;
    public GameObject ProfileRank;

    int rank;
    int profScore;
    


    bool isLoggedIn = false;

    void Awake()
    {
        rank = 1;
        profScore = PlayerPrefsManager.GetHighScore();
        isLoggedIn = FacebookManager.Instance.IsLoggedIn;
        if (isLoggedIn)
        {
            DealWithFBMenus(isLoggedIn);
            QueryScores();
        }else
        {
            Debug.Log("Awake - isLoggedIn is still false !! ");
        }
    }

	// Use this for initialization
	void Start () {
        /*
        results = FBscript.Instance.LeaderBoardResults();
        if (results != null)
        {
            IDictionary<string, object> data = results.ResultDictionary;


            //  List<object> scoreList = (List<object>)data["data"];
            leaderBoardList = (List<object>)data["data"];


            foreach (object obj in leaderBoardList)
            {
                var entry = (Dictionary<string, object>)obj;
                var user = (Dictionary<string, object>)entry["user"];
                Debug.Log(user["name"].ToString() + " , " + entry["score"].ToString());

                GameObject scorePanel;
                scorePanel = Instantiate(ScoreEntryPanel) as GameObject;
                scorePanel.transform.SetParent(ScrollScoreList.transform, false);

                Transform FriendName = scorePanel.transform.Find("FriendName");
                Transform FriendScore = scorePanel.transform.Find("FriendScore");
                Transform FriendAvatar = scorePanel.transform.Find("FriendAvatar");

                Text FnameText = FriendName.GetComponent<Text>();
                Text FscoreText = FriendScore.GetComponent<Text>();
                Image FuserAvatar = FriendAvatar.GetComponent<Image>();

                FnameText.text = user["name"].ToString();
                FscoreText.text = entry["score"].ToString();

                FB.API(user["id"].ToString() + "/picture?width=120&heigh=120", HttpMethod.GET, delegate (IGraphResult picResult)
                {
                    if (picResult.Error != null)
                    {
                        Debug.Log(picResult.RawResult.ToString());
                    }
                    else
                    {
                        FuserAvatar.sprite = Sprite.Create(picResult.Texture, new Rect(0, 0, 120, 120), new Vector2(0, 0));


                    }


                });

                //  DebugScores.text = user["name"].ToString() + " , " + entry["score"].ToString();

            }

        }else
        {
            Debug.LogError("no data receved from FBscript !");
        }*/
    }

    // Update is called once per frame
    void Update () {
		
	}
    public void QueryScores()
    {
        FB.API("/app/scores?fields=score,user.limit(30)", HttpMethod.GET, ScoresCallback);
    }
    private void ScoresCallback(IResult result)
    {
        //Debug.Log("Scores callBack: 1");
        //ScoresRes = result;
        //Debug.Log("Scores callBack: 2");

        /*string TextNow = result.RawResult;
         Debug.Log("Scores callBack: " + TextNow);
         DebugScores.text =TextNow;*/
        
       IDictionary<string, object> data = result.ResultDictionary;



      leaderBoardObject = (List<object>)data["data"];


       foreach (object obj in leaderBoardObject)
       {
           var entry = (Dictionary<string, object>)obj;
           var user = (Dictionary<string, object>)entry["user"];
           Debug.Log(user["name"].ToString() + " , " + entry["score"].ToString());

           GameObject scorePanel;
           scorePanel = Instantiate(ScoreEntryPanel) as GameObject;
           scorePanel.transform.SetParent(ScrollScoreList.transform,false);

           Transform FriendName = scorePanel.transform.Find("FriendText");
           Transform FriendScore = scorePanel.transform.Find("FriendScore");
           Transform FriendAvatar = scorePanel.transform.Find("FriendAvatar");

           Text FnameText = FriendName.GetComponent<Text>();
           Text FscoreText = FriendScore.GetComponent<Text>();
           Image FuserAvatar = FriendAvatar.GetComponent<Image>();

           FnameText.text = user["name"].ToString();
            string scoreNow = entry["score"].ToString();
            FscoreText.text = "Best: " + scoreNow;
            int currScore = Int32.Parse(scoreNow);
            if (currScore > profScore)
            {
                rank++;
            }

            FB.API(user["id"].ToString() + "/picture?width=120&heigh=120", HttpMethod.GET, delegate (IGraphResult picResult)
             {
                 if(picResult.Error != null)
                 {
                     Debug.Log(picResult.RawResult.ToString());
                 }else
                 {
                     Debug.Log("Have pics for ScrollList");
                     FuserAvatar.sprite = Sprite.Create(picResult.Texture, new Rect(0, 0, 120, 75), new Vector2(0, 0));


                 }


             });

           //  DebugScores.text = user["name"].ToString() + " , " + entry["score"].ToString();

       }

    }
    void DealWithFBMenus(bool isLoggedIn)
    {
        if (FB.IsLoggedIn)
        {
            //  FuserAvatar.sprite = leagerbordImage;
            Text ProfileBestText = ProfileBest.GetComponent<Text>();
            ProfileBestText.text = profScore + "";

            Text ProfileCoinsText = ProfileCoins.GetComponent<Text>();
            ProfileCoinsText.text = PlayerPrefsManager.GetCoins() + "";

            Text ProfileRankText = ProfileRank.GetComponent<Text>();
           
            ProfileRankText.text = rank + "";


            // CHECK IF THE PROFILE NAME IS SET
            if (FacebookManager.Instance.ProfileName != null)
            {
                Text UserName = ProfileText.GetComponent<Text>();
                UserName.text = FacebookManager.Instance.ProfileName;
            }
            else
            {
                // IF THERE IS NO PROFILE NAME
                StartCoroutine("WaitForProfileName");
            }
            // CHECK IF THE PROFILE PIC IS SET
            if (FacebookManager.Instance.ProfilePic != null)
            {
                Image ProfilePic = ProfileImage.GetComponent<Image>();
                ProfilePic.sprite = FacebookManager.Instance.ProfilePic;
            }
            else
            {
                // IF THERE IS NO PROFILE NAME
                StartCoroutine("WaitForProfilePic");
            }
        }
        else
        {
            Debug.Log("Facebook is SHIT .. u need to log in to get there but u u'r not logged .. hope this error will never be active .. ");


           
        }


    }

    IEnumerator WaitForProfileName()
    {
        while (FacebookManager.Instance.ProfileName == null)
        {
            yield return null;
        }
        DealWithFBMenus(FacebookManager.Instance.IsLoggedIn);
    }

    IEnumerator WaitForProfilePic()
    {
        while (FacebookManager.Instance.ProfilePic == null)
        {
            yield return null;
        }
        DealWithFBMenus(FacebookManager.Instance.IsLoggedIn);
    }

   
}
