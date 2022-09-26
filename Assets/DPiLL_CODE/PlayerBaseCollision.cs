using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Service;

namespace DPiLL_CODE
{
    [RequireComponent(typeof(BoxCollider), typeof(Rigidbody))]
    public sealed class PlayerBaseCollision : MonoBehaviour
    {
        [SerializeField] private PlayerBaseCollision _switchedTrigger;
        [SerializeField] private bool _isStartEnable;

        private void Awake()
        {
            this.gameObject.SetActive(_isStartEnable);
        }

        private void OnTriggerEnter(Collider other)
        {
            ServiceLocator.Get<EnemyService>().PlayerBaseActionHandling();
            this.gameObject.SetActive(false);
            _switchedTrigger.gameObject.SetActive(true);
        }
    }
}
