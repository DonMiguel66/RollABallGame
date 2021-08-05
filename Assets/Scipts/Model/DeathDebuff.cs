using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class DeathDebuff : InteractiveObject, IRotation
    {
        private float _rotSpeed;
        private GameController _GC;
        public event Action<string> KillPlayer = delegate (string i) { };

        private void Awake()
        {
            _rotSpeed = Random.Range(25f, 50f);
            _GC = Object.FindObjectOfType<GameController>();
        }
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotSpeed), Space.World);
        }

        protected override void Interaction()
        {
            if(!_GC._playerImmortalStatus)
                KillPlayer(gameObject.name);
        }

        public override void Execute()
        {
            if (!IsInteractable) return;
            Rotation();
        }
    }
}
