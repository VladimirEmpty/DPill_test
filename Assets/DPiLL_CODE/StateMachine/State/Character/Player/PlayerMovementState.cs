using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE.StateMachine.State.Character.Player
{
    public sealed class PlayerMovementState : BasePlayerState
    {
        private PlayerService _playerService;

        public override bool IsUpdatable => true;

        public override void Enter()
        {
            _playerService = ServiceLocator.Get<PlayerService>();
            StateOwner.Agent.speed = StateOwner.Setting.PlayerSpeed;
            StateOwner.Agent.enabled = true;
        }

        public override void Update()
        {
            var playerInput = -_playerService.PlayerInputDirection;

            StateOwner.Agent.velocity = new Vector3(playerInput.x, default, playerInput.y) * StateOwner.Setting.PlayerSpeed;
        }

        public override void Exit()
        {
            StateOwner.Agent.velocity = Vector3.zero;
            StateOwner.Agent.enabled = false;
        }
    }
}
