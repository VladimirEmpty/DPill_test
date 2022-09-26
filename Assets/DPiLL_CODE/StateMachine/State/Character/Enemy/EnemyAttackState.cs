using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE.StateMachine.State.Character.Enemy
{
    public sealed class EnemyAttackState : BaseEnemyState
    {
        private readonly EnemyService EnemyService;
        private readonly PlayerService PlayerService;

        public EnemyAttackState()
        {
            EnemyService = ServiceLocator.Get<EnemyService>();
            PlayerService = ServiceLocator.Get<PlayerService>();
        }

        public override bool IsUpdatable => false;

        public override void Enter()
        {
            StateOwner.transform.rotation = Quaternion.LookRotation(PlayerService.PlayerCharacter.transform.position - StateOwner.transform.position, Vector3.up);
            StateOwner.AnimationReciver.OnAnimationEvent += AttackAnimationEventHandling;
            StateOwner.Animator.CrossFade(CharacterAnimationName.Attack, default);
        }

        public override void Exit()
        {
            StateOwner.AnimationReciver.OnAnimationEvent -= AttackAnimationEventHandling;
        }

        private void AttackAnimationEventHandling()
        {
            if (PlayerService.PlayerCharacter != null 
                && EnemyService.GetDistanceToPlayer(StateOwner) <= StateOwner.Setting.AttackRange)
            {
                PlayerService.PlayerTakeDamage();
            }
            
            TransitToState<EnemyAttackReloadStsate>();
        }
    }
}
