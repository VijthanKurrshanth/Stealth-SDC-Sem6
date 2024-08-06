// using System.Collections;
// using TMPro;
// using UnityEngine;
// using System;
// using UnityEngine.Networking;

// public class PlayerAuthentication : MonoBehaviour
// {
//     public TextMeshProUGUI debugText;

//     // Property to check if the user is authenticated
//     public static bool IsAuthenticated { get; private set; }

//     void Start()
//     {
//         PlayerPrefs.SetFloat("yesterdayConsumption", 0); // Reset yesterday's consumption at the start of the game

//         StartCoroutine(ApiController.GetJwtKey((responseString) => AuthenticateAndSaveProfile(responseString)));
//     }

//     // Check internet connection. Not used in this script but can be used to check internet connection before making API calls
//     IEnumerator CheckInternetConnection(Action<bool> action = null)
//     {
//         const string targetUrl = "https://google.com";
//         bool isConnected = false;

//         UnityWebRequest request = UnityWebRequest.Get(targetUrl);
//         request.method = UnityWebRequest.kHttpVerbGET;
//         request.downloadHandler = new DownloadHandlerBuffer();
//         request.SetRequestHeader("Content-Type", "application/json");
//         request.SetRequestHeader("Accept", "*/*");

//         yield return request.SendWebRequest();

//         if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
//         {
//             Debug.LogError($"Error occurred during JWT key retrieval: {request.error}");
//         }
//         else
//         {
//             isConnected = true;
//         }
//         action?.Invoke(isConnected);
//     }

//     private void AuthenticateAndSaveProfile(string responseString)
//     {
//         // Authenticate the user

//         if (responseString == null)
//         {
//             debugText.text = "Error occurred during JWT key retrieval";
//         }
//         else
//         {
//             debugText.text = "JWT key retrieved successfully";
//         }

//         // Save the user profile
//         StartCoroutine(ApiController.GetUserProfile(responseString, (userProfile) => SaveProfile(userProfile)));
//     }

//     private void SaveProfile(UserProfile userProfile)
//     {
//         if (userProfile == null)
//         {
//             debugText.text = "Error occurred during user profile retrieval";
//         }
//         else
//         {
//             debugText.text = "User profile retrieved successfully";
//         }

//         // Display the username
//         debugText.text = $"Welcome {userProfile.UserName}";

//         // Save the username
//         PlayerPrefs.SetString("firstName", userProfile.FirstName);
//         PlayerPrefs.SetString("lastName", userProfile.LastName);
//         PlayerPrefs.SetString("userName", userProfile.UserName);
//         PlayerPrefs.SetString("nic", userProfile.Nic);
//         PlayerPrefs.SetString("phoneNumber", userProfile.PhoneNumber);
//         PlayerPrefs.SetString("email", userProfile.Email);
//         PlayerPrefs.Save();

//         // Set authentication status to true
//         IsAuthenticated = true;
//     }
// }
