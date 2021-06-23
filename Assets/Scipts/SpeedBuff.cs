using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class SpeedBuff : InteractiveObject, IFlicker, ISpeedChange
    {
        private Material _mat;
        private PlayerBall _player;
        public float _speedValue;

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
            SpeedChange();
        }

        public void SpeedChange()
        {
            _player.Speed += _speedValue;
        }
    }
}
