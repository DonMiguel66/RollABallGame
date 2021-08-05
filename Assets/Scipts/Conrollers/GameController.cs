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
        private ListInteractableObject _interactiveObjects;
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayWinGame _displayWinGame;
        private DisplayPoints _displayPoints;

        private CameraController _cameraController;
        private InputController _inputController; 
        private Reference reference;

        public bool _playerImmortalStatus = false;
        public int _playerPoints;
        private int _artifactCount = 0;

        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            reference = new Reference();

            _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);


            _displayEndGame = new DisplayEndGame(reference.EndGame);
            _displayPoints = new DisplayPoints(reference.Points);
            _displayWinGame = new DisplayWinGame(reference.EndGame);

            foreach (var obj in _interactiveObject)
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

            reference.RestartButton.onClick.AddListener(RestartGame);
            reference.RestartButton.gameObject.SetActive(false);
        }

        private void PlayerDeath(string value)
        {
            reference.RestartButton.gameObject.SetActive(true);
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
            reference.RestartButton.gameObject.SetActive(true);
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
            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
        }
        public void Dispose()
        {
            foreach (var obj in _interactiveObject)
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

