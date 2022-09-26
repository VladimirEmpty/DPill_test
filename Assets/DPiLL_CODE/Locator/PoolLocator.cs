using System;

using DPiLL_CODE.Pool;
using DPiLL_CODE.Factory;

namespace DPiLL_CODE.Locator
{
    public static class PoolLocator 
    {
        private static Locator<IContainablePool> _locator;

        static PoolLocator()
        {
            using (var factory = new NativeObjectFactory<Locator<IContainablePool>>())
            {
                _locator = factory.Create();
            }
        }

        public static void Add<T>(Action<T> onSetupCallback = null)
            where T : class, IContainablePool
        {
            using (var factory = new NativeObjectFactory<T>())
            {
                var objectImplementation = factory.Create();
                onSetupCallback?.Invoke(objectImplementation);
                _locator.Add(objectImplementation);
            }
        }

        public static void Add<T>(T service)
            where T : class, IContainablePool
        {
            _locator.Add(service);
        }

        public static T Get<T>()
            where T : class, IContainablePool
        {
            return _locator.Get<T>();
        }
    }
}
