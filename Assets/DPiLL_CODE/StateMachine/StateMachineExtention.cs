using System;

using DPiLL_CODE.Character;
using DPiLL_CODE.StateMachine.State.Character.Enemy;
using DPiLL_CODE.StateMachine.State.Character.Player;

namespace DPiLL_CODE.StateMachine
{
    public static class StateMachineExtention
    {
        public static void ChangeState<T>(this EnemyCharacter owner, Action<T> onSetupStateCallback = null)
            where T : BaseEnemyState, new()
        {
            StateMachine.ChangeState<T>(owner, state =>
            {
                state.StateOwner = owner;
                onSetupStateCallback?.Invoke(state);
            });
        }

        public static void ChangeState<T>(this PlayerCharacter owner, Action<T> onSetupStateCallback = null)
            where T : BasePlayerState, new()
        {
            StateMachine.ChangeState<T>(owner, state =>
            {
                state.StateOwner = owner;
                onSetupStateCallback?.Invoke(state);
            });
        }
    }
}
