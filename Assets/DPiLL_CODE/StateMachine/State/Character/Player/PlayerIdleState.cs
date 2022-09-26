namespace DPiLL_CODE.StateMachine.State.Character.Player
{
    public sealed class PlayerIdleState : BasePlayerState
    {
        public override bool IsUpdatable => false;

        public override void Enter()
        {
            StateOwner.Animator.CrossFade(CharacterAnimationName.Idle, default);
        }

        public override void Exit()
        {
            StateOwner.Animator.CrossFade(CharacterAnimationName.Run, 0.1f);
        }        
    }
}
