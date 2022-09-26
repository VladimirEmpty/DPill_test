using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Character;

namespace DPiLL_CODE.StateMachine.State.Modifire.Player
{
    public sealed class PlayerDropItemState : BaseModifireState<PlayerCharacter>
    {
        private const float MaxDropTimer = 0.4f;

        private readonly PlayerItemService PlayerItemService;
        private readonly EconomyService EconomyService;

        private float _currentDropTimer;

        public PlayerDropItemState()
        {
            PlayerItemService = ServiceLocator.Get<PlayerItemService>();
            EconomyService = ServiceLocator.Get<EconomyService>();
        }

        public override bool IsUpdatable => true;

        public override void Update()
        {
            _currentDropTimer -= Time.deltaTime;

            if (_currentDropTimer > 0) return;

            if (PlayerItemService.ItemCount <= 0)
            {
                StateOwner.Reset();
                return;
            }

            PlayerItemService.DropItem();
            EconomyService.CrystalCount++;

            _currentDropTimer = MaxDropTimer;
        }
    }
}
