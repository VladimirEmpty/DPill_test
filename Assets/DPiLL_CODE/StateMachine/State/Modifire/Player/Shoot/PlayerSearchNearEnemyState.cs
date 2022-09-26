using UnityEngine;

using DPiLL_CODE.Character;
using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE.StateMachine.State.Modifire.Player
{
    public sealed class PlayerSearchNearEnemyState : BaseModifireState<PlayerCharacter>
    {
        private const float MaxSearchTimer = 0.4f;

        private readonly EnemyService EnemyService;

        private float _searchTimer;

        public PlayerSearchNearEnemyState()
        {            
            EnemyService = ServiceLocator.Get<EnemyService>();
        }

        public override bool IsUpdatable => true;

        public override void Update()
        {
            _searchTimer += Time.deltaTime;

            if (_searchTimer < MaxSearchTimer) return;

            if(EnemyService.TryGetNearEnemyInRange(
                                StateOwner.TargetCharacter.transform.position, 
                                StateOwner.TargetCharacter.Setting.PlayerAttackRange, 
                                out var nearEnemy))
            {
                TransitToState<PlayerShootState>(state => state.target = nearEnemy.transform);
            }

            _searchTimer = default;
        }
    }
}
