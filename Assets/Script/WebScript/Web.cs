using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using UnityEngine.UI;
using UnityEditor.UIElements;
using static UnityEditor.ShaderData;
using System.Xml.Linq;


public class Web : MonoBehaviour
{
   
    void Start()
    {
        //StartCoroutine(Login("test1", "123"));
        //StartCoroutine(GetUser());
      // StartCoroutine(Regis("user2", "duc"));

    }

    IEnumerator GetUser()
    {   
        UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/getuser.php");
        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            // Show results as text
            Debug.Log(www.downloadHandler.text);

            // Or retrieve results as binary data
            byte[] results = www.downloadHandler.data;
        }
    }

   

    public IEnumerator Login(string myname, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginName", myname);
        form.AddField("loginPass", pass);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/login.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);

        }
    }

    public IEnumerator Regis(string myname, string pass)
    {
        WWWForm form = new WWWForm();
        form.AddField("loginName", myname);
        form.AddField("loginPass", pass);

        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/register.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
           UnityEngine.SceneManagement.SceneManager.LoadScene(3);
            
        }
    }
    public IEnumerator GetQuizz(string idquizz)
    {

        WWWForm form = new WWWForm();
        form.AddField("idquizz", idquizz);
        using UnityWebRequest www = UnityWebRequest.Get("http://localhost/sqlconnect/getquizz.php");

        yield return www.Send();

        if (www.isNetworkError)
        {
            Debug.Log(www.error);
        }
        else
        {
            string jsonData = www.downloadHandler.text;
            Debug.Log(jsonData);
            UIQuizzController.Instance.SetQuizzes(jsonData);
        }
    }
   

}

