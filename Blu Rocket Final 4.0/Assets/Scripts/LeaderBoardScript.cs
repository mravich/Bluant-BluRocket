using Facebook.Unity;
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


    void Awake()
    {

        QueryScores();
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
           FscoreText.text = entry["score"].ToString();

           FB.API(user["id"].ToString() + "/picture?width=120&heigh=120", HttpMethod.GET, delegate (IGraphResult picResult)
             {
                 if(picResult.Error != null)
                 {
                     Debug.Log(picResult.RawResult.ToString());
                 }else
                 {
                     FuserAvatar.sprite = Sprite.Create(picResult.Texture, new Rect(0, 0, 120, 75), new Vector2(0, 0));


                 }


             });

           //  DebugScores.text = user["name"].ToString() + " , " + entry["score"].ToString();

       }

    }
}
