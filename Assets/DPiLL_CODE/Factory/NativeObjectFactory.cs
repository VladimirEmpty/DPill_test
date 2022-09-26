using System;

namespace DPiLL_CODE.Factory
{
    public sealed class NativeObjectFactory<T> : IFactory<T>
        where T : class
    {
        private bool _isDisposed;

        public NativeObjectFactory()
        {
        }

        public T Prototype => null;

        public T Create()
        {
            return Activator.CreateInstance<T>(); 
        }

        public void Dispose()
        {
            if (_isDisposed) return;

            _isDisposed = true;
            GC.SuppressFinalize(this);
        }
    }
}
