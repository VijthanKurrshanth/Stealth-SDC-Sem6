using TMPro;
using UnityEngine;

public class DebugApi : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    string jwtKey;

    void Start()
    {
        StartCoroutine(ApiController.GetJwtKey((responseString) => ShowUserProfile(responseString)));
    }

    public void ShowUserProfile(string jwtKey)
    {
        if (jwtKey == null)
        {
            debugText.text = "Error occurred during JWT key retrieval";
        }
        else
        {
            debugText.text = "JWT key retrieved successfully";
            UserProfile userProfile = new();
            StartCoroutine(ApiController.GetUserProfile(jwtKey, (userProfile) => SaveProfile(userProfile)));
            debugText.text = "First Name: " + userProfile.FirstName + "\n" +
                            "Last Name: " + userProfile.LastName + "\n" +
                            "User Name: " + userProfile.UserName + "\n" +
                            "NIC: " + userProfile.Nic + "\n" +
                            "Phone Number: " + userProfile.PhoneNumber + "\n" +
                            "Email: " + userProfile.Email + "\n" +
                            "JWT Key: " + jwtKey;
        }
    }

    private void SaveProfile(UserProfile userProfile)
    {

    }

    // public void ShowJwtKey()
    // {
    //     string jwtKey = ApiController.GetJwtKey();
    //     debugText.text = "JWT Key: " + jwtKey;
    // }
}
