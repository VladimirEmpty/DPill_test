using UnityEngine;

using DPiLL_CODE.Character;

namespace DPiLL_CODE.StateMachine.State.Modifire.Player
{
    public sealed class PlayerReloadShootState : BaseModifireState<PlayerCharacter>
    {
        private float _timer;
        public override bool IsUpdatable => true;

        public override void Enter()
        {
            _timer = StateOwner.TargetCharacter.Setting.PlayerReloadTime;
        }

        public override void Update()
        {
            _timer -= Time.deltaTime;

            if (_timer <= 0f)
                TransitToState<PlayerSearchNearEnemyState>();
        }
    }
}
