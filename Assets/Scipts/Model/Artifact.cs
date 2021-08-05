using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace RollaBallGame
{
    public sealed class Artifact : InteractiveObject, IFly, IRotation
    {
        private DisplayPoints _displayPoints;
        public event Action<int> OnPointChange = delegate (int i) { };

        private float _flyAltitude;
        private float _rotSpeed;
        public int PointCount;

        private void Awake()
        {
            _flyAltitude = Random.Range(1.0f,2.0f);
            _rotSpeed = Random.Range(10f, 35f);
        }
        protected override void Interaction()
        {
            OnPointChange.Invoke(PointCount);
        }
        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, Mathf.PingPong(Time.time, _flyAltitude),
            transform.localPosition.z);
        }
        public void Rotation()
        {
            transform.Rotate(Vector3.up * (Time.deltaTime * _rotSpeed), Space.World);
        }

        public override void Execute()
        {
            if (!IsInteractable) return;
            Fly();
            Rotation();
        }
    }
}
