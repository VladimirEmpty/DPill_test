using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Character;
using DPiLL_CODE.Pool;
using DPiLL_CODE.Other;
using DPiLL_CODE.Setting;

using DPiLL_CODE.GUI.MVC;
using DPiLL_CODE.GUI.CharacterInfoUI;

namespace DPiLL_CODE.Installer
{
    public sealed class GameInstaller : MonoBehaviour
    {
        [Header("Gameplay Setting")]
        [SerializeField] private GameSetting _gameSetting;
        [SerializeField] private Transform _playerStartPosition;
        [SerializeField] private EnemyArea _enemyArea;

        [Header("Resource Setting")]
        [SerializeField] private EnemyCharacter _enemyCharacterPrefab;
        [SerializeField] private PlayerCharacter _playerCharacterPrefab;
        [SerializeField] private Projectile _projectilePrefab;
        [SerializeField] private GameObject _crystallPrefab;

        private void Reset()
        {
            gameObject.name = nameof(GameInstaller);
        }

        private void Awake()
        {
            var enemyPool = new EnemyPool(_enemyCharacterPrefab);
            var playerPool = new PlayerPool(_playerCharacterPrefab);
            var projectilePool = new ProjectilePool(_projectilePrefab);
            var crystallPool = new CrystallPool(_crystallPrefab);

            PoolLocator.Add(enemyPool);
            PoolLocator.Add(playerPool);
            PoolLocator.Add(projectilePool);
            PoolLocator.Add(crystallPool);
            
            var playerService = new PlayerService(_playerStartPosition.position);
            ServiceLocator.Add(playerService);

            var playerItemService = new PlayerItemService(_gameSetting);
            ServiceLocator.Add(playerItemService);

            var enemyService = new EnemyService(_enemyArea, _gameSetting);                        
            ServiceLocator.Add(enemyService);

            ServiceLocator.Add<ProjectileService>();
            ServiceLocator.Add<EconomyService>();

            Game.Start();
        }

        private void Start() => Destroy(gameObject);
    }
}
