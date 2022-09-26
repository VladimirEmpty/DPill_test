using DPiLL_CODE.GUI.MVC.Controller;

namespace DPiLL_CODE.GUI.GameInfoScreen
{
    public sealed class GameInfoScreenController : BaseUpdatableController<GameInfoScreen, GameInfoScreenModel>
    {
        public override string Tag => nameof(GameInfoScreenController);

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.CrystallValueText.text = Model.CrystallCount.ToString();
        }

        protected override void OnShow() => UpdateView();
    }
}
