using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.GUI.MVC.Model;

namespace DPiLL_CODE.GUI.GameRestartScreen
{
    public sealed class GameRestartScreenModel : IModel
    {
        private readonly PlayerService PlayerService;

        public GameRestartScreenModel()
        {
            PlayerService = ServiceLocator.Get<PlayerService>();
        }

        public bool IsShowed { get; private set; }

        public void Request()
        {
            IsShowed = PlayerService.PlayerCharacter == null;
        }

        public void Update()
        {
            Game.End();
            Game.Start();
        }
    }
}
