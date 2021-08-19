using System.Collections.Generic;
using UnityEngine;

namespace RollaBallGame
{
    public sealed class IOSaveLoadController 
    {
        public ListExecuteObject ListObjects;

        public IOSaveLoadController(ListExecuteObject list)
        {
            ListObjects = list;
        }

    }
}
