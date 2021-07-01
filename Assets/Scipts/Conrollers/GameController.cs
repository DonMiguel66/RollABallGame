using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollaBallGame
{
    public class GameController : MonoBehaviour, IDisposable
    {
        private ListInteractableObject _interactiveObjects;
        private ListExecuteObject _interactiveObject;
        private DisplayEndGame _displayEndGame;
        private DisplayPoints _displayPoints;
        private CameraController _cameraController;
        private InputController _inputController;

        public bool _playerImmortalStatus = false;
        private float timer;

        public int _playerPoints;
        private void Awake()
        {
            _interactiveObject = new ListExecuteObject();
            var reference = new Reference();

            _cameraController = new CameraController(reference.PlayerBall.transform, reference.MainCamera.transform);
            _interactiveObject.AddExecuteObject(_cameraController);

            _inputController = new InputController(reference.PlayerBall);
            _interactiveObject.AddExecuteObject(_inputController);


            _displayEndGame = new DisplayEndGame();
            _displayPoints = new DisplayPoints(); 
            foreach (var obj in _interactiveObject)
            {
                if(obj is Artifact artifact)
                {
                    artifact.OnPointChange += AddPoint;
                }
                if (obj is DeathDebuff deathDebuff)
                {
                    deathDebuff.KillPlayer += PlayerDeath;
                    deathDebuff.KillPlayer += _displayEndGame.GameOver;
                }
                if (obj is ImmortalBuff immortalBuff)
                {
                    immortalBuff.PlayerImmortalChange += PlayerImmortal;
                }
            }

            //_interactiveObjects = new ListInteractableObject();
        }

        private void PlayerDeath(string value)
        {
            if(!_playerImmortalStatus)
                Time.timeScale = 0.0f;
        }

        private void PlayerImmortal(bool value)
        {
            StartCoroutine(SetImmortal(5));
        }

        private void AddPoint(int value)
        {
            _playerPoints += value;
            _displayPoints.Display(_playerPoints);
        }

        private void Update()
        {
            /*if (_playerImmortalStatus)
                timer += Time.deltaTime;
            if(_playerImmortalStatus && timer>5)
            {
                PlayerImmortal(false);
            }*/

            for (var i = 0; i < _interactiveObject.Length; i++)
            {
                var interactiveObject = _interactiveObject[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                interactiveObject.Execute();
            }
            /*for (var i = 0; i < _interactiveObjects.Length; i++)
            {
                var interactiveObject = _interactiveObjects[i];

                if (interactiveObject == null)
                {
                    continue;
                }
                if (interactiveObject is IFly fly)
                {
                    fly.Fly();
                }
                if (interactiveObject is IFlicker flicker)
                {
                    flicker.Flicker();
                }
                if (interactiveObject is IRotation rotation)
                {
                    rotation.Rotation();
                }
            }*/
        }
        public IEnumerator SetImmortal(float time)
        {
            _playerImmortalStatus = true;
            yield return new WaitForSeconds(time);
            _playerImmortalStatus = false;
        }
        public void Dispose()
        {
            /*foreach (var x in _interactiveObjects)
            {
                Destroy((UnityEngine.Object)x);
            }*/
            foreach (var obj in _interactiveObject)
            {
                if (obj is Artifact artifact)
                {
                    artifact.OnPointChange += AddPoint;
                }
                if (obj is DeathDebuff deathDebuff)
                {
                    deathDebuff.KillPlayer += PlayerDeath;
                }
            }
        }
        
    }
}

