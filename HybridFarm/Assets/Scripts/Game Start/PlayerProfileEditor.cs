using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

    public GameObject alertPanel;
    public TextMeshProUGUI alertText;

    public GameObject waitingPanel;
    public TextMeshProUGUI waitingText;
    public GameObject loadingScreen;
    public GameObject attackAlgorithm;

    public bool questionnaireFinished = false;

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
        updateProfileDTO.email = userProfile.Email;
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
        firstNamePlaceholder.text = inputText;
    }

    public void OnEndEditLastName(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.lastname = inputText;
        lastNamePlaceholder.text = inputText;
    }

    public void OnEndEditEmail(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.email = inputText;
        emailPlaceholder.text = inputText;
    }

    public void OnEndEditPhoneNumber(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.phoneNumber = inputText;
        phoneNumberPlaceholder.text = inputText;
    }

    public void OnEndEditNic(string inputText)
    {
        // Process the input text here (e.g., print it to the console)
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.nic = inputText;
        nicPlaceholder.text = inputText;
    }

    public void OnSaveButtonClick()
    {
        StartCoroutine(UpdateProfile(updateProfileDTO, (string message) =>
        {
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
            if (PlayerPrefs.GetInt("playerExists") == 0)
            {
                SceneManager.LoadScene("4.GameplayEnvironment");
                PlayerPrefs.SetInt("playerExists", 1);
            }
            else
                SceneManager.LoadScene("3.MainMenu");
        }
        else
        {
            Debug.LogError(message);
            alertText.text = message;
            alertPanel.SetActive(true);
        }
    }

    public void OnAlertCloseButtonClick()
    {
        alertPanel.SetActive(false);
    }

    public void OnCloseButtonClicked()
    {
        SceneManager.LoadScene("3.MainMenu");
    }

    public void OnCloseWaitButtonClick()
    {
        StartCoroutine(ApiController.GetScore((score) =>
        {
            if (!questionnaireFinished)
            {
                if (score == -1)
                {
                    waitingText.text = "Please finish the questionnaire";
                }
                else if (score == -2)
                {
                    waitingText.text = "Connection Issue";
                }
                else
                {
                    waitingText.text = $"Your score is: {score} \n Press Finish button again.";
                    PlayerPrefs.SetInt("playerBoostPoints", score);
                    StartCoroutine(ApiController.Reset());
                    questionnaireFinished = true;
                }
            }
            else
            {
                questionnaireFinished = false;
                waitingPanel.SetActive(false); // Hide the waiting panel
                StartCoroutine(LoadingScreen());
            }
        }));
    }

    IEnumerator LoadingScreen()
    {
        loadingScreen.SetActive(true);
        while (attackAlgorithm.GetComponent<AttackAlgorithm>().GetAttackInterval() == 0)
        {
            yield return new WaitForSeconds(1f);
        }
        loadingScreen.SetActive(false);
        SceneManager.LoadScene("4.GameplayEnvironment");
    }
}

// This class is used to store the user profile data
public class UpdateProfileDTO
{
    public string firstname;
    public string lastname;
    public string email;
    public string phoneNumber;
    public string nic;
}