using UnityEngine;

namespace DPiLL_CODE.StateMachine.State.Character.Enemy
{
    public sealed class PatrolState : BaseEnemyState
    {
        private float _timer;

        public override bool IsUpdatable => true;

        public override void Enter()
        {
            _timer = Random.Range(StateOwner.Setting.PatrolTime/2, StateOwner.Setting.PatrolTime);
            StateOwner.Agent.enabled = true;
            StateOwner.Animator.CrossFade(CharacterAnimationName.Idle, default);
        }

        public override void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer > 0f) return;

            TransitToState<PatrolMovementState>();
        }
    }
}
