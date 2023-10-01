using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

public class HTTPRequetsHelper
{
    private string baseUrl = "https://game-2d-md18102.onrender.com/register";


    // get
    public async Task<ListPostModel> GetAPI(string url)
    {
        try
        {
            url += baseUrl;
            // setup header authorization bearer token
            using var www = UnityWebRequest.Get(url);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = www.downloadHandler.text;
            var model = ListPostModel.CreateReponseFromJSON(result);
            return model;
        }
        catch (Exception e)
        {
            Debug.Log(e.Message);
            return default;
        }
    }

    // post 
    public async Task<bool> PostAPI(string url, WWWForm form)
    {
        try
        {
            url += baseUrl + url; 
            Debug.Log(">>>>>>>> Post API: " + url);
            using var www = UnityWebRequest.Post(url, form);
            var operation = www.SendWebRequest();
            while (!operation.isDone) await Task.Yield();
            if (www.result != UnityWebRequest.Result.Success)
                Debug.Log(www.error);
            var result = www.downloadHandler.text;
            Debug.Log(">>>>>>>>> result: " + result);
            var model = ReponseModel.CreateFromJSON(result);
            Debug.Log(model.error + " " + model.statusCode);
            return model.error;
        }
        catch (Exception e)
        {
            Debug.Log(">>>>>> Lỗi dòng 56 POST: " + e.Message);
            return default;
        }
    }


}

// posts reponse 

public class ListPostModel: ReponseModel
{
    public PostModel[] data { get; set; }

    public static ListPostModel CreateReponseFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ListPostModel>(jsonString);
    }
}
public class PostModel
{
    public string id { get; set; }
    public string Carts { get; set; }
    public string Points { get; set; }
    public string Coins { get; set; }
    public string Position { get; set; }
    public string Disabled { get; set; }
}

// model reponse
public class ReponseModel
{
    internal bool error { get; set; }

    public int statusCode { get; set; }
    public static ReponseModel CreateFromJSON(string jsonString)
    {
        return JsonUtility.FromJson<ReponseModel>(jsonString);
    }
}
