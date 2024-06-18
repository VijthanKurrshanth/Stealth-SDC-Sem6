using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerView : MonoBehaviour
{
    public GameObject playerPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DisplayPlayers(List<Player> players)
    {
        int count = 0;
        foreach (Player player in players)
        {
            GameObject playerObject = Instantiate(playerPrefab, transform);
            playerObject.transform.localPosition = new Vector3(806.365f, -85 - count * 153, 0);
            foreach (Text textComponent in playerObject.GetComponentsInChildren<Text>())
            {
                if (textComponent.name == "UserName")
                {
                    textComponent.text = player.userName;
                }
                else if (textComponent.name == "FirstName")
                {
                    textComponent.text = player.firstName;
                }
                else if (textComponent.name == "LastName")
                {
                    textComponent.text = player.lastName;
                }
                else if (textComponent.name == "Score")
                {
                    textComponent.text = player.score.ToString();
                }
                else if (textComponent.name == "Rank")
                {
                    textComponent.text = player.rank.ToString();
                }
            }
            count++;
        }
    }
}
