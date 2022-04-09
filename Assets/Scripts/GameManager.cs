using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using com.BrendanLeighton.Assets.Scripts.Timers;

namespace com.BrendanLeighton
{

    // a button to begin the game (perhaps it's the same canvas that has the game over text except the text is not displayed at the beginning
    // a countdown timer before player is shown the patter
    // randomly assign colors to the boxes
    // another countdown for player to try to memorize the colors
    // when timer ends the boxes change to white and the player can start changing the colors
    // ??? time limit on how long the player has to enter their choice, long enough to be able to cycle through the colors but limit like 30-60 seconds


    public class GameManager : MonoBehaviour
    {
        // GAME OBJECTS
        [SerializeField] private GameObject overlay_BeginGame;
        [SerializeField] private GameObject overlay_HUD;
        [SerializeField] private GameObject overlay_ReadyUpTimer;
        [SerializeField] private TextMeshProUGUI timer_HUD;
        [SerializeField] private TextMeshProUGUI timer_ReadyUp;
        [SerializeField] private Box[] _boxes;
        // TIMES / TIMER
        [SerializeField] private float _timeForPlayerToMemorize;
        [SerializeField] private float _timeForPlayerToPickColors;
        private ReadyUp _readyUpTimer;

        private void Awake()
        {
            // make sure beginning overlay is active,
            overlay_BeginGame.SetActive(true);
            // and other overlays are inactive
            overlay_HUD.SetActive(false);
            overlay_ReadyUpTimer.SetActive(false);

            _readyUpTimer = new ReadyUp();
        }

        private void Update()
        {
            if (_readyUpTimer.isStarted)  _readyUpTimer.Update();
        }

        public void ButtonPress_BeginGame()
        {
            // remove begin-game-button
            overlay_BeginGame.SetActive(false);
            // start game start countdown
            // assign timers
            _readyUpTimer.SetUiComponent(timer_ReadyUp);
            overlay_ReadyUpTimer.SetActive(true);
            _readyUpTimer.StartTimer();

            // pick random colors for each block

            // start timer
            // when timer ends, change all blocks to white
            for (int i = 0; i < _boxes.Length; i++)
            {
                Debug.Log("box in loop to change color: " + _boxes[i]);
                _boxes[i].SetColor(Color.white);
            }
        }
    }
}
