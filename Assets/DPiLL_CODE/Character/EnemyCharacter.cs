using System;
using UnityEngine;

using DPiLL_CODE.Setting;
using DPiLL_CODE.StateMachine;
using DPiLL_CODE.StateMachine.State.Character.Enemy;

namespace DPiLL_CODE.Character
{
    public sealed class EnemyCharacter : BaseCharacter
    {
        [SerializeField] private EnemyCharacterSetting _setting;

        public EnemyCharacterSetting Setting => _setting;       
    }
}
