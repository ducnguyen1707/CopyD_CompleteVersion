using System;
using System.Collections;
using System.Collections.Generic;
using Core.DesignPattern;
using Core.Extension;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class UIQuizzController : Singleton<UIQuizzController>
{
    #region SerializedVariable

    [SerializeField] private int _scoreEachAns;
    [SerializeField] private int _secondEnd;
    [SerializeField] private GameObject _panel;
    [SerializeField] private UIQuiz _prefabUIQuiz;
    [SerializeField] private Transform _uiQuizContainer;
    [SerializeField] private TextMeshProUGUI _txtScore;
    [SerializeField] private TextMeshProUGUI _txtTime;

    
    #endregion

    #region PublicVariable

    [HideInInspector] public int Score;
    [HideInInspector] public int Second;
    [HideInInspector] public int CorrectAns;
    [HideInInspector] public int WrongAns;
    [HideInInspector] public int MaxAns;
    public string TestData;

    #endregion

    #region PrivateVariable

    private List<UIQuiz> _uiQuizzes = new();
    

    #endregion

    #region Mono

    private void Start()
    {
        OpenPanelQuiz(TestData);
        InvokeRepeating(nameof(UpdateTime),0,1);
    }

    #endregion

    #region Control

    public void SetQuizzes(string data)
    {
        _uiQuizContainer.DestroyChilds();
        var quizzes = JsonConvert.DeserializeObject<List<QuizInfo>>(data);
        foreach (var quizInfo in quizzes)
        {
            var uiQuiz = Instantiate(_prefabUIQuiz, _uiQuizContainer);
            uiQuiz.Init(quizInfo);
            _uiQuizzes.Add(uiQuiz);
        }

      

        foreach (var uiQuiz in _uiQuizzes)
        {
            uiQuiz.transform.SetSiblingIndex(Random.Range(0,_uiQuizzes.Count));
        }

        MaxAns = _uiQuizzes.Count;
    }

    public void OpenPanelQuiz(string data)
    {
        _panel.SetActive(false);
        SetQuizzes(data);
    }

    public void OpenPanelQuiz()
    {
        _panel.SetActive(true);
    }
    public void OffPanelQuiz()
    {
        _panel.SetActive(false);
    }
    private void UpdateScore()
    {
        if (Score < 0)
            Score = 0;
        _txtScore.text = "Score:"+ Score;
        if (WrongAns + CorrectAns == MaxAns)
        {
            End();
        }
    }
    public void RightAnswer()
    {
        Score += _scoreEachAns;
        CorrectAns++;
        UpdateScore();
    }

    public void WrongAnswer()
    {
        Score -= _scoreEachAns;
        WrongAns++;
        UpdateScore();
    }

    private void UpdateTime()
    {
        Second++;
        var time = new TimeSpan(0,0,Second);
        _txtTime.text = time.ToString();
        if(Second>_secondEnd)
            End();
    }

    public void End()
    {
        _panel.SetActive(false);
        StopAllCoroutines();
        CancelInvoke();
        UIFinishQuiz.Instance.OpenFinishQuiz();
        Debug.Log("Chuyen qua EndScene");
    }

    #endregion
}

public class QuizInfo
{
    public string idquizz { get; set; }
    public string ques { get; set; }
    public string rans { get; set; }
    public string ans1 { get; set; }
    public string ans2 { get; set; }
    public string ans3 { get; set; }
}