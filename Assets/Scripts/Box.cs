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

        private void Awake()
        {
            thisBox = gameObject.GetComponent<Renderer>();
        }

        public void SetColor(Color newColor)
        {
            thisBox.material.color = newColor;
            if (newColor == Color.white) color_curr = -1;               // -1 so next click turns box to Blue
            if (newColor == color_options[0]) color_curr = 0;         // Blue
            else if (newColor == color_options[1]) color_curr = 1;  // Red
            else color_curr = 2;                                                   // Yellow
        }

        public void ChangeColor()
        {
            if (color_curr == 2) color_curr = 0;
            else color_curr++;

            thisBox.material.color = color_options[color_curr];
        }

        public void OnMouseDown()
        {
            ChangeColor();
        }
    }
}
