using UnityEngine;

using DPiLL_CODE.GUI.CharacterInfoUI;

namespace DPiLL_CODE.Setting
{
    [CreateAssetMenu(fileName = nameof(PlayerCharacterSetting), menuName = "Settings/PlayerCharacter")]
    public sealed class PlayerCharacterSetting : ScriptableObject
    {
        [SerializeField] private int _playerStartHealth;
        [SerializeField] private float _playerSpeed;
        [SerializeField] private float _playerReloadTime;
        [SerializeField] private float _playerAttackRange;
        [SerializeField] private float _playerTakeItemRange;
        [SerializeField] private float _playerInventoryItemOffset;

        public int PlayerStartHealth => _playerStartHealth;
        public float PlayerSpeed => _playerSpeed;
        public float PlayerReloadTime => _playerReloadTime;
        public float PlayerAttackRange => _playerAttackRange;
        public float PlayerTakeItemRange => _playerTakeItemRange;
        public float PlayerInvnetoryItemOffset => _playerInventoryItemOffset;
    }
}
