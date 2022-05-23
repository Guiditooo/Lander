using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Game_Manager : MonoBehaviour
{
    private bool playerIsAlive;
    [SerializeField] private bool fuel;

    public static Action OnPause;

    private void Awake()
    {
        Time.timeScale = 1;
        CrashChecker.OnPlayerDeath += PauseGame;
        OnPause += PauseGame;
    }

    private void Start()
    {
        Time.timeScale = 1;
        playerIsAlive = true;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape))
        {
            OnPause();
        }
    }

    public void ReturnToMainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    private void PauseGame()
    {
        Time.timeScale = Time.timeScale == 0 ? 1 : 0;
    }

    private void OnDestroy()
    {
        CrashChecker.OnPlayerDeath -= PauseGame;
        OnPause -= PauseGame;
    }

}
