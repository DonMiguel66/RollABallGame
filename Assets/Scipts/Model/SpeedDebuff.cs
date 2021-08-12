using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class SpeedDebuff : InteractiveObject, IRotation
    {
        private float _rotSpeed;
        public float _speedValue;

        public event Action<float> PlayerSpeedChange = delegate (float i) { };
        private void Awake()
        {
            _rotSpeed = Random.Range(25f, 50f);
        }

        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotSpeed), Space.World);
        }

        protected override void Interaction()
        {
            PlayerSpeedChange.Invoke(_speedValue*-1);       
        }


        public override void Execute()
        {
            if (!IsInteractable) return;
            Rotation();
        }
    }
}
