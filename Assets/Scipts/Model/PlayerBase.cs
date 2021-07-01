using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollaBallGame
{
    public abstract class PlayerBase : MonoBehaviour
    {
        public float Speed = 5.0f;
        public abstract void Move(float x, float y, float z);
        /*private Rigidbody _rigidbody;
        public bool isImmortal = false;

        public void Start()
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

        protected void Moving()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            _rigidbody.AddForce(direction * Speed);
        }

        public void SpeedChange(float speedChangeValue)
        {
            Speed += speedChangeValue;
        }

        private void PlayerDeath()
        {
            if (!isImmortal){ Destroy(gameObject); }
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
        }*/
    }
}

