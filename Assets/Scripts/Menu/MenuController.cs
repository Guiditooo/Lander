using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup startingPanel;
    //[SerializeField] private CanvasGroup creditsPanel;

    private CanvasGroup actualPanel;

    private void Awake()
    {
        actualPanel = startingPanel;
        StartPanel(startingPanel);
    }

    public void StartPanel(CanvasGroup newPanel)
    {
        actualPanel.alpha = 0;
        actualPanel.blocksRaycasts = false;
        actualPanel.interactable = false;
        actualPanel = newPanel;
        actualPanel.alpha = 1;
        actualPanel.blocksRaycasts = true;
        actualPanel.interactable = true;
    }

    public void CloseGame()
    {
        Application.Quit();
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Gameplay");
    }

}
