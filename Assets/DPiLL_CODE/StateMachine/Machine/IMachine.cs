using System;
using DPiLL_CODE.StateMachine.State;

namespace DPiLL_CODE.StateMachine
{
    public interface IMachine : IDisposable
    {
        public IState CurrentState { get; }

        public void ChangeState(IState state);
        public void Update();
    }
}
