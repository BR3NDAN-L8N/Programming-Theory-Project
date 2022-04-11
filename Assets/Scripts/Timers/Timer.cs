using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace com.BrendanLeighton
{
    public class Timer
    {
        public Timer(GameObject ParentUIElement, TextMeshProUGUI uiElement, float startTime, bool isSetActiveOnTimeOut)
        {
            UI_Timer_Text = uiElement;
            TimersParentComponent = ParentUIElement;
            Time = startTime;
            isActiveOnTimeOut = isSetActiveOnTimeOut;
        }

        // PROPERTIES
        private float _time;
        public float Time
        {
            get => _time;
            set
            {
                if (value > 0) _time = value;
                else _time = 0;
            }
        }

        // FIELDS
        public TextMeshProUGUI UI_Timer_Text;
        GameObject TimersParentComponent;
        public bool isStarted = false;
        private bool isActiveOnTimeOut;
        private TextMeshProUGUI uiElement;
        private float startTime;
        private bool removeUiElementWhenTimerEnds;

        // LIFE CYCLE METHODS
        public void Update()
        {
            Debug.Log("Timer.cs > Update(): has ran");
            if (isStarted)
            {
                // stop timer
                if (_time <= 0)
                {
                    Debug.Log("Stopping timer... ");
                    if (isActiveOnTimeOut)
                    {
                        UI_Timer_Text.text = "Times Up!";
                    } else
                    {
                        TimersParentComponent.SetActive(isActiveOnTimeOut);
                    }
                    isStarted = false;
                }
                // count down
                if (_time > 0)
                {
                    Debug.Log("Timer going");
                    _time -= UnityEngine.Time.deltaTime;

                    Debug.Log("Timer.cs > Update() > _time: " + _time);

                    UI_Timer_Text.text = "Time: " + _time.ToString("#0.00");
                }
            }
        }

        // CLASS METHODS
        public void StartTimer()
        {
            isStarted = true;
        }
    }
}
