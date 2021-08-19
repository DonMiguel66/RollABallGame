using System;

namespace RollaBallGame
{
    public interface IInteractable: IAction
    {
        bool _isInteractable { get; }
    }
}
