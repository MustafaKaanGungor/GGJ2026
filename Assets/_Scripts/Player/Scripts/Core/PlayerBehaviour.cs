using System;
using System.Collections.Generic;
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
        public Sprite[] StatIcons;

        public static PlayerBehaviour Instance { get; private set; }
        
        public event Action<SlotType, Mask.Core.Mask> OnMaskChange;

        public Dictionary<StatType, Sprite> StatIconsDict;

        private SlotType _currentActiveSlotType;
        public SlotType CurrentActiveSlotType => _currentActiveSlotType;

        public PlayerStats Stats { get; private set; } = new();
        public Inventory.Core.Inventory Inventory { get; private set; } = new();
        [SerializeField] private Sprite defaultMaskIcon;
        private Animator animator;

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
            animator = GetComponentInChildren<Animator>();
            animator.SetTrigger("GameStarted");
            _currentActiveSlotType = SlotType.First;
            OnMaskChange?.Invoke(_currentActiveSlotType, null);
            if (Inventory.TryGetFirstEmptySlot(out var slot))
            {
                var mask = new Mask.Core.Mask(
                    new Mask.Core.MaskPerk(StatType.Default, 0),
                    slot.SlotType, LaserType.Default
                );

                mask.RegisterEvents();
                Inventory.Add(slot.SlotType, mask, defaultMaskIcon);
            }
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
                animator.SetTrigger("MaskPickup");
            }

            if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                _currentActiveSlotType = SlotType.Second;
                OnMaskChange?.Invoke(_currentActiveSlotType, Inventory.Get(_currentActiveSlotType));
                animator.SetTrigger("MaskPickup");
            }

            if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                _currentActiveSlotType = SlotType.Third;
                OnMaskChange?.Invoke(_currentActiveSlotType, Inventory.Get(_currentActiveSlotType));
                animator.SetTrigger("MaskPickup");
            }
        }
    }
}