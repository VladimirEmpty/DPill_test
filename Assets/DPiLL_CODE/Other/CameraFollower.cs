using UnityEngine;

using DPiLL_CODE.Character;

namespace DPiLL_CODE.Other
{
    public sealed class CameraFollower : MonoBehaviour
    {
        private PlayerCharacter _player;

        private Vector3 _offset;

        private void Awake()
        {
            _offset = transform.position;
        }

        private void LateUpdate()
        {
            if (_player == null) return;

            transform.position = _player.transform.position + _offset;
        }

        public void SetTarget(PlayerCharacter player)
        {
            _player = player;
        }
    }
}
