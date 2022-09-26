using UnityEngine;

namespace DPiLL_CODE.Setting
{
    [CreateAssetMenu(fileName = nameof(GameSetting), menuName = "Settings/GameSetting")]
    public sealed class GameSetting : ScriptableObject
    {
        [SerializeField] private int _minEnemyCount;
        [SerializeField] private int _maxEnemtCount;

        [SerializeField][Range(0f,100f)] private float _createCrystallChance;

        public int MinEnemyCount => _minEnemyCount;
        public int MaxEnemyCount => _maxEnemtCount;

        public float CreateCrystallChance => _createCrystallChance / 100f;
    }
}
