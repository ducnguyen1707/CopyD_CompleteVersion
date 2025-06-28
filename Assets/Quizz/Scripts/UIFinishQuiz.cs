using System;
using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using TMPro;
using UnityEngine;

public class UIFinishQuiz : Singleton<UIFinishQuiz>
{
    #region SerializedVariable

    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private TextMeshProUGUI _txtTime;
    [SerializeField] private TextMeshProUGUI _txtCorrectAns;
    [SerializeField] private GameObject _panel;

    #endregion

    #region Control

    public void OpenFinishQuiz(int score=-1,string time="",int correctAns=-1)
    {
        _panel.SetActive(true);
        _txtScore.text ="Score: "+(score == -1 ? UIQuizzController.Instance.Score : score);
        _txtTime.text = "Time:" + (string.IsNullOrEmpty(time)?  new TimeSpan(0,0,UIQuizzController.Instance.Second).ToString() : time);
        _txtCorrectAns.text = $"Correct:{UIQuizzController.Instance.CorrectAns}/{UIQuizzController.Instance.MaxAns}" ;
    }

    #endregion
}
