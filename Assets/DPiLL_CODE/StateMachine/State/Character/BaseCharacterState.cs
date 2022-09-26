using System;

using DPiLL_CODE.Character;

namespace DPiLL_CODE.StateMachine.State.Character
{
    public abstract class BaseCharacterState<T> : BaseState<T>
        where T : BaseCharacter
    {
        protected void TransitToState<State>(Action<State> onSetupCallback = null)
            where State : BaseCharacterState<T>, new()
        {
            StateOwner.ChangeState<State>(state =>
            {
                state.StateOwner = this.StateOwner;
                onSetupCallback?.Invoke(state);
            });
        }
    }
}
