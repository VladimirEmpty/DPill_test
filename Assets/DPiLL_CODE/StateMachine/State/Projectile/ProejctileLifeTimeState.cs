using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Other;

namespace DPiLL_CODE.StateMachine.State.Projectiles
{
    public sealed class ProejctileLifeTimeState : BaseState<Projectile>
    {
        private const float MaxLIfeTime = 5f;
        private float _currentLifeTime;

        public override bool IsUpdatable => true;

        public override void Update()
        {
            _currentLifeTime += Time.deltaTime;

            if(_currentLifeTime >= MaxLIfeTime)
            {
                ServiceLocator.Get<ProjectileService>().RemoveProjectile(StateOwner);
            }
        }
    }
}
