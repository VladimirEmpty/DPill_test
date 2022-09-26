using System;
using UnityEngine;

namespace DPiLL_CODE
{
    public sealed class GameUpdater : MonoBehaviour
    {
        public event Action OnUpdate;

        private void Start()
        {
            DontDestroyOnLoad(this);
        }

        private void Update()
        {
            OnUpdate?.Invoke();
        }
    }
}
