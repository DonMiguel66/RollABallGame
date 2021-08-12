using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RollaBallGame 
{
    public class CameraController : IExecute
    {
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _translation;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _translation = _mainCamera.position - _player.position;
        }

        public void Execute()
        {
            _mainCamera.position = _player.position + _translation;
        }
    }
}

