using System;

using DPiLL_CODE.StateMachine;

namespace DPiLL_CODE.Character.Modifire
{
    public abstract class CharacterModifre<T> : IStateMachineOwner, IDisposable
        where T : BaseCharacter
    {
        private bool _isDisposed;
        
        public T TargetCharacter { get; private set; }
        public int Hash => GetHashCode();

        public void Dispose()
        {
            if (_isDisposed) return;

            TargetCharacter = null;
            _isDisposed = true;

            GC.SuppressFinalize(this);
        }

        public virtual void SetTarget(T target) => TargetCharacter = target;
    }
}
