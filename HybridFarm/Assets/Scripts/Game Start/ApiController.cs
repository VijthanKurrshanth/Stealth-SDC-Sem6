using UnityEngine;
using System;
using System.IO;
using System.Net;
using Newtonsoft.Json.Linq;
using UnityEngine.Networking;
using System.Text;
using System.Collections;
using System.Runtime.InteropServices.WindowsRuntime;

public static class ApiController
{
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
        callback?.Invoke(result);
    }

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

        UserProfile userProfile = new UserProfile()
        {
            FirstName = (string)jsonObject["user"]["firstname"],
            LastName = (string)jsonObject["user"]["lastname"],
            UserName = (string)jsonObject["user"]["username"],
            Nic = (string)jsonObject["user"]["nic"],
            PhoneNumber = (string)jsonObject["user"]["phoneNumber"],
            Email = (string)jsonObject["user"]["email"]
        };

        PlayerPrefs.SetString("userName", userProfile.UserName);

        callback?.Invoke(userProfile);
    }


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

        callback?.Invoke(message);
    }

}
