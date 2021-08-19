using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Object = UnityEngine.Object;

namespace RollaBallGame
{
    public class GameController : MonoBehaviour, IDisposable
    {
        [SerializeField] private InputData _inputData;
        private ListExecuteObject _interactiveObjects;
        private DisplayEndGame _displayEndGame;
        private DisplayWinGame _displayWinGame;
        private DisplayPoints _displayPoints;

        private CameraController _cameraController;
        private InputController _inputController; 
        private Reference _reference;

        public bool _playerImmortalStatus = false;
        public int _playerPoints;
        private int _artifactCount = 0;

        private void Awake()
        {
            _interactiveObjects = new ListExecuteObject();
            _reference = new Reference();

            _cameraController = new CameraController(_reference.PlayerBall.transform, _reference.MainCamera.transform);
            _interactiveObjects.AddExecuteObject(_cameraController);

            _inputController = new InputController(_reference.PlayerBall, _inputData, _interactiveObjects);
            _interactiveObjects.AddExecuteObject(_inputController);


            _displayEndGame = new DisplayEndGame(_reference.EndGame);
            _displayPoints = new DisplayPoints(_reference.Points);
            _displayWinGame = new DisplayWinGame(_reference.EndGame);

            foreach (var obj in _interactiveObjects)
            {
                if(obj is Artifact artifact)
                {
                    artifact.OnPointChange += AddPoint;
                }
                if (obj is ImmortalBuff immortalBuff)
                {
                    immortalBuff.PlayerImmortalChange += PlayerImmortal;
                }
                if (obj is DeathDebuff deathDebuff)
                {
                    deathDebuff.KillPlayer += PlayerDeath;
                    deathDebuff.KillPlayer += _displayEndGame.GameOver;
                }
                if (obj is FinalArtifact finalArtifact)
                {
                    finalArtifact.FinishGame += StopGame;
                    finalArtifact.FinishGame += _displayWinGame.GameOver;
                }
            }

            _reference.RestartButton.onClick.AddListener(RestartGame);
            _reference.RestartButton.gameObject.SetActive(false);
        }

        private void PlayerDeath(string value)
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }

        private void PlayerImmortal(bool value, int time)
        {
            StartCoroutine(SetImmortal(time));
        }

        private void AddPoint(int value)
        {
            _playerPoints += value;
            _artifactCount += 1;
            _displayPoints.Display(_playerPoints);
        }

        private void StopGame()
        {
            _reference.RestartButton.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
        private void RestartGame()
        {
            SceneManager.LoadScene(sceneBuildIndex: 0);
            Time.timeScale = 1.0f;
        }
        public IEnumerator SetImmortal(float time)
        {
            _playerImmortalStatus = true;
            yield return new WaitForSeconds(time);
            _playerImmortalStatus = false;
        }

        private void Update()
        {
            for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }
        public void Dispose()
        {
            foreach (var obj in _interactiveObjects)
            {
                if (obj is Artifact artifact)
                {
                    artifact.OnPointChange -= AddPoint;
                }
                if (obj is ImmortalBuff immortalBuff)
                {
                    immortalBuff.PlayerImmortalChange -= PlayerImmortal;
                }
                if (obj is DeathDebuff deathDebuff)
                {
                    deathDebuff.KillPlayer -= PlayerDeath;
                }
            }
        }
        
    }
}

