using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor;
using System;


public class PlayerProfileEditor : MonoBehaviour
{
    private UserProfile userProfile;
    public TextMeshProUGUI userName;
    public TextMeshProUGUI firstName;
    public TextMeshProUGUI lastName;
    public TextMeshProUGUI email;
    public TextMeshProUGUI phoneNumber;
    public TextMeshProUGUI nic;
    public Image downloadedImage;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RetrieveUserProfile());
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator RetrieveUserProfile()
    {
        string jwtKey = ApiController.GetJwtKey();
        if (string.IsNullOrEmpty(jwtKey))
        {
            Debug.LogError("JWT key is null or empty");
            yield break;
        }

        this.userProfile = ApiController.GetUserProfile(jwtKey);
        if (userProfile == null)
        {
            Debug.LogError("Failed to retrieve user profile");
            yield break;
        }

        Debug.Log($"User profile retrieved: {userProfile}");

        setTexMeshPro();
        StartCoroutine(DownloadImage(userProfile.ProfilePictureUrl));
    }

    public UserProfile GetUserProfile()
    {
        return this.userProfile;
    }

    public void setTexMeshPro()
    {
        this.userName.text = userProfile.UserName;
        this.firstName.text = userProfile.FirstName;
        this.lastName.text = userProfile.LastName;
        this.email.text = userProfile.Email;
        this.phoneNumber.text = userProfile.PhoneNumber;
        this.nic.text = userProfile.Nic;
    }

    IEnumerator DownloadImage(string url)
    {
        UnityWebRequest www = UnityWebRequestTexture.GetTexture(url);
        yield return www.SendWebRequest();

        if ((www.result == UnityWebRequest.Result.ConnectionError) || (www.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.Log("Error downloading image: " + www.error);
        }
        else
        {
            Texture2D myTexture = ((DownloadHandlerTexture)www.downloadHandler).texture;
            // Conversion step: Create a Sprite from the downloaded Texture
            Sprite downloadedSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
            downloadedImage.sprite = downloadedSprite;
        }
    }
}
