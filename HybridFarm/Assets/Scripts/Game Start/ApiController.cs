using UnityEngine;
using System;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using System.Text;
using System.Collections;

// This class contains methods that interact with APIs on the server
public static class ApiController
{
    // This method is used to get the JWT key from the server
    public static IEnumerator GetJwtKey(Action<string> callback = null)
    {
        Debug.Log("Getting JWT key");
        string result;
        string url = "http://20.15.114.131:8080/api/login";
        string body = "{\"apiKey\":\"NjVjNjA0MGY0Njc3MGQ1YzY2MTcyMmNlOjY1YzYwNDBmNDY3NzBkNWM2NjE3MjJjNA\"}";

        UnityWebRequest request = UnityWebRequest.Post(url, body, "application/json");
        request.method = UnityWebRequest.kHttpVerbPOST;
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(body));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "*/*");

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null; // Pause the coroutine until the request is complete
        }

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError($"Error occurred during JWT key retrieval: {request.error}");
            result = null;
        }
        else
        {
            string jsonResponse = request.downloadHandler.text;
            JObject jsonObject = JObject.Parse(jsonResponse);
            string token = (string)jsonObject["token"];
            result = token;
        }
        callback?.Invoke(result); // Invoke the callback function with the token or null
    }

    // This method is used to get the user profile from the server
    public static IEnumerator GetUserProfile(string jwtKey, Action<UserProfile> callback = null)
    {
        if (string.IsNullOrEmpty(jwtKey))
        {
            Debug.LogError("JWT key is null or empty");
            yield break;
        }

        string url = "http://20.15.114.131:8080/api/user/profile/view";
        UnityWebRequest request = UnityWebRequest.Get(url);
        request.method = UnityWebRequest.kHttpVerbGET;
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + jwtKey);

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null; // Pause the coroutine until the request is complete
        }

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError($"Error occurred during user profile retrieval: {request.error}");
            yield break;
        }

        string jsonResponse = request.downloadHandler.text;
        JObject jsonObject = JObject.Parse(jsonResponse);

        UserProfile userProfile = new()
        {
            FirstName = (string)jsonObject["user"]["firstname"],
            LastName = (string)jsonObject["user"]["lastname"],
            UserName = (string)jsonObject["user"]["username"],
            Nic = (string)jsonObject["user"]["nic"],
            PhoneNumber = (string)jsonObject["user"]["phoneNumber"],
            Email = (string)jsonObject["user"]["email"]
        };

        PlayerPrefs.SetString("userName", userProfile.UserName);

        callback?.Invoke(userProfile); // Invoke the callback function with the user profile
    }

    // This method is used to update the user profile on the server
    public static IEnumerator UpdateUserProfile(string jwtKey, UpdateProfileDTO updateProfileObject, Action<string> callback = null)
    {
        string url = "http://20.15.114.131:8080/api/user/profile/update";
        string jsonData = JsonUtility.ToJson(updateProfileObject);

        UnityWebRequest request = UnityWebRequest.Put(url, jsonData);
        request.method = UnityWebRequest.kHttpVerbPUT;
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(jsonData)); // Use raw upload for PUT request
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "application/json");
        request.SetRequestHeader("Authorization", "Bearer " + jwtKey);

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null; // Pause the coroutine until the request is complete
        }

        string message;
        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError($"Error occurred during user profile update: {request.error}");
            string exceptionBodyString = request.downloadHandler.text;
            JObject exceptionBody = JObject.Parse(exceptionBodyString);
            message = (string)exceptionBody["message"];
        }
        else
        {
            Debug.Log("Update successful");
            message = "success";
        }

        callback?.Invoke(message); // Invoke the callback function with the message
    }

    // This method is used to open the web app frontend
    public static IEnumerator OpenWebAppInNewTab()
    {
        string targetUrl = "http://localhost:3000/";
        Application.OpenURL(targetUrl);
        yield return null;
    }

    // This method is used to authenticate the web app interactions
    public static IEnumerator AuthenticateWebApp(Action callback = null)
    {

        string url = "http://localhost:8020/hybridFarm/v1/authenticate";
        string body = "{\"apiKey\":\"NjVjNjA0MGY0Njc3MGQ1YzY2MTcyMmNlOjY1YzYwNDBmNDY3NzBkNWM2NjE3MjJjNA\"}";

        UnityWebRequest request = UnityWebRequest.Post(url, body, "application/json");
        request.method = UnityWebRequest.kHttpVerbPOST;
        request.uploadHandler = new UploadHandlerRaw(Encoding.UTF8.GetBytes(body));
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "*/*");


        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null; // Pause the coroutine until the request is complete
        }

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError($"Error occurred during Authentication: {request.error}");
            yield break;
        }
        else
        {
            callback?.Invoke();
        }
    }

    // This method is used to get the score from the web app backend
    public static IEnumerator GetScore(Action<int> callback = null)
    {
        Debug.Log("Getting Score");
        int result;
        string url = "http://localhost:8020/hybridFarm/v1/score";

        UnityWebRequest request = UnityWebRequest.Get(url);
        request.method = UnityWebRequest.kHttpVerbGET;
        request.downloadHandler = new DownloadHandlerBuffer();
        request.SetRequestHeader("Content-Type", "application/json");
        request.SetRequestHeader("Accept", "*/*");

        yield return request.SendWebRequest();

        while (!request.isDone)
        {
            yield return null; // Pause the coroutine until the request is complete
        }

        if ((request.result == UnityWebRequest.Result.ConnectionError) || (request.result == UnityWebRequest.Result.ProtocolError))
        {
            Debug.LogError($"Error occurred during Score retrieval: {request.error}");
            result = -2;
        }
        else
        {
            string score = request.downloadHandler.text;
            if (int.TryParse(score, out int scoreValue))
            {
                Debug.Log($"Score: {scoreValue}");
                result = scoreValue;
            }
            else
            {
                Debug.LogError("Failed to parse score into an integer");
                result = -2;
            }
        }
        callback?.Invoke(result); // Invoke the callback function with the score
    }
}
