using System;
using Inventory.Core;
using Stats.Core;
using Unity.VisualScripting;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Player.Core
{
    [DisallowMultipleComponent]
    public class PlayerBehaviour : MonoBehaviour
    {
        public static PlayerBehaviour Instance { get; private set; }
        
        public event Action<SlotType, Mask.Core.Mask> OnMaskChange;

        private SlotType _currentActiveSlotType;
        public SlotType CurrentActiveSlotType => _currentActiveSlotType;

        public PlayerStats Stats { get; private set; } = new();
        public Inventory.Core.Inventory Inventory { get; private set; } = new();

        private void OnEnable()
        {
            Inventory.RegisterEvents();
        }

        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        private void Start()
        {
            _currentActiveSlotType = SlotType.First;
            OnMaskChange?.Invoke(_currentActiveSlotType, null);
        }

        private void OnDisable()
        {
            Inventory.UnregisterEvents();
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.D)) Stats.Damage(10);
            
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                _currentActiveSlotType = SlotType.First;
                OnMaskChange?.Invoke(_currentActiveSlotType, Inventory.Get(_currentActiveSlotType));
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentActiveSlotType = SlotType.Second;
                OnMaskChange?.Invoke(_currentActiveSlotType, Inventory.Get(_currentActiveSlotType));
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _currentActiveSlotType = SlotType.Third;
                OnMaskChange?.Invoke(_currentActiveSlotType, Inventory.Get(_currentActiveSlotType));
            }
        }
    }
}