using UnityEngine;

using DPiLL_CODE.Character;

namespace DPiLL_CODE.Pool
{
    public sealed class EnemyPool : BaseAllocatedGameObjectPool<EnemyCharacter>
    {
        public EnemyPool(EnemyCharacter prototype) : base(prototype) { }

        public EnemyCharacter Spawn(Vector3 position)
        {
            var enemy = base.Spawn();
            enemy.transform.position = position;
            enemy.transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(-360f, 360f));

            return enemy;
        }

        protected override void OnDespawn(EnemyCharacter despawnedObject)
        {
            despawnedObject.gameObject.SetActive(false);
        }

        protected override void OnSpawn(EnemyCharacter spawnedObject)
        {
            spawnedObject.gameObject.SetActive(true);
        }
    }
}
