using System;
using System.Collections.Generic;
using UnityEngine;

using DPiLL_CODE.Character;
using DPiLL_CODE.Character.Modifire;
using DPiLL_CODE.Locator;
using DPiLL_CODE.Factory;
using DPiLL_CODE.Pool;
using DPiLL_CODE.StateMachine;
using DPiLL_CODE.StateMachine.State.Character.Player;
using DPiLL_CODE.GUI.MVC;
using DPiLL_CODE.GUI.CharacterInfoUI;
using DPiLL_CODE.GUI.PlayerJoystick;
using DPiLL_CODE.GUI.GameRestartScreen;

using Random = UnityEngine.Random;

namespace DPiLL_CODE.Service
{
    public sealed class PlayerService : IService
    {
        private readonly PlayerPool PlayerPool;
        private readonly Vector3 PlayerStartPosition;

        private LinkedList<CharacterModifre<PlayerCharacter>> _modifires;
        private int _maxPlayerHealth;
        private int _playerHealth;

        public PlayerService(Vector3 playerStartPosition)
        {
            PlayerPool = PoolLocator.Get<PlayerPool>();
            PlayerStartPosition = playerStartPosition;

            _modifires = new LinkedList<CharacterModifre<PlayerCharacter>>();
        }

        public PlayerCharacter PlayerCharacter { get; private set; }
        public Vector2 PlayerInputDirection { get; private set; }
        public int MaxPlayerHealth => _maxPlayerHealth;
        public int PlayerHealth => _playerHealth;

        public void CreatePlayer()
        {
            PlayerCharacter = PlayerPool.Spawn(PlayerStartPosition);
            PlayerCharacter.ChangeState<PlayerSetupState>();
            PlayerCharacter.Agent.enabled = false;
            PlayerCharacter.IsPlayerInBaseStatus = true;

            _playerHealth = PlayerCharacter.Setting.PlayerStartHealth;
            _maxPlayerHealth = PlayerCharacter.Setting.PlayerStartHealth;

            ConectorMVC.UpdateController<CharacterInfoUIController>();
            ConectorMVC.UpdateController<PlayerJoystickController>();
        }

        public void SetPlayerInput(float x, float y)
        {
            PlayerInputDirection = new Vector2(x, y);

            if (PlayerCharacter == null) return;


            if (PlayerInputDirection == default)
                PlayerCharacter.ChangeState<PlayerIdleState>();
            else
                PlayerCharacter.ChangeState<PlayerMovementState>();
        }

        public void DestroyPlayer()
        {
            if (PlayerCharacter == null) return;

            RemoveModifire<PlayerShootModifire>();
            RemoveModifire<PlayerTakeItemModifire>();            

            PlayerCharacter.Reset();
            PlayerPool.Despawn(PlayerCharacter);

            PlayerCharacter = null;
            PlayerInputDirection = default;

            var modifreNode = _modifires.First;

            while(modifreNode != null)
            {
                modifreNode.Value.Dispose();
                modifreNode = modifreNode.Next;
            }

            _modifires.Clear();
            _playerHealth = default;            
        }


        public void PlayerTakeDamage()
        {
            var damage = Random.Range(5, 10);

            _playerHealth -= damage;

            if (PlayerHealth <= 0)
            {
                DestroyPlayer();

                ConectorMVC.UpdateController<GameRestartScreenController>();
                ConectorMVC.UpdateController<PlayerJoystickController>();
            }

            ConectorMVC.UpdateController<CharacterInfoUIController>();
        }

        public void AddModifire<T>()
            where T : CharacterModifre<PlayerCharacter>
        {
            if (PlayerCharacter == null) return;

            using (var factory = new NativeObjectFactory<T>())
            {
                var modifire = factory.Create();
                modifire.SetTarget(PlayerCharacter);

                _modifires.AddLast(modifire);
            }
        }

        public void RemoveModifire<T>()
            where T : CharacterModifre<PlayerCharacter>
        {
            var modifireNode = _modifires.First;

            while(modifireNode != null)
            {
                if (modifireNode.Value.GetType().Equals(typeof(T)))
                {
                    _modifires.Remove(modifireNode);
                    modifireNode.Value.RemoveStateMachine();
                    modifireNode.Value.Dispose();
                    break;
                }
                modifireNode = modifireNode.Next;
            }
        }
    }
}
