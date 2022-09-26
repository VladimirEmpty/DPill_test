using DPiLL_CODE.GUI.MVC.Model;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE.GUI.GameInfoScreen
{
    public sealed class GameInfoScreenModel : IModel
    {
        private readonly EconomyService EconomyService;

        public GameInfoScreenModel()
        {
            EconomyService = ServiceLocator.Get<EconomyService>();
        }

        public int CrystallCount { get; private set; }

        public void Request()
        {
            CrystallCount = EconomyService.CrystalCount;
        }

        public void Update() { }
    }
}
