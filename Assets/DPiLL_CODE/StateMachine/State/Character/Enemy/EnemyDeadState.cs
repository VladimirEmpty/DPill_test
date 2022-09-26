using System;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Character;

namespace DPiLL_CODE.StateMachine.State.Character.Enemy
{
    public sealed class EnemyDeadState : BaseEnemyState
    {
        public event Action<EnemyCharacter> OnEnemyDead;

        public override bool IsUpdatable => false;

        public override void Enter()
        {
            ServiceLocator.Get<PlayerItemService>().CreateCystal(StateOwner.transform.position);
            OnEnemyDead?.Invoke(StateOwner);
        }

        protected override void OnDispose()
        {
            OnEnemyDead = null;
        }
    }
}
