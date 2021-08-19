using System.Collections.Generic;

namespace RollaBallGame
{
    public interface ISaveInteractiveObject
    {
        void SaveIO(ListExecuteObject interactiveObjects);
        void LoadIO(ListExecuteObject interactiveObjects);
    }
}
