using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MySceneManager : MonoBehaviour
{
    private void Awake()
    {
        DontDestroyOnLoad(this);
    }

    public void GoToGameScene()
    {
        SceneManager.LoadScene("Game");
    }

    public static void GoToCreditsScene()
    {
        SceneManager.LoadScene("Credits");
    }

    public static void GoToMenuScene()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
