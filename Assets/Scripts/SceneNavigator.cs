using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneNavigator
{
    private static readonly string Title_Screen = "Title_Screen";
    private static readonly string Game = "Game";

    public static void GoToTitleScreen()
    {
        SceneManager.LoadScene(Title_Screen, LoadSceneMode.Single);
    }


    public static void GoToGameScene()
    {
        SceneManager.LoadScene(Game, LoadSceneMode.Single);
    }
}
