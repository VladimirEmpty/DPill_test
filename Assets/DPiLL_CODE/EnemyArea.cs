using UnityEngine;

namespace DPiLL_CODE
{
    public sealed class EnemyArea : MonoBehaviour
    {
        [SerializeField] private Transform _areaPoint1;
        [SerializeField] private Transform _areaPoint2;

        public Transform AreaPoint1 => _areaPoint1;
        public Transform AreaPoint2 => _areaPoint2;
    }
}
