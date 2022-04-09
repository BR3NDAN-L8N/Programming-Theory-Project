using System.Collections;
using UnityEngine;
using TMPro;

namespace com.BrendanLeighton.Assets.Scripts.Timers
{
    public class ReadyUp : Timer
    {
            public void SetUiComponent(TextMeshProUGUI UiElement)
        {
            UI_Timer = UiElement;
        }
    }
}