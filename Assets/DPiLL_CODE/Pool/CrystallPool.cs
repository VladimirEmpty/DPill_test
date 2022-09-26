using UnityEngine;

namespace DPiLL_CODE.Pool
{
    public sealed class CrystallPool : BaseAllocatedGameObjectPool<GameObject>
    {
        public CrystallPool(GameObject prototype) : base(prototype) { }

        protected override void OnDespawn(GameObject despawnedObject)
        {
            despawnedObject.SetActive(false);
            despawnedObject.transform.SetParent(null);
        }

        protected override void OnSpawn(GameObject spawnedObject)
        {
            spawnedObject.SetActive(true);
        }
    }
}
