using System;
using UnityEngine;

namespace DPiLL_CODE.Character
{
    public sealed class AnimationEventReciver : MonoBehaviour
    {
        public event Action OnAnimationEvent;

        public void AnimationEventHandling() => OnAnimationEvent?.Invoke();
    }
}
