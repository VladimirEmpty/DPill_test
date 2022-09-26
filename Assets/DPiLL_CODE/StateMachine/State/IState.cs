using System;

namespace DPiLL_CODE.StateMachine.State
{
    public interface IState : IDisposable
    {
        bool IsUpdatable { get; }
        void Enter();
        void Update();
        void Exit();
    }
}
