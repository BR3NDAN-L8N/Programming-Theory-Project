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
        [SerializeField] private float _timeForPlayerToReadyUp;
        [SerializeField] private float _timeForPlayerToMemorize;
        [SerializeField] private float _timeForPlayerToPickColors;
        private Timer _readyUpTimer;
        private Timer _hudTimer;
        // FLAGS
        private bool _isGameLoopActive = false;
        private bool _isGameLoopStarting = false;
        // STATS
        private float _score = 0f;

        private void Awake()
        {
            // make sure beginning overlay is active,
            overlay_BeginGame.SetActive(true);
            // and other overlays are inactive
            overlay_HUD.SetActive(false);
            overlay_ReadyUpTimer.SetActive(false);

            _readyUpTimer = new Timer(overlay_ReadyUpTimer, timer_ReadyUp, _timeForPlayerToReadyUp, false);
            _hudTimer = new Timer(overlay_HUD, timer_HUD, _timeForPlayerToPickColors, true);
        }

        private void Update()
        {
            if (_readyUpTimer.isStarted) _readyUpTimer.Update();
            if (_hudTimer.isStarted) _hudTimer.Update();

            if (!_isGameLoopStarting && _isGameLoopActive)
            {
                StopCoroutine(StartGame());
            }
        }

        IEnumerator StartGame()
        {
            _isGameLoopStarting = true;
            // remove begin-game-button
            overlay_BeginGame.SetActive(false);
            // activate the overlay that holds the ReadyUp timer UI
            overlay_ReadyUpTimer.SetActive(true);
            // start timer for player to ready up
            _readyUpTimer.StartTimer();
            // make the coroutine wait for the timer
            yield return new WaitForSeconds(_timeForPlayerToReadyUp);
            // pick random colors for each block
            RandomizeAllBlocks();
            // make coroutine wait for memorizing time
            yield return new WaitForSeconds(_timeForPlayerToMemorize);
            // change all blocks to white
            ResetAllBlocks();
            UnfreezeBoxes();
            _isGameLoopStarting = false;
            _isGameLoopActive = true;  // this bool is used to manage the game running state (here it lets us know this coroutine can stop
            StartCoroutine(HandlePlayersTurn());
        }

        IEnumerator HandlePlayersTurn()
        {
            overlay_HUD.SetActive(true);
            _hudTimer.StartTimer();
            yield return new WaitForSeconds(_timeForPlayerToPickColors);
            // END PLAYERS TURN
            FreezeBoxes();
            CheckPlayersSubmission();
        }

        public void ButtonPress_BeginGame()
        {
            FreezeBoxes();
            ResetAllBlocks();
            StartCoroutine(StartGame());
        }

        private void ResetAllBlocks()
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].SetColor(Color.white);
            }
        }

        private void RandomizeAllBlocks()
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].SetColorRandom();
            }
        }

        private void CheckPlayersSubmission()
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                if (_boxes[i].CheckCurrColorVsRandomColor())
                {
                    _score += 1;
                }
            }
            Debug.Log("Score: " + _score);
            StopCoroutine(HandlePlayersTurn());
        }

        private void FreezeBoxes()
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].FreezeBoxChangeByPlayer(true);
            }
        }

        private void UnfreezeBoxes()
        {
            for (int i = 0; i < _boxes.Length; i++)
            {
                _boxes[i].FreezeBoxChangeByPlayer(false);
            }
        }
    }
}
