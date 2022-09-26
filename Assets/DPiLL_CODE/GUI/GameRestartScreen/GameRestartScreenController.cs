using DPiLL_CODE.GUI.MVC.Controller;

namespace DPiLL_CODE.GUI.GameRestartScreen
{
    public sealed class GameRestartScreenController : BaseUpdatableController<GameRestartScreen, GameRestartScreenModel>
    {
        public override string Tag => nameof(GameRestartScreenController);

        public override void UpdateView()
        {
            Model.Request();
            LinkedView.RestartPanel.SetActive(Model.IsShowed);
        }

        protected override void OnShow()
        {
            LinkedView.DebugRestartButton.onClick.AddListener(OnDebugButtonClickHandling);
            LinkedView.RestartButton.onClick.AddListener(OnRestartButtonClickHandling);
            UpdateView();
        }

        private void OnDebugButtonClickHandling()
        {
            LinkedView.RestartPanel.SetActive(true);
        }

        private void OnRestartButtonClickHandling()
        {
            Model.Update();
            UpdateView();
        }
    }
}
