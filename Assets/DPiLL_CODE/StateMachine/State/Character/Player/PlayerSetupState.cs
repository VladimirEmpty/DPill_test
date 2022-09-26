using UnityEngine;

using DPiLL_CODE.Other;

namespace DPiLL_CODE.StateMachine.State.Character.Player
{
    public sealed class PlayerSetupState : BasePlayerState
    {
        public override bool IsUpdatable => false;

        public override void Enter()
        {
            if(Camera.main.gameObject.TryGetComponent<CameraFollower>(out var cameraFollower))
            {
                cameraFollower.SetTarget(StateOwner);
            }

            TransitToState<PlayerIdleState>();
        }
    }
}
