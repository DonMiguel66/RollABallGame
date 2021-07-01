using UnityEngine;
using UnityEngine.UI;

namespace RollaBallGame
{
    public sealed class DisplayEndGame
    {
        private Text _finishGameLabel;

        public DisplayEndGame()
        {
            // будем грузить из кода
        }

        public void GameOver(string name)
        {
            _finishGameLabel.text = $"Вы проиграли. Вас убил {name} цвета";
        }
    }
}
