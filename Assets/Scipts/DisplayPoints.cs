using UnityEngine;
using UnityEngine.UI;

namespace RollaBallGame
{
    public sealed class DisplayPoints
    {
        private Text _text;
        private GameController _GC;

        public DisplayPoints()
        {
            _text = Object.FindObjectOfType<Text>();
            _GC = Object.FindObjectOfType<GameController>();
        }

        public void Display(int value)
        {
            _GC._playerPoints += value;
            _text.text = $"Points: {_GC._playerPoints}";
        }
    }
}
