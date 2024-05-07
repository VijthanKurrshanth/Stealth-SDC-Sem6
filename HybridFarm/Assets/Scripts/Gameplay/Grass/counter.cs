using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class counter : MonoBehaviour
{
    public TextMeshProUGUI countdownText;
    grassSpawnDestroy grassSpawnDestroy;

    void Start()
    {
        StartCoroutine(MakeNumberCountdown());
    }

    private IEnumerator MakeNumberCountdown()
    {
        for (int i = 5; i > 0; i--)
        {
            countdownText.text = i.ToString();
            yield return new WaitForSeconds(1); // Wait for 1 second
        }
        // After the countdown is finished, set the numberOfGrassplant to 0
        grassSpawnDestroy.numberOfGrassplant = 0;
    }
}
