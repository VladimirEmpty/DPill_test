using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Character;

namespace DPiLL_CODE.StateMachine.State.Modifire.Player
{
    public sealed class PlayerTakeItemState : BaseModifireState<PlayerCharacter>
    {
        private const float MaxSearchTimer = 0.2f;
        private readonly PlayerItemService PlayerItemService;

        private float _searchTimer;

        public PlayerTakeItemState()
        {
            PlayerItemService = ServiceLocator.Get<PlayerItemService>();
            _searchTimer = MaxSearchTimer;
        }

        public override bool IsUpdatable => true;

        public override void Update()
        {
            _searchTimer -= Time.deltaTime;

            if (_searchTimer > 0f) return;

            if(PlayerItemService.TryTakeItemInRange(
                                        StateOwner.TargetCharacter.transform.position,
                                        StateOwner.TargetCharacter.Setting.PlayerTakeItemRange,
                                        out var item))
            {
                item.transform.SetParent(StateOwner.TargetCharacter.ItemPoint);
                item.transform.localPosition = Vector3.zero;
                item.transform.localPosition = Vector3.up * StateOwner.TargetCharacter.Setting.PlayerInvnetoryItemOffset * (PlayerItemService.ItemCount - 1);
            }

            _searchTimer = MaxSearchTimer;
        }
    }
}
