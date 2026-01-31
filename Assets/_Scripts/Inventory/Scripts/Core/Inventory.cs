using System.Collections.Generic;
using Mask.Core;
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

        public void Add(SlotType slotType, MaskBehaviour maskBehaviour)
        {
            _slots[slotType].Attach(maskBehaviour);
        }

        public void Remove(SlotType slotType)
        {
            _slots[slotType].Attach(null);
        }
    }
}