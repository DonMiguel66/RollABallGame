using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class ImmortalBuff : InteractiveObject, IFlicker
    {
        private Material _mat;
        [SerializeField] private float _immortalTime = 5;
        //private PlayerBall _player;
        private bool _immortal = true;

        //public event Action<float> PlayerImmortalChange = delegate (float i) { };
        public event Action<bool> PlayerImmortalChange = delegate (bool i) { };
        private void Awake()
        {
            _mat = GetComponent<Renderer>().material;
            //_player = Object.FindObjectOfType<PlayerBall>();

        }
        public void Flicker()
        {
            _mat.color = new Color(_mat.color.r, _mat.color.g, _mat.color.b,
            Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            PlayerImmortalChange.Invoke(_immortal);
            //_player.StartCoroutine(_player.SetImmortal(5));
        }
        public override void Execute()
        {
            if (!IsInteractable) return;
            Flicker();
        }
    }
}
