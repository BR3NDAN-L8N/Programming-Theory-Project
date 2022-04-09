using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace com.BrendanLeighton
{
    public class Timer
    {
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
        public TextMeshProUGUI UI_Timer;
        public bool isStarted = false;

        // LIFE CYCLE METHODS
        public void Update()
        {
            // count down
            if (isStarted && _time > 0) _time -= UnityEngine.Time.deltaTime;
        }

        // CLASS METHODS
        public void StartTimer()
        {
            isStarted = true;
        }
    }
}
