using UnityEngine;

using DPiLL_CODE.Setting;
using DPiLL_CODE.GUI.CharacterInfoUI;


namespace DPiLL_CODE.Character
{
    [RequireComponent(typeof(Rigidbody))]
    public sealed class PlayerCharacter : BaseCharacter
    {
        [SerializeField] private PlayerCharacterSetting _setting;
        [SerializeField] private Transform _firePoint;
        [SerializeField] private Transform _itemPoint;

        public PlayerCharacterSetting Setting => _setting;
        public Transform FirePoint => _firePoint;
        public Transform ItemPoint => _itemPoint;
        public bool IsPlayerInBaseStatus { get; set; }
    }
}
