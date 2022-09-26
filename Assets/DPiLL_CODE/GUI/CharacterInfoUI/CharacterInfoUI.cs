using UnityEngine;
using UnityEngine.UI;
using TMPro;

using DPiLL_CODE.GUI.MVC;
using DPiLL_CODE.GUI.MVC.View;

namespace DPiLL_CODE.GUI.CharacterInfoUI
{
    public sealed class CharacterInfoUI : MonoBehaviour, IView
    {
        [SerializeField] private Slider _characterHealthSlider;
        [SerializeField] private TextMeshProUGUI _characterHealthValueText;

        public Slider CharacterHealthSlider => _characterHealthSlider;
        public TextMeshProUGUI CharacterHealthValueText => _characterHealthValueText;

        private void Start()
        {
            this.AddController<CharacterInfoUIController>();
        }

        private void LateUpdate()
        {
            transform.rotation = Quaternion.Euler(Vector3.right * -90f);
        }
    }
}
