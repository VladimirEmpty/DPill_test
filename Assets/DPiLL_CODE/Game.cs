using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE
{
    public static class Game
    {
        public static void Start()
        {
            ServiceLocator.Get<PlayerService>().CreatePlayer();
            ServiceLocator.Get<EnemyService>().CreateEnemiesInArea();
        }

        public static void End()
        {
            ServiceLocator.Get<PlayerService>().DestroyPlayer();
            ServiceLocator.Get<EnemyService>().DestroyAllEnemy();
            ServiceLocator.Get<PlayerItemService>().DestroyAllItem();
        }
    }
}
