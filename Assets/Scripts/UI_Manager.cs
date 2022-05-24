using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using TMPro;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] private CanvasGroup gameOver;
    [SerializeField] private CanvasGroup pause;

    [SerializeField] private TMP_Text actualNests;
    [SerializeField] private TMP_Text totalNests;

    [SerializeField] private TMP_Text actualEggs;
    [SerializeField] private TMP_Text totalEggs;

    private void Awake()
    {
        Game_Manager.OnPause += ChangePauseState;
        CrashChecker.OnPlayerDeath += ShowGameOver;
        Egg.OnEggPickUp += UpdateActualEggs;
        Nest.OnDiscoverNest += UpdateActualNests;

        gameOver.gameObject.SetActive(true);
        pause.gameObject.SetActive(true);
    }

    void Start()
    {
        HidePanel(gameOver);
        HidePanel(pause);
        SetTotalEggs();
        SetTotalNests();
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
        Egg.OnEggPickUp -= UpdateActualEggs;
        Nest.OnDiscoverNest -= UpdateActualNests;
    }

    //Egg UI Functions
    private void UpdateActualEggs()
    {
        actualEggs.text = Egg.GetEggCount().ToString();
    }
    private void SetTotalEggs()
    {

        totalEggs.text = Egg.GetMaxEggCount().ToString();
    }

    //Nest UI Functions
    private void UpdateActualNests()
    {
        actualNests.text = Nest.GetNestCount().ToString();
    }
    private void SetTotalNests()
    {
        totalNests.text = Nest.GetMaxNestCount().ToString();
    }

}
