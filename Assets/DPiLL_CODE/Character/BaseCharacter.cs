using UnityEngine;
using UnityEngine.AI;

using DPiLL_CODE.StateMachine;

namespace DPiLL_CODE.Character
{
    [RequireComponent(typeof(NavMeshAgent), typeof(CapsuleCollider))]
    public abstract class BaseCharacter : MonoBehaviour, IStateMachineOwner
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationEventReciver _animationReciver;

        public Animator Animator => _animator;
        public AnimationEventReciver AnimationReciver => _animationReciver;
        public NavMeshAgent Agent { get; private set; }
        public int Hash => GetHashCode();

        private void Awake()
        {
            Agent = GetComponent<NavMeshAgent>();
        }
    }
}

