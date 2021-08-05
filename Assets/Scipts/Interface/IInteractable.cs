using System;

namespace RollaBallGame
{
    public interface IInteractable: IAction
    {
        bool isInteractable { get; }
    }
}
