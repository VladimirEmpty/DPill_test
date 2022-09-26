using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.GUI.MVC.Model;

namespace DPiLL_CODE.GUI.CharacterInfoUI
{
    public sealed class CharacterInfoUIModel : IModel
    {
        private readonly PlayerService PlayerService;

        public CharacterInfoUIModel()
        {
            PlayerService = ServiceLocator.Get<PlayerService>();
        }

        public int HealthValue { get; private set; }
        public float HealthSliderAmount { get; private set; }
        public bool IsShowed { get; private set; }

        public void Request()
        {
            if (PlayerService.MaxPlayerHealth == 0) return;

            HealthValue = PlayerService.PlayerHealth;
            HealthSliderAmount = (float) PlayerService.PlayerHealth / PlayerService.MaxPlayerHealth;
            IsShowed = PlayerService.PlayerCharacter != null;
        }

        public void Update()
        {
        }
    }
}
