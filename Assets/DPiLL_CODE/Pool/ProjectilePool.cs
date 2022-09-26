using UnityEngine;

using DPiLL_CODE.Other;

namespace DPiLL_CODE.Pool
{
    public sealed class ProjectilePool : BaseGameObjectPool<Projectile>
    {
        public ProjectilePool(Projectile prototype) : base(prototype) { }

        protected override void OnDespawn(Projectile despawnedObject)
        {
            despawnedObject.Rigidbody.velocity = Vector3.zero;
            despawnedObject.Rigidbody.angularVelocity = Vector3.zero;
            despawnedObject.gameObject.SetActive(false);
        }

        protected override void OnSpawn(Projectile spawnedObject)
        {
            spawnedObject.gameObject.SetActive(true);
        }
    }
}
