using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Character;

namespace DPiLL_CODE.StateMachine.State.Modifire.Player
{
    public sealed class PlayerShootState : BaseModifireState<PlayerCharacter>
    {
        public Transform target;

        public PlayerShootState() { }

        public override bool IsUpdatable => false;

        public override void Enter()
        {
            var projectileService = ServiceLocator.Get<ProjectileService>();

            var direction = target.position - StateOwner.TargetCharacter.transform.position;
            StateOwner.TargetCharacter.FirePoint.transform.rotation = Quaternion.LookRotation(direction);
            projectileService.CreateProjectile(StateOwner.TargetCharacter.FirePoint);

            TransitToState<PlayerReloadShootState>();
        }
    }
}
