using UnityEngine;

namespace RollaBallGame
{
    [CreateAssetMenu(menuName = "Data/Input", fileName = nameof(InputData))]
    public sealed class InputData : ScriptableObject
    {
        public KeyCode Save= KeyCode.C;
        public KeyCode Load = KeyCode.V;
        public KeyCode SaveAll = KeyCode.Y;
        public KeyCode LoadAll = KeyCode.U;

    }
}
