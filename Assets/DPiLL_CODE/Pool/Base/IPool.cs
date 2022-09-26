using System;

using DPiLL_CODE.Factory;

namespace DPiLL_CODE.Pool
{
    public interface IPool<T> : IContainablePool
        where T : UnityEngine.Object
    {
        IFactory<T> Factory { get; }

        public T Spawn();
        public void Despawn(T despawnedObject);
    }
}
