using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    [SerializeField] private CanvasGroup startingPanel;

    private CanvasGroup actualPanel;

    private void Awake()
    {
        actualPanel = startingPanel;

        foreach (CanvasGroup canvasGroup in GetComponentsInChildren<CanvasGroup>())
        {
            canvasGroup.alpha = 0;
            canvasGroup.blocksRaycasts = false;
            canvasGroup.interactable = false;
        }

        actualPanel.alpha = 1;
        actualPanel.blocksRaycasts = true;
        actualPanel.interactable = true;

    }

    public void StartPanel(CanvasGroup newPanel)
    {
        StartCoroutine(PanelChange(newPanel));
    }

    IEnumerator MakeItVisible(CanvasGroup panel)
    {
        float t = 0;
        while (t<1)
        {
            t += Time.unscaledDeltaTime;
            panel.alpha = t;
            yield return null;
        }
        panel.blocksRaycasts = true;
        panel.interactable = true;
    }
    IEnumerator MakeItInvisible(CanvasGroup panel)
    {
        panel.blocksRaycasts = false;
        panel.interactable = false;
        float t = 1;
        while (t > 0)
        {
            t -= Time.unscaledDeltaTime;
            panel.alpha = t;
            yield return null;
        }
    }

    IEnumerator PanelChange(CanvasGroup panel)
    {
        yield return StartCoroutine(MakeItInvisible(actualPanel));
        StartCoroutine(MakeItVisible(panel));
        actualPanel = panel;
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
