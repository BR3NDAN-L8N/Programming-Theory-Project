using System.Collections;
using UnityEngine;
using TMPro;

namespace com.BrendanLeighton.Assets.Scripts.Timers
{
    public class ReadyUp : Timer
    {
        public ReadyUp(GameObject ParentUIElement, TextMeshProUGUI uiElement, float startTime, bool removeUiElementWhenTimerEnds) 
            : base(ParentUIElement, uiElement, startTime, removeUiElementWhenTimerEnds)
        {
        }
    }
}