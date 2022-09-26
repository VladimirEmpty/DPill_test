using System.Collections.Generic;
using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Character;
using DPiLL_CODE.Character.Modifire;
using DPiLL_CODE.Setting;
using DPiLL_CODE.Pool;
using DPiLL_CODE.StateMachine;
using DPiLL_CODE.StateMachine.State.Character.Enemy;

using Random = UnityEngine.Random;

namespace DPiLL_CODE.Service
{
    public sealed class EnemyService : IService
    {
        private readonly PlayerService PlayerService;
        private readonly GameSetting GameSetting;
        private readonly EnemyPool EnemyPool;

        private LinkedList<EnemyCharacter> _enemyList;

        public EnemyService(EnemyArea enemyArea, GameSetting gameSetting)
        {
            PlayerService = ServiceLocator.Get<PlayerService>();
            GameSetting = gameSetting;
            EnemyArea = enemyArea;
            EnemyPool = PoolLocator.Get<EnemyPool>();

            _enemyList = new LinkedList<EnemyCharacter>();
        }

        public EnemyArea EnemyArea { get; }

        public void CreateEnemiesInArea()
        {
            var enemyCount = Random.Range(GameSetting.MinEnemyCount, GameSetting.MaxEnemyCount);

            for (var i = 0; i < enemyCount; ++i)
            {
                var randomPosition = new Vector3(
                    Random.Range(EnemyArea.AreaPoint1.position.x, EnemyArea.AreaPoint2.position.x),
                    EnemyArea.transform.position.y,
                    Random.Range(EnemyArea.AreaPoint1.position.z, EnemyArea.AreaPoint2.position.z));

                var enemy = EnemyPool.Spawn(randomPosition);
                enemy.Agent.enabled = false;
                enemy.ChangeState<PatrolState>();

                _enemyList.AddLast(enemy);
            }
        }

        public void HitEnemy(EnemyCharacter enemy)
        {
            enemy.ChangeState<EnemyDeadState>(state =>
            {
                state.StateOwner = enemy;
                state.OnEnemyDead += Remove;
            });
        }

        public void DestroyAllEnemy()
        {
            var enemyNode = _enemyList.First;

            while(enemyNode != null)
            {
                enemyNode.Value.Reset();
                EnemyPool.Despawn(enemyNode.Value);
                enemyNode = enemyNode.Next;
            }

            _enemyList.Clear();
        }

        public bool TryGetNearEnemyInRange(Vector3 position, float range, out EnemyCharacter nearEnemy)
        {
            nearEnemy = null;
            var enemyNode = _enemyList.First;
            var enemyDistance = 0f;
            var result = false;

            while(enemyNode != null)
            {
                enemyDistance = (enemyNode.Value.transform.position - position).magnitude;

                if(enemyDistance <= range)
                {
                    nearEnemy = enemyNode.Value;
                    result = true;
                    break;
                }

                enemyNode = enemyNode.Next;
            }

            return result;
        }

        public void PlayerBaseActionHandling()
        {
            PlayerService.PlayerCharacter.IsPlayerInBaseStatus = !PlayerService.PlayerCharacter.IsPlayerInBaseStatus;

            if (PlayerService.PlayerCharacter.IsPlayerInBaseStatus)
            {
                ForEachEnemyState<PatrolState>();
                PlayerService.RemoveModifire<PlayerShootModifire>();
                PlayerService.RemoveModifire<PlayerTakeItemModifire>();
                PlayerService.AddModifire<PlayerDropItemModifire>();
            }
            else
            { 
                ForEachEnemyState<HuntState>();
                PlayerService.AddModifire<PlayerShootModifire>();
                PlayerService.AddModifire<PlayerTakeItemModifire>();
                PlayerService.RemoveModifire<PlayerDropItemModifire>();
            }
        }

        public float GetDistanceToPlayer(EnemyCharacter character) => (PlayerService.PlayerCharacter.transform.position - character.transform.position).magnitude;
        public Vector3 PlayerPosition() => PlayerService.PlayerCharacter.transform.position;

        private void Remove(EnemyCharacter enemy)
        {
            enemy.Reset();
            _enemyList.Remove(enemy);
            EnemyPool.Despawn(enemy);
        }

        private void ForEachEnemyState<T>()
            where T : BaseEnemyState, new()
        {
            var enemyNode = _enemyList.First;

            while(enemyNode != null)
            {
                enemyNode.Value.ChangeState<T>();
                enemyNode = enemyNode.Next;
            }
        }
    }
}
