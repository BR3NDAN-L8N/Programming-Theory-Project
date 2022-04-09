using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace com.BrendanLeighton
{
    public static class SceneNavigator
    {
        private static readonly string Title_Screen = "Title_Screen";
        private static readonly string Game = "Game";

        public static void ToTitleScreen()
        {
            SceneManager.LoadScene(Title_Screen, LoadSceneMode.Single);
        }


        public static void ToGameScene()
        {
            SceneManager.LoadScene(Game, LoadSceneMode.Single);
        }
    }
}
