using System;

namespace DPiLL_CODE.Factory
{
    public interface IFactory<T> : IDisposable
        where T : class
    {
        T Prototype { get; }
        T Create();
    }
}
