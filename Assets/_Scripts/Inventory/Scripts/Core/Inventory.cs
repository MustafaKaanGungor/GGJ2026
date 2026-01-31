using System.Collections.Generic;
using UnityEngine;

// ReSharper disable once CheckNamespace

namespace Inventory.Core
{
    public class Inventory
    {
        private readonly Dictionary<SlotType, Slot> _slots = new()
        {
            { SlotType.First, new Slot() },
            { SlotType.Second, new Slot() },
            { SlotType.Third, new Slot() }
        };

        public bool TryGetFirstEmptySlot(out Slot targetSlot)
        {
            foreach (var (_, slot) in _slots)
            {
                if (!slot.IsEmpty) continue;
                targetSlot = slot;
                return true;
            }

            targetSlot = null;
            return false;
        }

        // TODO: Replace with actual mask behaviour later.
        public void Add(SlotType slotType, GameObject gameObject)
        {
            _slots[slotType].Attach(gameObject);
        }

        public void Remove(SlotType slotType)
        {
            _slots[slotType].Attach(null);
        }
    }
}