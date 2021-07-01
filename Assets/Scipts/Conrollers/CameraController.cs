using System;
using System.Data;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RollaBallGame 
{
    public class CameraController : IExecute
    {
        //public Player Player;
        private Transform _player;
        private Transform _mainCamera;
        private Vector3 _translation;

        private InteractiveObject _interactiveObject;
        private Animator _animator;

        public CameraController(Transform player, Transform mainCamera)
        {
            _player = player;
            _mainCamera = mainCamera;
            _mainCamera.LookAt(_player);
            _translation = _mainCamera.position - _player.position;
        }

        public void Execute()
        {
            _mainCamera.position = _player.position + _translation;
        }

        /*private void Start()
        {
            _animator = GetComponent<Animator>();
            _translation = transform.position - Player.transform.position;
            foreach (var interactiveObject in FindObjectsOfType<InteractiveObject>())
            {
                interactiveObject.OnTriggerChange += CameraAnims;
            } // Подписка на событие
            ExeptionCheck(); //Вызов метода проверки исключения (Наличие ссылки на Игрока)
        }

        private void ExeptionCheck() //Метод проверки наличия ссылки на Игрока
        {
            if (Player == null)
                throw new DataException($"Player not found");
        }

        private void Update()
        {
            transform.position = Player.transform.position + _translation;
        }
        public void CameraAnims()
        {
            StartCoroutine(CameraBreeze());
        }

        private IEnumerator CameraBreeze() //Корутин на включение анимации (упрощённый, без триггеров)
        {
            _animator.enabled = true;
            yield return new WaitForSeconds(1f);
            _animator.enabled = false;
        }

        public void OnDestroy()
        {
            foreach (var interactiveObject in FindObjectsOfType<InteractiveObject>())
            {
                interactiveObject.OnTriggerChange -= CameraAnims;
            }
        }*/

    }
}

