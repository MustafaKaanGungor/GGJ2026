using System;
using System.Collections.Generic;
using UnityEngine;
using Object = System.Object;

// ReSharper disable once CheckNamespace

namespace Inventory.Core
{
    public class Inventory
    {
        public event Action<SlotType, Mask.Core.Mask, Sprite> OnAdd;
        public event Action<SlotType> OnRemove;

        private readonly Dictionary<SlotType, Slot> _slots = new()
        {
            { SlotType.First, new Slot(SlotType.First) },
            { SlotType.Second, new Slot(SlotType.Second) },
            { SlotType.Third, new Slot(SlotType.Third) }
        };

        public void RegisterEvents()
        {
            Mask.Core.Mask.OnDegrade += OnDegrade;
        }

        public void UnregisterEvents()
        {
            Mask.Core.Mask.OnDegrade -= OnDegrade;
        }

        public bool TryGetFirstEmptySlot(out Slot targetSlot)
        {
            foreach (var (_, slot) in _slots)
            {
                Debug.Log($"{slot.SlotType} is empty: {slot.IsEmpty}");
                if (!slot.IsEmpty) continue;
                targetSlot = slot;
                return true;
            }

            targetSlot = null;
            return false;
        }

        public void Add(SlotType slotType, Mask.Core.Mask mask, Sprite icon)
        {
            _slots[slotType].Attach(mask);
            OnAdd?.Invoke(slotType, mask, icon);
        }

        public Mask.Core.Mask Get(SlotType slotType)
        {
            return  _slots[slotType].AttachedMask;
        }

        public void Remove(SlotType slotType)
        {
            _slots[slotType].Attach(null);
        }

        private void OnDegrade()
        {
            foreach (var (slotType, slot) in _slots)
            {
                if (slot.IsEmpty) continue;
                if (slot.AttachedMask.Condition == 0)
                {
                    slot.AttachedMask.UnregisterEvents();
                    Remove(slotType);
                    OnRemove?.Invoke(slotType);
                }
            }
        }
    }
}