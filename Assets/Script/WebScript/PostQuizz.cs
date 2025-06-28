using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using UnityEngine.Networking;
public class PostQuizz : MonoBehaviour
{
    public TMP_InputField newQuesInput;
    public TMP_InputField rightAnsInput;
    public TMP_InputField Ans1Input;
    public TMP_InputField Ans2Input;
    public TMP_InputField Ans3Input;
    public Button submitButton;

    public void Start()

    {
        submitButton.onClick.AddListener(() =>
        {
            StartCoroutine(postQuizz(newQuesInput.text, rightAnsInput.text, Ans1Input.text, Ans2Input.text, Ans3Input.text));
        });
    }

    public IEnumerator postQuizz(string ques, string rans, string ans1, string ans2, string ans3)
    {
        WWWForm form = new WWWForm();
        form.AddField("pQues", ques);
        form.AddField("pRAns", rans);
        form.AddField("pAns1", ans1);
        form.AddField("pAns2", ans2);
        form.AddField("pAns3", ans3);


        using UnityWebRequest www = UnityWebRequest.Post("http://localhost/sqlconnect/postquizz.php", form);
        yield return www.SendWebRequest();

        if (www.result != UnityWebRequest.Result.Success)
        {
            Debug.LogError(www.error);
        }
        else
        {
            Debug.Log(www.downloadHandler.text);
        }
    }
}
