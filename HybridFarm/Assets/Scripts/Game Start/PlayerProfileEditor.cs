using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;



public class PlayerProfileEditor : MonoBehaviour
{
    private UserProfile userProfile = new();
    private UpdateProfileDTO updateProfileDTO = new();
    public TextMeshProUGUI userName;
    public TextMeshProUGUI firstName;
    public TextMeshProUGUI lastName;
    public TextMeshProUGUI email;
    public TextMeshProUGUI phoneNumber;
    public TextMeshProUGUI nic;

    public TextMeshProUGUI firstNamePlaceholder;
    public TextMeshProUGUI lastNamePlaceholder;
    public TextMeshProUGUI emailPlaceholder;
    public TextMeshProUGUI phoneNumberPlaceholder;
    public TextMeshProUGUI nicPlaceholder;

    public TMP_InputField firstNameInputField;
    public TMP_InputField lastNameInputField;
    public TMP_InputField emailInputField;
    public TMP_InputField phoneNumberInputField;
    public TMP_InputField nicInputField;

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

        firstNamePlaceholder = GameObject.Find("FirstNamePlaceholder").GetComponent<TextMeshProUGUI>();
        lastNamePlaceholder = GameObject.Find("LastNamePlaceholder").GetComponent<TextMeshProUGUI>();
        emailPlaceholder = GameObject.Find("EmailPlaceholder").GetComponent<TextMeshProUGUI>();
        phoneNumberPlaceholder = GameObject.Find("PhonePlaceholder").GetComponent<TextMeshProUGUI>();
        nicPlaceholder = GameObject.Find("NICPlaceholder").GetComponent<TextMeshProUGUI>();

        firstNameInputField = GameObject.Find("FirstNameInputField").GetComponent<TMP_InputField>();
        lastNameInputField = GameObject.Find("LastNameInputField").GetComponent<TMP_InputField>();
        emailInputField = GameObject.Find("EmailInputField").GetComponent<TMP_InputField>();
        phoneNumberInputField = GameObject.Find("PhoneInputField").GetComponent<TMP_InputField>();
        nicInputField = GameObject.Find("NICInputField").GetComponent<TMP_InputField>();

        firstNameInputField.onEndEdit.AddListener(OnEndEditFirstName);
        lastNameInputField.onEndEdit.AddListener(OnEndEditLastName);
        emailInputField.onEndEdit.AddListener(OnEndEditEmail);
        phoneNumberInputField.onEndEdit.AddListener(OnEndEditPhoneNumber);
        nicInputField.onEndEdit.AddListener(OnEndEditNic);
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
        //StartCoroutine(DownloadImage(userProfile.ProfilePictureUrl));
    }

    public void SetTexMeshPro()
    {
        userName.text = userProfile.UserName;
        firstName.text = userProfile.FirstName;
        lastName.text = userProfile.LastName;
        email.text = userProfile.Email;
        phoneNumber.text = userProfile.PhoneNumber;
        nic.text = userProfile.Nic;

        firstNamePlaceholder.text = userProfile.FirstName;
        lastNamePlaceholder.text = userProfile.LastName;
        emailPlaceholder.text = userProfile.Email;
        phoneNumberPlaceholder.text = userProfile.PhoneNumber;
        nicPlaceholder.text = userProfile.Nic;

        updateProfileDTO.firstname = userProfile.FirstName;
        updateProfileDTO.lastname = userProfile.LastName;
        updateProfileDTO.Email = userProfile.Email;
        updateProfileDTO.phoneNumber = userProfile.PhoneNumber;
        updateProfileDTO.nic = userProfile.Nic;
    }

    // IEnumerator DownloadImage(string url)
    // {
    //     UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
    //     yield return request.SendWebRequest();

    //     if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
    //     {
    //         Debug.Log("Error downloading image: " + request.error);
    //     }
    //     else
    //     {
    //         Texture2D myTexture = ((DownloadHandlerTexture)request.downloadHandler).texture;
    //         // Conversion step: Create a Sprite from the downloaded Texture
    //         Sprite downloadedSprite = Sprite.Create(myTexture, new Rect(0, 0, myTexture.width, myTexture.height), new Vector2(0.5f, 0.5f));
    //     }
    // }

    public void OnEndEditFirstName(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.firstname = inputText;
    }

    public void OnEndEditLastName(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.lastname = inputText;
    }

    public void OnEndEditEmail(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.Email = inputText;
    }

    public void OnEndEditPhoneNumber(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.phoneNumber = inputText;
    }

    public void OnEndEditNic(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.nic = inputText;
    }

    public void OnSaveButtonClick()
    {
        StartCoroutine(UpdateProfile(updateProfileDTO, (string message) =>
        {
            Debug.Log(message);
            CheckPutRequestStatus(message);
        }));
    }

    IEnumerator UpdateProfile(UpdateProfileDTO updateProfileObject, Action<string> callback = null)
    {
        string message;
        string jwtKey = ApiController.GetJwtKey();
        if (string.IsNullOrEmpty(jwtKey))
        {
            Debug.LogError("JWT key is null or empty");
            message = "sendError";
            yield break;
        }
        else
            message = ApiController.UpdateUserProfile(jwtKey, updateProfileObject);

        // Call the callback function if it's not null
        callback?.Invoke(message);
    }

    private void CheckPutRequestStatus(string message)
    {
        if (message == "sendError")
        {
            Debug.LogError("Failed to update user profile");
            return;
        }
        else if (message == "success")
        {
            Debug.Log("User profile updated successfully");
        }
        else
        {
            Debug.LogError(message);
        }
    }
}

public class UpdateProfileDTO
{
    public string firstname;
    public string lastname;
    public string Email;
    public string phoneNumber;
    public string nic;
}