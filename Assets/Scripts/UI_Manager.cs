using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOver;
    [SerializeField] private CanvasGroup pause;

    private void Awake()
    {
        Game_Manager.OnPause += ChangePauseState;
        CrashChecker.OnPlayerDeath += ShowGameOver;
    }

    void Start()
    {
        HidePanel(gameOver);
        HidePanel(pause);
    }

    public void ShowPanel(CanvasGroup cg)
    {
        cg.alpha = 1;
        cg.blocksRaycasts = true;
        cg.interactable = true;
    }
    public void HidePanel(CanvasGroup cg)
    {
        cg.alpha = 0;
        cg.blocksRaycasts = false;
        cg.interactable = false;
    }
    private void ChangePauseState()
    {
        if (gameOver.alpha == 1) return;
        if(pause.alpha == 1)
        {
            HidePanel(pause);
        }
        else
        {
            ShowPanel(pause);
        }
    }

    private void ShowGameOver()
    {
        ShowPanel(gameOver);
    }

    private void OnDestroy()
    {
        Game_Manager.OnPause -= ChangePauseState;
        CrashChecker.OnPlayerDeath -= ShowGameOver;
    }

}
