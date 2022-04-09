using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.BrendanLeighton
{
    public class TitleScreenManager : MonoBehaviour
    {
        // START GAME BUTTON
        public void ButtonPress_StartGame()
        {
            SceneNavigator.ToGameScene();
        }
    }
}
