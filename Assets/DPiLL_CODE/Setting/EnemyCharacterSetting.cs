using UnityEngine;

namespace DPiLL_CODE.Setting
{
    [CreateAssetMenu(fileName = nameof(EnemyCharacterSetting), menuName = "Settings/EnemyCharacter")]
    public sealed class EnemyCharacterSetting : ScriptableObject
    {
        [SerializeField] private float _patrolSpeed;
        [SerializeField] private float _patrolTime;
        [SerializeField] private float _huntSpeed;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _attackReloadTime;

        public float PatrolSpeed => _patrolSpeed;
        public float PatrolTime => _patrolTime;

        public float HuntSpeed => _huntSpeed;
        public float AttackRange => _attackRange;
        public float AttackReloadTime => _attackReloadTime;
    }
}
