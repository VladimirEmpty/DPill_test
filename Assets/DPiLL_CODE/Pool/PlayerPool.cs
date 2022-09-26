using UnityEngine;

using DPiLL_CODE.Character;

namespace DPiLL_CODE.Pool
{
    public sealed class PlayerPool : BaseAllocatedGameObjectPool<PlayerCharacter>
    {
        public PlayerPool(PlayerCharacter prototype) : base(prototype) { }

        public PlayerCharacter Spawn(Vector3 position)
        {
            var player = base.Spawn();
            player.transform.position = position;

            return player;
        }

        protected override void OnDespawn(PlayerCharacter despawnedObject)
        {
            despawnedObject.gameObject.SetActive(false);
        }

        protected override void OnSpawn(PlayerCharacter spawnedObject)
        {
            spawnedObject.gameObject.SetActive(true);
        }
    }
}
