using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;
using DPiLL_CODE.Character;
using DPiLL_CODE.StateMachine;

namespace DPiLL_CODE.Other
{
    [RequireComponent(typeof(SphereCollider), typeof(Rigidbody))]
    public sealed class Projectile : MonoBehaviour, IStateMachineOwner
    {
        public Rigidbody Rigidbody { get; private set; }

        public int Hash => GetHashCode();

        private void Awake()
        {
            Rigidbody = GetComponent<Rigidbody>();
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.TryGetComponent<EnemyCharacter>(out var enemy))
            {
                ServiceLocator.Get<ProjectileService>().RemoveProjectile(this);
                ServiceLocator.Get<EnemyService>().HitEnemy(enemy);
            }
        }
    }
}
