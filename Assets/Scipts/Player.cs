using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollaBallGame
{
    public abstract class Player : MonoBehaviour
    {
        public float Speed = 5.0f;
        private Rigidbody _rigidbody;
        public bool isImmortal = false;

        public void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        protected void Moving()
        {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");

            Vector3 direction = new Vector3(horizontal, 0f, vertical);

            _rigidbody.AddForce(direction * Speed);
        }

        public IEnumerator SetImmortal(float time)
        {
            Log(Time.deltaTime);
            isImmortal = true;
            yield return new WaitForSeconds(time);
            isImmortal = false;
            Log(Time.deltaTime);
        }
    }
}

