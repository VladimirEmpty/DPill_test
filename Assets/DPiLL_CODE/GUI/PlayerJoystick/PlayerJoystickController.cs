using DPiLL_CODE.GUI.MVC.Controller;

namespace DPiLL_CODE.GUI.PlayerJoystick
{
    public sealed class PlayerJoystickController : BaseUpdatableController<Joystick, PlayerJoystickModel>
    {
        public override string Tag => nameof(PlayerJoystickController);

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.CanvasGroup.blocksRaycasts = Model.IsIntactable;
            LinkedView.CanvasGroup.alpha = Model.IsIntactable ? 1f : 0f;
        }

        protected override void OnShow()
        {
            LinkedView.OnPlayerDrag += OnPlayerInputHandling;
            LinkedView.OnPlayerEndDrag += OnPlayerInputHandling;
        }

        private void OnPlayerInputHandling()
        {
            Model.inputX = LinkedView.Horizontal;
            Model.inputY = LinkedView.Vertical;

            Model.Update();
        }
    }
}
