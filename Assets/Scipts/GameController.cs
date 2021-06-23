using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollaBallGame
{
    public class GameController : MonoBehaviour, IDisposable
    {
        private ListInteractableObject _interactiveObjects;
        private InteractiveObject _interactiveObject;
        public int _playerPoints;
        private void Awake()
        {            
            _interactiveObjects = new ListInteractableObject();
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
            }
        }

        public void Dispose()
        {
            foreach (var x in _interactiveObjects)
            {
                Destroy((UnityEngine.Object)x);
            }
        }
        
    }
}

