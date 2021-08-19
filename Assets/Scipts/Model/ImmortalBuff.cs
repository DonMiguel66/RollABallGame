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
        [SerializeField] private int _immortalTime = 5;
        public event Action<bool, int> PlayerImmortalChange = delegate (bool i, int n) { };
        private void Awake()
        {
            _mat = GetComponent<Renderer>().material;
        }
        public void Flicker()
        {
            _mat.color = new Color(_mat.color.r, _mat.color.g, _mat.color.b,
            Mathf.PingPong(Time.time, 1.0f));
        }

        protected override void Interaction()
        {
            PlayerImmortalChange.Invoke(true, _immortalTime);
        }
        public override void Execute()
        {
            if (!IsInteractable) return;
            Flicker();
        }
    }
}
