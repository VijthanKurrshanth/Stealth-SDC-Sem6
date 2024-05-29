using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerProfileEditor : MonoBehaviour
{
    private UserProfile userProfile = new();
    private readonly UpdateProfileDTO updateProfileDTO = new();
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

    public bool questionnaireFinished = false;

    // Start is called before the first frame update
    void Start()
    {
        RetrieveUserProfile();
    }

    // This method is used to retrieve the user profile from the server
    private void RetrieveUserProfile()
    {
        StartCoroutine(ApiController.GetJwtKey((string key) =>
        {
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("JWT key is null or empty");
                return;
            }
            StartCoroutine(ApiController.GetUserProfile(key, (UserProfile profile) =>
            {
                if (userProfile == null)
                {
                    Debug.Log("Failed to retrieve user profile");
                }

                userProfile = profile; // Assign the retrieved user profile to the userProfile object
                SetTexMeshPro();
            }));
        }));
    }

    // This method is used to set the retrieved user profile to the TextMeshPro objects
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

        // Initialize the updateProfileDTO object with the retrieved user profile data
        updateProfileDTO.firstname = userProfile.FirstName;
        updateProfileDTO.lastname = userProfile.LastName;
        updateProfileDTO.email = userProfile.Email;
        updateProfileDTO.phoneNumber = userProfile.PhoneNumber;
        updateProfileDTO.nic = userProfile.Nic;
    }

    public void OnEndEditFirstName(string inputText)
    {
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.firstname = inputText; // Update the first name in the updateProfileDTO object
        firstNamePlaceholder.text = inputText; // Update the first name in the placeholder
    }

    public void OnEndEditLastName(string inputText)
    {
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.lastname = inputText;
        lastNamePlaceholder.text = inputText;
    }

    public void OnEndEditEmail(string inputText)
    {
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.email = inputText;
        emailPlaceholder.text = inputText;
    }

    public void OnEndEditPhoneNumber(string inputText)
    {
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.phoneNumber = inputText;
        phoneNumberPlaceholder.text = inputText;
    }

    public void OnEndEditNic(string inputText)
    {
        Debug.Log("User entered: " + inputText);
        updateProfileDTO.nic = inputText;
        nicPlaceholder.text = inputText;
    }

    public void OnSaveButtonClick()
    {
        UpdateProfile(updateProfileDTO);
    }

    // This method is used to update the user profile on the server
    private void UpdateProfile(UpdateProfileDTO updateProfileObject)
    {
        StartCoroutine(ApiController.GetJwtKey((string key) =>
        {
            string message = null;
            if (string.IsNullOrEmpty(key))
            {
                Debug.Log("JWT key is null or empty");
                message = "sendError";
                CheckPutRequestStatus(message);
            }
            else
                StartCoroutine(ApiController.UpdateUserProfile(key, updateProfileObject, (string response) =>
                CheckPutRequestStatus(response)));
        }));
    }

    // This method is used to check the status of the PUT request
    private void CheckPutRequestStatus(string message)
    {
        if (message == "sendError")
        {
            Debug.Log("Failed to update user profile");
            return;
        }
        else if (message == "success")
        {
            Debug.Log("User profile updated successfully");
            if (PlayerPrefs.GetInt("playerExists") == 0)
            {
                StartCoroutine(ApiController.AuthenticateWebApp(() =>
                {
                    waitingPanel.SetActive(true);
                    ApiController.OpenWebAppInNewTab();
                })); // Authenticate the web app and open it in a new tab

            }
            else
                SceneManager.LoadScene("3.MainMenu");
        }
        else
        {
            Debug.Log(message);
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
                    PlayerPrefs.SetInt("playerExists", 1);
                }
            }
            else
            {
                questionnaireFinished = false;
                waitingPanel.SetActive(false); // Hide the waiting panel
                SceneManager.LoadScene("6. LevelMap");
            }
        }));
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