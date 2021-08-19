using UnityEngine;
using UnityEngine.UI;

namespace RollaBallGame
{
    public sealed class DisplayPoints
    {
        private Text _pointText;
        private GameController _GC;

        public DisplayPoints(GameObject points)
        {
            _pointText = points.GetComponentInChildren<Text>();
            _GC = Object.FindObjectOfType<GameController>();

        }

        public void Display(int value)
        {
            _GC._playerPoints += value;
            _pointText.text = $"Points: {_GC._playerPoints}";
        }
    }
}
