﻿using UnityEngine;

namespace RollaBallGame
{
    public sealed class MiniMapController : MonoBehaviour
    {
        private Transform _player;
        private void Start()
        {
            _player = Camera.main.transform;
            transform.parent = null;
            transform.rotation = Quaternion.Euler(90.0f, 0, 0);
            transform.position = _player.position + new Vector3(0, 5.0f, 0);

            var rt = Resources.Load<RenderTexture>("MiniMap/MiniMapTexture");

            GetComponent<Camera>().targetTexture = rt;
        }

        private void LateUpdate()
        {
            var newPosition = _player.position;
            newPosition.y = transform.position.y;
            transform.position = Vector3.Lerp(transform.position, newPosition, 0.125f);
            transform.rotation = Quaternion.Euler(90, _player.eulerAngles.y, 0);
        }
    }

}
