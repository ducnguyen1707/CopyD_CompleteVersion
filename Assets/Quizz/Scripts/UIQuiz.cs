using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIQuiz : MonoBehaviour
{
    #region SerializedVariable

    [SerializeField] private TextMeshProUGUI _txtQuestion;
    [SerializeField] private List<TextMeshProUGUI> _txtAnswers;
    [SerializeField] private List<Button> _btnAnswers;

    #endregion

    #region PublicVariable

    [HideInInspector] public QuizInfo QuizInfo;

    #endregion

    #region Init

    public void Init(QuizInfo info)
    {
        QuizInfo = info;
        _txtQuestion.text = info.ques;
        _txtAnswers[0].text = info.rans;
        _txtAnswers[1].text = info.ans1;
    }

    #endregion

    #region Mono

    private void Awake()
    {
        for (int i = 0; i < _btnAnswers.Count; i++)
        {
            var index = i;
            _btnAnswers[i].onClick.AddListener(()=>OnAnswer(_txtAnswers[index].text));
        }
    }

    #endregion

    #region Control

    private void OnAnswer(string ans)
    {
        if (ans == QuizInfo.rans)
        {
            UIQuizzController.Instance.RightAnswer();
        }
        else
        {
            UIQuizzController.Instance.WrongAnswer();
        }

        SetInteractableButtonAnswers(false);
    }

    private void SetInteractableButtonAnswers(bool isInteractable)
    {
        foreach (var btnAnswer in _btnAnswers)
        {
            btnAnswer.interactable = isInteractable;
        }
    }

    #endregion
}
