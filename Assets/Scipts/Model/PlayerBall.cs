using UnityEngine;

namespace RollaBallGame
{
    public sealed class PlayerBall : PlayerBase
    {
        private Rigidbody _rigidbody;

        private void Start()
        {
            foreach (var speedBuffObject in FindObjectsOfType<SpeedBuff>())
            {
                speedBuffObject.PlayerSpeedChange += SpeedChange;
            }
            foreach (var speedDebuffObject in FindObjectsOfType<SpeedDebuff>())
            {
                speedDebuffObject.PlayerSpeedChange += SpeedChange;
            }
            _rigidbody = GetComponent<Rigidbody>();
        }

        public override void Move(float x, float y, float z)
        {
            _rigidbody.AddForce(new Vector3(x, y, z) * Speed);
        }
        public void SpeedChange(float speedChangeValue)
        {
            Speed += speedChangeValue;
        }

        public void OnDestroy()
        {
            foreach (var speedBuffObject in FindObjectsOfType<SpeedBuff>())
            {
                speedBuffObject.PlayerSpeedChange -= SpeedChange;
            }
            foreach (var speedDebuffObject in FindObjectsOfType<SpeedDebuff>())
            {
                speedDebuffObject.PlayerSpeedChange -= SpeedChange;
            }
        }
    }
}
