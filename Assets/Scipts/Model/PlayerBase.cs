﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Debug;

namespace RollaBallGame
{
    public abstract class PlayerBase : MonoBehaviour
    {
        [Header("Скорость игрока")]
        [Range(0.1f, 10f)]
        public float Speed = 5.0f;
        //public static bool Immortal = false; - вариант, что бы инф-я о бессмертности игрока была в PlayerBase
        public abstract void Move(float x, float y, float z);
    }
}

