using System;
using Inventory.Core;
using Stats.Core;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Player.Core
{
    [DisallowMultipleComponent]
    public class PlayerBehaviour : MonoBehaviour
    {
        public static event Action<SlotType> OnSlotChanged;

        private SlotType _currentActiveSlotType;

        public PlayerStats Stats { get; private set; } = new();
        public Inventory.Core.Inventory Inventory { get; private set; } = new();

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _currentActiveSlotType = SlotType.First;
                OnSlotChanged?.Invoke(_currentActiveSlotType);
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentActiveSlotType = SlotType.Second;
                OnSlotChanged?.Invoke(_currentActiveSlotType);
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _currentActiveSlotType = SlotType.Third;
                OnSlotChanged?.Invoke(_currentActiveSlotType);
            }
        }
    }
}