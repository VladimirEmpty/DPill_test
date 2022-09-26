using UnityEngine;
using UnityEngine.UI;

using DPiLL_CODE.GUI.MVC;
using DPiLL_CODE.GUI.MVC.View;

namespace DPiLL_CODE.GUI.GameRestartScreen
{
    public sealed class GameRestartScreen : MonoBehaviour, IView
    {
        [SerializeField] private Button _debugRestartButton;
        [SerializeField] private Button _restartButton;
        [SerializeField] private GameObject _restartPanel;

        public Button DebugRestartButton => _debugRestartButton;
        public Button RestartButton => _restartButton;
        public GameObject RestartPanel => _restartPanel;

        private void Start()
        {
            this.AddController<GameRestartScreenController>();
        }
    }
}
