using DPiLL_CODE.GUI.MVC.Controller;

namespace DPiLL_CODE.GUI.CharacterInfoUI
{
    public sealed class CharacterInfoUIController : BaseUpdatableController<CharacterInfoUI, CharacterInfoUIModel>
    {
        public override string Tag => nameof(CharacterInfoUIController);

        public override void UpdateView()
        {
            Model.Request();

            LinkedView.CharacterHealthSlider.enabled = Model.IsShowed;
            LinkedView.CharacterHealthSlider.value = Model.HealthSliderAmount;
            LinkedView.CharacterHealthValueText.text = Model.HealthValue.ToString();
        }

        protected override void OnShow() => UpdateView();
    }
}
