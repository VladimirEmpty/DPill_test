using UnityEngine;

using DPiLL_CODE.Pool;
using DPiLL_CODE.Other;
using DPiLL_CODE.Locator;
using DPiLL_CODE.StateMachine;
using DPiLL_CODE.StateMachine.State.Projectiles;

namespace DPiLL_CODE.Service
{
    public sealed class ProjectileService : IService
    {
        private const float ProjectileForce = 10f;

        private readonly ProjectilePool ProjectilePool;

        public ProjectileService()
        {
            ProjectilePool = PoolLocator.Get<ProjectilePool>();
        }

        public void CreateProjectile(Transform firePoint)
        {
            var projectile = ProjectilePool.Spawn();
            projectile.ChangeState<ProejctileLifeTimeState>(state => state.StateOwner = projectile);
            projectile.transform.position = firePoint.position;
            projectile.Rigidbody.AddForce(firePoint.forward * ProjectileForce, ForceMode.VelocityChange);
        }

        public void RemoveProjectile(Projectile projectile)
        {
            projectile.RemoveStateMachine();
            ProjectilePool.Despawn(projectile);    
        }
    }
}
