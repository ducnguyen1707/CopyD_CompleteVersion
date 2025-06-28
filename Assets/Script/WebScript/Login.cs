using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class Login : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TMP_InputField passwordInput;
    public Button submitButton;

    public void Start()
    {
        submitButton.onClick.AddListener(() =>
        {
           StartCoroutine(Main.Instance.Web.Login(nameInput.text, passwordInput.text));
        });

    }
}
