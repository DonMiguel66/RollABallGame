using UnityEngine;
using UnityEngine.UI;

namespace RollaBallGame
{
    public class Reference
    {
        private PlayerBall _playerBall;
        private Camera _mainCamera;
        private Canvas _canvas; 
        private GameObject _points;
        private GameObject _endGame;
        private Button _restartButton;
        public Canvas Canvas
        {
            get
            {
                if (_canvas == null)
                {
                    _canvas = Object.FindObjectOfType<Canvas>();
                }
                return _canvas;
            }

        }
        public GameObject Points
        {
            get
            {
                if (_points == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/Points");
                    _points = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _points;
            }
        }

        public GameObject EndGame
        {
            get
            {
                if (_endGame == null)
                {
                    var gameObject = Resources.Load<GameObject>("UI/FinishGameLabel");
                    _endGame = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _endGame;
            }
        }
        public Button RestartButton
        {
            get
            {
                if (_restartButton == null)
                {
                    var gameObject = Resources.Load<Button>("UI/RestartButton");
                    _restartButton = Object.Instantiate(gameObject, Canvas.transform);
                }

                return _restartButton;
            }
        }

        public PlayerBall PlayerBall
        {
            get
            {
                if (_playerBall == null)
                {
                    var gameObject = Resources.Load<PlayerBall>("PlayerBall");
                    _playerBall = Object.Instantiate(gameObject);
                }

                return _playerBall;
            }
        }

        public Camera MainCamera
        {
            get
            {
                if (_mainCamera == null)
                {
                    _mainCamera = Camera.main;
                }
                return _mainCamera;
            }
        }

    }
}
