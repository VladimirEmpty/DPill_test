using UnityEngine;
using TMPro;

using DPiLL_CODE.GUI.MVC;
using DPiLL_CODE.GUI.MVC.View;

namespace DPiLL_CODE.GUI.GameInfoScreen
{
    public sealed class GameInfoScreen : MonoBehaviour, IView
    {
        [SerializeField] private TextMeshProUGUI _crystallValueText;

        public TextMeshProUGUI CrystallValueText => _crystallValueText;

        private void Start()
        {
            this.AddController<GameInfoScreenController>();
        }
    }
}
