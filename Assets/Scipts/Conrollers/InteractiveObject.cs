using System;
using UnityEngine;
using Random = UnityEngine.Random;
using static UnityEngine.Debug;

namespace RollaBallGame 
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable, IExecute
    {
        public bool isInteractable { get; } = true;
        public bool _isInteractable ;
        protected abstract void Interaction();
        public abstract void Execute();
        protected bool IsInteractable
        {
            get { return _isInteractable; }
            private set 
            {
                _isInteractable = value;
                //GetComponent<Renderer>().enabled = _isInteractable;
                GetComponent<Collider>().enabled = _isInteractable;
            }
        }

        public event Action OnTriggerChange; //Событие, на которое будет подписана камера

        private void OnTriggerEnter(Collider other)
        {
            if(!isInteractable || !other.GetComponent<PlayerBall>())
            {
                return;
            }
            Interaction();
            OnTriggerChange();
            IsInteractable = false;
            Destroy(gameObject);
        }
        private void Start()
        {
            IsInteractable = true;
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