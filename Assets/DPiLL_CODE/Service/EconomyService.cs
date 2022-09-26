using DPiLL_CODE.GUI.MVC;
using DPiLL_CODE.GUI.GameInfoScreen;

namespace DPiLL_CODE.Service
{
    public sealed class EconomyService : IService
    {
        private int _crystallCount;

        public int CrystalCount
        {
            get => _crystallCount;
            set => SetCrystalCount(value);
        }

        private void SetCrystalCount(int value)
        {
            _crystallCount = value;
            ConectorMVC.UpdateController<GameInfoScreenController>();
        }
    }
}
