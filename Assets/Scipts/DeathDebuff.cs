using System;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;
namespace RollaBallGame
{
    public sealed class DeathDebuff : InteractiveObject, IRotation
    {
        private float _rotSpeed;
        private Player _player;

        /*public delegate void KillPlayerChange(object value);
        public event KillPlayerChange _killPlayer;
        public event KillPlayerChange KillPlayer
        {
            add { _killPlayer += value; }
            remove { _killPlayer -= value; }

        }*/
        private void Awake()
        {
            _rotSpeed = Random.Range(25f, 50f);
            _player = Object.FindObjectOfType<PlayerBall>();
        }
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotSpeed), Space.World);
        }

        protected override void Interaction()
        {
            if(!_player.isImmortal)
                Destroy(_player);
            //_killPlayer?.Invoke(this);
        }
    }
}
