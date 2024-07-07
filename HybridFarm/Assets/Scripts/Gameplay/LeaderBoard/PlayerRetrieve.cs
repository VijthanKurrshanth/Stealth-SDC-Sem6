using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using UnityEngine;

public class PlayerRetrieve : MonoBehaviour
{
    public GameObject leaderBoardContent;

    // Start is called before the first frame update
    void Start()
    {
        System.DateTime currentTime = System.DateTime.Now;
        int interval = 0;

        string lastCheckedTimeStr = PlayerPrefs.GetString("LastCheckedTime");
        Debug.Log("lastCheckedTime :"+lastCheckedTimeStr);
        if (!string.IsNullOrEmpty(lastCheckedTimeStr))
        {
            System.DateTime lastCheckedTime = System.DateTime.Parse(lastCheckedTimeStr);
            System.TimeSpan timeDifference = currentTime - lastCheckedTime;
            interval = (int)timeDifference.TotalSeconds;
            if (interval >= 60)
            {
                PlayerPrefs.SetString("LastCheckedTime", currentTime.ToString());
                PlayerPrefs.Save();
            }
        }
        else
        {
            PlayerPrefs.SetString("LastCheckedTime", currentTime.ToString());
            PlayerPrefs.Save();
        }

        StartCoroutine(ApiController.GetJwtKey((string key) =>
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("JWT key is null or empty");
                return;
            }
            StartCoroutine(ApiController.GetPlayersList(key, (List<JObject> players) =>
            {
                if (players == null)
                {
                    Debug.Log("Failed to retrieve players list");
                    return;
                }

                int totalPlayers = players.Count;

                List<Player> playerList = new();

                foreach (JObject obj in players)
                {
                    if (obj["username"].ToString() == PlayerPrefs.GetString("userName"))
                    {
                        Player player = new()
                        {
                            userName = PlayerPrefs.GetString("userName"),
                            firstName = PlayerPrefs.GetString("firstName"),
                            lastName = PlayerPrefs.GetString("lastName"),
                            score = PlayerPrefs.GetInt("PlayerScore"),
                        };
                        playerList.Add(player);
                    }
                    else
                    {
                        Player player = new()
                        {
                            userName = obj["username"].ToString(),
                            firstName = obj["firstname"].ToString(),
                            lastName = obj["lastname"].ToString(),
                            score = CalculateScore(obj["username"].ToString(), totalPlayers, interval),
                        };
                        playerList.Add(player);
                    }
                }
                RankPlayers(playerList);
                foreach (Player player in playerList)
                {
                    //Debug.Log("Rank: " + player.rank + " Username: " + player.userName + " Score: " + player.score);
                }
                leaderBoardContent.GetComponent<PlayerView>().DisplayPlayers(playerList);
            }));
        }));
    }

    // Update is called once per frame
    void Update()
    {

    }

    private int CalculateScore(string userName, int totalPlayers, int interval)
    {
        int currentScore = PlayerPrefs.GetInt(userName + "_score");

        int randomScoreWeight = Random.Range(1, totalPlayers);
        if (currentScore == 0)
        {
            currentScore = SetBaseScore(randomScoreWeight, totalPlayers);
        }
        else if (interval >= 60)
        {
            double increase = interval * 100 * randomScoreWeight / 60 / totalPlayers;
            currentScore += (int)increase;
        }

        PlayerPrefs.SetInt(userName + "_score", currentScore);
        PlayerPrefs.Save();

        return currentScore;
    }

    private int SetBaseScore(int num, int totalPlayers)
    {
        int maxScore = 3000;
        int minScore = 500;

        int baseScore = minScore + (maxScore - minScore) * num / totalPlayers;
        return baseScore;
    }

    private void RankPlayers(List<Player> playerList)
    {
        playerList.Sort((x, y) => y.score.CompareTo(x.score));

        for (int i = 0; i < playerList.Count; i++)
        {
            playerList[i].rank = i + 1;
            //Debug.Log("Rank: " + (i + 1) + " Username: " + playerList[i].userName + " Score: " + playerList[i].score);
        }
    }
}
