using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FormButtonScript : MonoBehaviour
{
     //[SerializeField] Canvas formCanvas;
    [SerializeField] GameObject game;
    public Button formButton;

    void Start()
    {
        Button button = formButton.GetComponent<Button>();
        
        button.onClick.AddListener(thongbao);
    }

    void thongbao()
    {
        Debug.Log("Hi");
     }
}
