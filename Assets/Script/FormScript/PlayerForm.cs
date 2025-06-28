using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using Unity.VisualScripting;
using UnityEngine.UI;
using JetBrains.Annotations;
using static UnityEditor.ShaderData;
using UnityEngine.EventSystems;
public class PlayerForm : MonoBehaviour
{
    public void Start()
    {
        StartCoroutine(Main.Instance.Web.GetQuizz("Ques1"));
    }
}

