using System;

using DPiLL_CODE.Character;
using DPiLL_CODE.Character.Modifire;

namespace DPiLL_CODE.StateMachine.State.Modifire
{
    public abstract class BaseModifireState<T> : BaseState<CharacterModifre<T>>
        where T : BaseCharacter
    {
        protected void TransitToState<State>(Action<State> onSetupCallback = null)
            where State : BaseModifireState<T>, new()
        {
            StateOwner.ChangeState<State>(state =>
            {
                state.StateOwner = this.StateOwner;
                onSetupCallback?.Invoke(state);
            });
        }
    }
}
