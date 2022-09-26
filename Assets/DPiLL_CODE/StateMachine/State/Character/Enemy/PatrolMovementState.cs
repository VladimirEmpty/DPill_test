using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE.StateMachine.State.Character.Enemy
{
    public sealed class PatrolMovementState : BaseEnemyState
    {
        public override bool IsUpdatable => true;

        public override void Enter()
        {
            var enemyService = ServiceLocator.Get<EnemyService>();
            var randomPoint = new Vector3(
                    Random.Range(enemyService.EnemyArea.AreaPoint1.position.x, enemyService.EnemyArea.AreaPoint2.position.x),
                    enemyService.EnemyArea.transform.position.y,
                    Random.Range(enemyService.EnemyArea.AreaPoint1.position.z, enemyService.EnemyArea.AreaPoint2.position.z));

            StateOwner.Animator.CrossFade(CharacterAnimationName.Walk, default);
            StateOwner.Agent.speed = StateOwner.Setting.PatrolSpeed;
            StateOwner.Agent.SetDestination(randomPoint);
        }

        public override void Update()
        {
            if (StateOwner.Agent.path.corners.Length > 1) return;

            TransitToState<PatrolState>();//NEED transit to chek state
        }
    }
}
