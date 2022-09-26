using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE.StateMachine.State.Character.Enemy
{
    public sealed class HuntState : BaseEnemyState
    {
        private readonly EnemyService EnemyService;
        private readonly PlayerService PlayerService;

        public HuntState()
        {
            EnemyService = ServiceLocator.Get<EnemyService>();
            PlayerService = ServiceLocator.Get<PlayerService>();
        }

        public override bool IsUpdatable => true;

        public override void Enter()
        {
            StateOwner.Agent.ResetPath();
            StateOwner.Animator.CrossFade(CharacterAnimationName.Run, 0.15f);
        }

        public override void Update()
        {
            if(PlayerService.PlayerCharacter == null)
            {
                TransitToState<PatrolState>();
                return;
            }

            if (EnemyService.GetDistanceToPlayer(StateOwner) <= StateOwner.Setting.AttackRange)
            {
                TransitToState<EnemyAttackState>();
            }
            else
            {
                StateOwner.transform.rotation = Quaternion.LookRotation(PlayerService.PlayerCharacter.transform.position - StateOwner.transform.position, Vector3.up);
                StateOwner.Agent.velocity = StateOwner.transform.forward * StateOwner.Setting.HuntSpeed;
            }
        }
    }
}
