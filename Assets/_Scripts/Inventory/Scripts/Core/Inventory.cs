using System;
using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Inventory.Core
{
    public class Inventory
    {
        public event Action<SlotType, Mask.Core.Mask, Sprite> OnAdd;

        private readonly Dictionary<SlotType, Slot> _slots = new()
        {
            { SlotType.First, new Slot(SlotType.First) },
            { SlotType.Second, new Slot(SlotType.Second) },
            { SlotType.Third, new Slot(SlotType.Third) }
        };

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

        public void Remove(SlotType slotType)
        {
            _slots[slotType].Attach(null);
        }
    }
}