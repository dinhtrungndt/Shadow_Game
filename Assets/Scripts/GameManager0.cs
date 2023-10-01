using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager0 : MonoBehaviour
{
    // register
    public TMP_InputField RegisterEmail;
    public TMP_InputField RegisterPassword;
    public TMP_Text RegisterError;

    // login
    public TMP_InputField LoginEmail;
    public TMP_InputField LoginPassword;
    public TMP_Text LoginError;

    public async void Register()
    {
        var email = RegisterEmail.text;
        var password = RegisterPassword.text;

        var url = "/add-register";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        HTTPRequetsHelper helper = new HTTPRequetsHelper();
        var result = await helper.PostAPI(url, form);
        Debug.Log(">>>>>>>>" + result);

        if(!result)
        {
            // chuyển màn hình login
        }
        else
        {
            // hiện thông báo lỗi
            RegisterError.text = "Đăng ký không thành công !";
        }
    }

    public async void Login()
    {
        var email = LoginEmail.text;
        var password = LoginPassword.text;

        var url = "/login";
        WWWForm form = new WWWForm();
        form.AddField("email", email);
        form.AddField("password", password);
        HTTPRequetsHelper helper = new HTTPRequetsHelper();
        var result = await helper.PostAPI(url, form);
        Debug.Log(">>>>>>>>" + result);

        if (!result)
        {
            // chuyển qua Scene 1
            SceneManager.LoadScene(AppConstants.SCENE01_INDEX);
        }
        else
        {
            // hiện thông báo lỗi
            LoginError.text = "Đăng nhập không thành công !";
        }
    }
}
