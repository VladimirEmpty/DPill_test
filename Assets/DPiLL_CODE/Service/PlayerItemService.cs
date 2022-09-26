using System;
using System.Collections.Generic;
using UnityEngine;

using DPiLL_CODE.Locator;
using DPiLL_CODE.Setting;
using DPiLL_CODE.Pool;

using Random = UnityEngine.Random;

namespace DPiLL_CODE.Service
{
    public sealed class PlayerItemService : IService
    {
        private readonly GameSetting GameSetting;
        private readonly CrystallPool CrystallPool;

        private LinkedList<GameObject> _itemsInScene;
        private LinkedList<GameObject> _itemsInInventory;

        public PlayerItemService(GameSetting gameSetting)
        {
            GameSetting = gameSetting;
            CrystallPool = PoolLocator.Get<CrystallPool>();

            _itemsInScene = new LinkedList<GameObject>();
            _itemsInInventory = new LinkedList<GameObject>();
        }

        public int ItemCount => _itemsInInventory.Count;

        public void CreateCystal(Vector3 posiiton)
        {
            if (Random.value > GameSetting.CreateCrystallChance) return;

            var crystall = CrystallPool.Spawn();
            crystall.transform.position = posiiton;
            crystall.transform.rotation = Quaternion.Euler(Vector3.up * Random.Range(0f, 360f));

            _itemsInScene.AddLast(crystall);
        }

        public void DropItem()
        {
            CrystallPool.Despawn(_itemsInInventory.Last.Value);
            _itemsInInventory.RemoveLast();
        }

        public void DestroyAllItem()
        {
            ForEachItems(
                _itemsInScene,
                element =>
                {
                    CrystallPool.Despawn(element);
                });

            ForEachItems(
                _itemsInInventory,
                element =>
                {
                    CrystallPool.Despawn(element);
                });

            _itemsInScene.Clear();
            _itemsInInventory.Clear();
        }

        public bool TryTakeItemInRange(Vector3 position, float range, out GameObject item)
        {
            var itemNode = _itemsInScene.First;
            var distance = 0f;
            item = null;

            while(itemNode != null)
            {
                distance = (itemNode.Value.transform.position - position).magnitude;

                if(distance <= range)
                {
                    _itemsInInventory.AddLast(itemNode.Value);
                    _itemsInScene.Remove(itemNode);
                    item = itemNode.Value;

                    return true;
                }

                itemNode = itemNode.Next;
            }

            return false;
        }

        private void ForEachItems(LinkedList<GameObject> list, Action<GameObject> elementCallback)
        {
            var node = list.First;

            while(node != null)
            {
                elementCallback?.Invoke(node.Value);

                node = node.Next;
            }
        }
    }
}
