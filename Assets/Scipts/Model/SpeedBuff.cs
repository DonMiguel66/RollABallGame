﻿using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class SpeedBuff : InteractiveObject, IFlicker
    {
        private Material _mat;
        private PlayerBall _player;
        public float _speedValue;

        public event Action<float> PlayerSpeedChange = delegate(float i) { };

        private void Awake()
        {
            _mat = GetComponent<Renderer>().material;
            _player = Object.FindObjectOfType<PlayerBall>();
        }
        public void Flicker()
        {
            _mat.color = new Color(_mat.color.r, _mat.color.g, _mat.color.b,
            Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            PlayerSpeedChange.Invoke(_speedValue);
        }

        /*public void SpeedChange()
        {
            _player.Speed += _speedValue;
        }*/

        public override void Execute()
        {
            if (!IsInteractable) return;
            Flicker();
        }
    }
}