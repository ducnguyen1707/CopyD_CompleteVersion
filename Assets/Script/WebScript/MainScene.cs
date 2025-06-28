using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainScene : MonoBehaviour
{
    public Button buttonLogin;
    public Button buttonRegis;
    public Button buttonPlay;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);

        buttonLogin.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        });

        buttonRegis.onClick.AddListener(() =>
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        });
    }
}
