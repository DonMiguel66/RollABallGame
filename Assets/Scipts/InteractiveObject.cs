using System;
using UnityEngine;
using Random = UnityEngine.Random;
using static UnityEngine.Debug;

namespace RollaBallGame 
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        public bool isInteractable { get; } = true;
        protected abstract void Interaction();

        public event Action OnTriggerChange;

        private void OnTriggerEnter(Collider other)
        {
            if(!isInteractable || !other.GetComponent<PlayerBall>())
            {
                return;
            }
            Interaction();
            OnTriggerChange();
            Destroy(gameObject);
        }
        private void Start()
        {
            ((IAction)this).Action();
        }
        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }
    }
}