using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace RollaBallGame
{
    public sealed class PointsChange
    {
        private int _playerPoints;
        private int _addPoints;

        public PointsChange()
        {
            _playerPoints = Object.FindObjectOfType<GameController>()._playerPoints;
            _addPoints = Object.FindObjectOfType<Artifact>().PointCount;
        }

        public void Change()
        {
            _playerPoints += _addPoints; 
        }

    }
}
