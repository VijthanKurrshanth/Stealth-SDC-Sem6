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

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(RetrieveUserProfile());
    }

    // Update is called once per frame
    void Update()
    {
    }

    private IEnumerator RetrieveUserProfile()
    {
        yield return StartCoroutine(ApiController.GetJwtKey((string key) =>
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("JWT key is null or empty");
                return;
            }
            StartCoroutine(ApiController.GetUserProfile(key, (UserProfile profile) =>
            {
                if (userProfile == null)
                {
                    Debug.LogError("Failed to retrieve user profile");
                }
                Debug.Log($"User profile retrieved: {userProfile}");
                userProfile = profile;
                SetTexMeshPro();
            }));
        }));
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
        StartCoroutine(UpdateProfile(updateProfileDTO));
    }

    private IEnumerator UpdateProfile(UpdateProfileDTO updateProfileObject)
    {
        yield return StartCoroutine(ApiController.GetJwtKey((string key) =>
        {
            string message = null;
            if (string.IsNullOrEmpty(key))
            {
                Debug.LogError("JWT key is null or empty");
                message = "sendError";
                CheckPutRequestStatus(message);
            }
            else
                StartCoroutine(ApiController.UpdateUserProfile(key, updateProfileObject, (string response) =>
                CheckPutRequestStatus(response)));
        }));
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
}

public class UpdateProfileDTO
{
    public string firstname;
    public string lastname;
    public string email;
    public string phoneNumber;
    public string nic;
}