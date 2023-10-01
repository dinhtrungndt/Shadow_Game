using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // gọi API lấy thông tin và lưu vào bộ nhớ

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void GetSettings()
    {
        var url = "/login";

        HTTPRequetsHelper helper = new HTTPRequetsHelper();
        ListPostModel result = await helper.GetAPI(url);
        Debug.Log(">>>>>>>>" + result);
    }
}
