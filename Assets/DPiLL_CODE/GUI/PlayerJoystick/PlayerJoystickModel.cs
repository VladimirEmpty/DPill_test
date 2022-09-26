using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.GUI.MVC.Model;

namespace DPiLL_CODE.GUI.PlayerJoystick
{
    public sealed class PlayerJoystickModel : IModel
    {
        private readonly PlayerService PlayerService;

        public float inputX;
        public float inputY;

        public PlayerJoystickModel()
        {
            PlayerService = ServiceLocator.Get<PlayerService>();
        }

        public bool IsIntactable { get; private set; }

        public void Request()
        {
            IsIntactable = PlayerService.PlayerCharacter != null;
        }

        public void Update()
        {
            PlayerService.SetPlayerInput(inputX, inputY);

            inputX = default;
            inputY = default;
        }
    }
}
