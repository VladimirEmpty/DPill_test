using System;

using DPiLL_CODE.StateMachine.State;

namespace DPiLL_CODE.StateMachine
{
    public sealed class Machine : IMachine
    {
        private bool _isDisposed;

        public Machine()
        {
        }

        public IState CurrentState { get; private set; }

        private event Action OnUpdate;

        public void ChangeState(IState state)
        {
            if (CurrentState != null)
            {
                OnUpdate = null;
                CurrentState.Exit();
                CurrentState.Dispose();
            }

            CurrentState = state;
            CurrentState.Enter();

            if (CurrentState.IsUpdatable)
            {
                OnUpdate = CurrentState.Update;
            }
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            CurrentState?.Dispose();

            OnUpdate = null;
            CurrentState = null;
            _isDisposed = true;

            GC.SuppressFinalize(this);
        }

        public void Update() => OnUpdate?.Invoke();
    }
}
