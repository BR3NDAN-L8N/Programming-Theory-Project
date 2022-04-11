using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace com.BrendanLeighton
{
    public class Box : MonoBehaviour
    {
        [SerializeField] public Renderer thisBox;

        public int color_curr = 0;
        public Color[] color_options = { Color.blue, Color.red, Color.yellow };
        private Color randomColor;
        private bool _isBoxNotFrozen = true;

        private void Awake()
        {
            thisBox = gameObject.GetComponent<Renderer>();
        }

        public void SetColor(Color newColor)
        {
            Debug.Log("thisBox > SetColor: " + thisBox + "\nnewColor: " + newColor.ToString());
            if (thisBox == null) thisBox = gameObject.GetComponent<Renderer>();
            thisBox.material.color = newColor;
            if (newColor == Color.white) color_curr = -1;               // -1 so next click turns box to Blue
            if (newColor == color_options[0]) color_curr = 0;         // Blue
            else if (newColor == color_options[1]) color_curr = 1;  // Red
            else color_curr = 2;                                                   // Yellow
        }

        public void SetColorRandom()
        {
            color_curr = Random.Range(0, 3);
            Color newColor = color_options[color_curr];
            thisBox.material.color = newColor;
            randomColor = newColor;
        }

        public bool CheckCurrColorVsRandomColor()
        {
            if (color_options[color_curr] == randomColor)
            {
                // TODO: add some type of highlighting to let players know which box is the correct color
                return true;
            }
            return false;
        }

        public void ChangeColor()
        {
            if (_isBoxNotFrozen)
            {
                if (color_curr == 2) color_curr = 0;
                else color_curr++;

                thisBox.material.color = color_options[color_curr];
            }
        }

        public void OnMouseDown()
        {
            ChangeColor();
        }

        public void FreezeBoxChangeByPlayer(bool boolean)
        {
            _isBoxNotFrozen = !boolean;
        }
    }
}
