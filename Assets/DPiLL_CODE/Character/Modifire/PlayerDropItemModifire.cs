using DPiLL_CODE.StateMachine;
using DPiLL_CODE.StateMachine.State.Modifire.Player;

namespace DPiLL_CODE.Character.Modifire
{
    public sealed class PlayerDropItemModifire : CharacterModifre<PlayerCharacter>
    {
        public override void SetTarget(PlayerCharacter target)
        {
            base.SetTarget(target);
            this.ChangeState<PlayerDropItemState>(state => state.StateOwner = this);
        }
    }
}
