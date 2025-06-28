using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Regis : MonoBehaviour
{
    public TMP_InputField newnameInput;
    public TMP_InputField newpasswordInput;
    public Button regissubmitButton;

    public void Start()
    {
        regissubmitButton.onClick.AddListener(() =>
        {
            StartCoroutine(Main.Instance.Web.Regis(newnameInput.text, newpasswordInput.text));
        });
    }
}
