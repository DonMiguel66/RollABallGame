using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class ImmortalBuff : InteractiveObject, IFlicker
    {
        private Material _mat;
        private PlayerBall _player;

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
            _player.StartCoroutine(_player.SetImmortal(5));
        }
        
    }
}
