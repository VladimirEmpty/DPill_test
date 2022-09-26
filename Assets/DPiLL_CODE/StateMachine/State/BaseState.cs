using System;

namespace DPiLL_CODE.StateMachine.State
{
    public abstract class BaseState<T> : IState
        where T: class, IStateMachineOwner
    {
        private T _stateOwner;
        private bool _isDisposed;

        public BaseState()
        {                
        }

        public abstract bool IsUpdatable { get; }
        public T StateOwner
        {
            get => _stateOwner;
            set
            {
                if (_stateOwner != null) return;
                _stateOwner = value;
            }
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            OnDispose();

            _isDisposed = true;
            StateOwner = null;

            GC.SuppressFinalize(this);
        }

        public virtual void Enter() { }
        public virtual void Exit() { }
        public virtual void Update() { }

        protected virtual void OnDispose() { }
    }
}
