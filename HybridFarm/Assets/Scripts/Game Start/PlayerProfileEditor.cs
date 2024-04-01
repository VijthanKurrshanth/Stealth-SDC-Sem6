using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class PlayerProfileEditor : MonoBehaviour
{
    private UserProfile userProfile = new();
    private UpdateProfileObject updateProfileObject = new();
    public TextMeshProUGUI userName;
    public TextMeshProUGUI firstName;
    public TextMeshProUGUI lastName;
    public TextMeshProUGUI email;
    public TextMeshProUGUI phoneNumber;
    public TextMeshProUGUI nic;
    public TextMeshProUGUI profilePictureUrl;
    public Image downloadedImage;

    public TextMeshProUGUI firstNamePlaceholder;
    public TextMeshProUGUI lastNamePlaceholder;
    public TextMeshProUGUI emailPlaceholder;
    public TextMeshProUGUI phoneNumberPlaceholder;
    public TextMeshProUGUI nicPlaceholder;
    public TextMeshProUGUI profilePictureUrlPlaceholder;

    // Start is called before the first frame update
    void Start()
    {
        UpdateAttributes();
        StartCoroutine(RetrieveUserProfile());
    }

    private void UpdateAttributes()
    {
        userName = GameObject.Find("UserName").GetComponent<TextMeshProUGUI>();
        firstName = GameObject.Find("FirstNameText").GetComponent<TextMeshProUGUI>();
        lastName = GameObject.Find("LastNameText").GetComponent<TextMeshProUGUI>();
        email = GameObject.Find("EmailText").GetComponent<TextMeshProUGUI>();
        phoneNumber = GameObject.Find("PhoneText").GetComponent<TextMeshProUGUI>();
        nic = GameObject.Find("NICText").GetComponent<TextMeshProUGUI>();
        profilePictureUrl = GameObject.Find("URLText").GetComponent<TextMeshProUGUI>();

        firstNamePlaceholder = GameObject.Find("FirstNamePlaceholder").GetComponent<TextMeshProUGUI>();
        lastNamePlaceholder = GameObject.Find("LastNamePlaceholder").GetComponent<TextMeshProUGUI>();
        emailPlaceholder = GameObject.Find("EmailPlaceholder").GetComponent<TextMeshProUGUI>();
        phoneNumberPlaceholder = GameObject.Find("PhonePlaceholder").GetComponent<TextMeshProUGUI>();
        nicPlaceholder = GameObject.Find("NICPlaceholder").GetComponent<TextMeshProUGUI>();
        profilePictureUrlPlaceholder = GameObject.Find("URLPlaceholder").GetComponent<TextMeshProUGUI>();
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

        SetTexMeshPro();
        StartCoroutine(DownloadImage(userProfile.ProfilePictureUrl));
    }

    public void SetTexMeshPro()
    {
        userName.text = userProfile.UserName;
        firstName.text = userProfile.FirstName;
        lastName.text = userProfile.LastName;
        email.text = userProfile.Email;
        phoneNumber.text = userProfile.PhoneNumber;
        nic.text = userProfile.Nic;
        profilePictureUrl.text = userProfile.ProfilePictureUrl;

        firstNamePlaceholder.text = userProfile.FirstName;
        lastNamePlaceholder.text = userProfile.LastName;
        emailPlaceholder.text = userProfile.Email;
        phoneNumberPlaceholder.text = userProfile.PhoneNumber;
        nicPlaceholder.text = userProfile.Nic;
        profilePictureUrlPlaceholder.text = userProfile.ProfilePictureUrl;
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

    public void OnEndEdit(string newText)
    {
        Debug.Log("First Name: " + firstName.text);
        Debug.Log("Last Name: " + lastName.text);
        Debug.Log("Email: " + email.text);
        Debug.Log("Phone Number: " + phoneNumber.text);
        Debug.Log("NIC: " + nic.text);
    }

    public void OnSaveButtonClick()
    {
        updateProfileObject.FirstName = firstName.text;
        updateProfileObject.LastName = lastName.text;
        updateProfileObject.Email = email.text;
        updateProfileObject.PhoneNumber = phoneNumber.text;
        updateProfileObject.Nic = nic.text;

        Debug.Log(updateProfileObject.FirstName + " " + updateProfileObject.LastName + " " + updateProfileObject.Email + " " + updateProfileObject.PhoneNumber + " " + updateProfileObject.Nic);
        Debug.Log(firstName.text + " " + lastName.text + " " + email.text + " " + phoneNumber.text + " " + nic.text);

        StartCoroutine(UpdateProfile(updateProfileObject));
    }

    IEnumerator UpdateProfile(UpdateProfileObject updateProfileObject)
    {
        Debug.Log(updateProfileObject.FirstName);
        string jwtKey = ApiController.GetJwtKey();
        if (string.IsNullOrEmpty(jwtKey))
        {
            Debug.LogError("JWT key is null or empty");
            yield break;
        }

        ApiController.UpdateUserProfile(jwtKey, updateProfileObject);
    }
}

public class UpdateProfileObject
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Nic { get; set; }
}