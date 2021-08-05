using System;
using UnityEngine;
using UnityEngine.UI;

namespace RollaBallGame
{
    class DisplayWinGame
    {
        private Text _winGameLabel;

        public DisplayWinGame(GameObject endGame)
        {
            _winGameLabel = endGame.GetComponentInChildren<Text>();
            _winGameLabel.text = String.Empty;
        }

        public void GameOver()
        {
            _winGameLabel.text = $"Вы Выиграли.";
        }
    }
}
