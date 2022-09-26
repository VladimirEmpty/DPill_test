using UnityEngine;

namespace DPiLL_CODE.StateMachine.State.Character.Enemy
{
    public sealed class EnemyAttackReloadStsate : BaseEnemyState
    {
        private float _reloadTimer;

        public override bool IsUpdatable => true;

        public override void Enter()
        {
            _reloadTimer = StateOwner.Setting.AttackReloadTime;
        }

        public override void Update()
        {
            _reloadTimer -= Time.deltaTime;

            if (_reloadTimer <= 0f)
                TransitToState<HuntState>();
        }
    }
}
